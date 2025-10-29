using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.src.Mediator
{
    internal class Mediator: IMediator
    {
        private readonly Dictionary<Type, List<(string key, Func<object, Task> Handler)>> _subscribers = new();
        private readonly Dictionary<string, Func<Control>> _factories = new();
        private readonly HashSet<string> _initialized = new HashSet<string>();
        private readonly ConcurrentDictionary<Type, SemaphoreSlim> _locks = new();
        private readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);

        private static readonly Lazy<Mediator> _instance = new Lazy<Mediator>(() => new Mediator());
        public static Mediator Instance => _instance.Value;

        public void Register<TMessage>(string Key, Func<TMessage, Task> handler)
        {
            try
            {
                if (string.IsNullOrEmpty(Key)) throw new ArgumentNullException("Register: Key is Empty");
                if (handler == null) throw new ArgumentNullException("Register: Handler is Null");
                var type = typeof(TMessage);
                if (!_subscribers.ContainsKey(type))
                {
                    _subscribers[type] = new List<(string key, Func<object, Task> Handler)>();
                }
                _subscribers[type].Add((Key, async (msg) => await handler((TMessage)msg)));
                _initialized.Add(Key);
            }
            catch (Exception ex)
            {
                throw new Exception("Register: " + ex.Message);
            }
        }
        public void Unregister(string subriberKey)
        {
            try
            {
                if (string.IsNullOrEmpty(subriberKey)) return;
                foreach (var key in _subscribers.Values)
                {
                    key.RemoveAll(k => k.key == subriberKey);
                }
                _initialized.Remove(subriberKey);
            }
            catch (Exception ex) {
                throw new Exception("Unregister: " + ex.Message);
            }
        }
        public async Task Publish<TMessage>(String key, TMessage message) {
            var type = typeof(TMessage);
            var semaphore = _locks.GetOrAdd(type, _ => new SemaphoreSlim(1, 1));
            await semaphore.WaitAsync();
            try
            {
                if (!_subscribers.ContainsKey(type) || _subscribers[type].Any(h => h.key == key))
                {
                    await AutoInit(type, key);
                }

                if (!_subscribers.TryGetValue(type, out var handlers))
                {
                    throw new Exception("Publish: No subscriber for " + type +" Type");
                }

                var target = handlers.Where(h => h.key == key);
                try
                {
                    var task = target.Select(handler => handler.Handler(message));
                    await Task.WhenAll(task);
                }
                catch (Exception ex)
                {
                    throw new Exception("Publish: Handler " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Publish: " + ex.Message + " Fail in First");
            }
            finally
            {
                semaphore.Release();
            }
        }
        public void RegisterFactory(string key, Func<Control> factory)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                    throw new ArgumentException("Register Factory: Key is Empty", nameof(key));
                if(factory == null) 
                    throw new ArgumentNullException("Register Factory: Factory is Null", nameof(factory));
                _factories[key] = factory;
            }
            catch (Exception ex)
            {

            }
        }
        private async Task AutoInit(Type MessageType, string key) {
            await _lock.WaitAsync();
            try
            {
                if (_factories.TryGetValue(key, out var factory))
                {
                    if (!_initialized.Contains(key))
                    {
                        Control factoryInstance = null;
                        if (Application.OpenForms.Count > 0)
                        {
                            var MainForm = Application.OpenForms[0];
                            if (MainForm.InvokeRequired)
                            {
                                await Task.Run(() =>
                                {
                                    MainForm.Invoke(new Action(() =>
                                    {
                                        try
                                        {
                                            factoryInstance = factory();
                                        }
                                        catch (Exception ex)
                                        {
                                            throw new Exception("Auto-Init Thread UI: " + ex.Message);
                                        }
                                    }));
                                });
                            }
                            else
                            {
                                factoryInstance = factory();
                            }
                        }
                        else
                        {
                            factoryInstance = factory();
                        }
                        if (factoryInstance == null)
                            throw new Exception("Auto-Init Auto Create: Key not found");
                        factoryInstance.Disposed += (_, _) => Unregister(key);
                    }
                }
                else
                {
                    throw new Exception("Auto-Init: Key was not Register");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("AutoInit: Can not Auto create for " + ex.Message);
            }
            finally
            {
                _lock.Release();
            }
        }
    }
}
