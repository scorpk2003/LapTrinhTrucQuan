using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro.src.Mediator
{
    public class Mediator : IMediator
    {
        private readonly Dictionary<Type, List<(string key, Func<object, Task> Handler)>> _subscribers = new();
        private readonly Dictionary<string, Func<Control>> _factories = new();
        private readonly Dictionary<string, Control> _cacheControl = new();
        private readonly ConcurrentDictionary<Type, SemaphoreSlim> _locks = new();
        private readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);
        private readonly HashSet<string> _formActive = new();

        private static readonly Lazy<Mediator> _instance = new Lazy<Mediator>(() => new Mediator());
        public static Mediator Instance => _instance.Value;
        private readonly string _instanceId = Guid.NewGuid().ToString("N").Substring(0, 8);
        private readonly DateTime _createdAt = DateTime.Now;
        private Mediator()
        {
            var stackTrace = new StackTrace(true);
            Debug.WriteLine("\n\n\t\t+------------------------------------------------------------+");
            Debug.WriteLine($"\t\t¦ NEW MEDIATOR INSTANCE CREATED!");
            Debug.WriteLine($"\t\t¦ Instance ID: {_instanceId}");
            Debug.WriteLine($"\t\t¦ Created At: {_createdAt:HH:mm:ss.fff}");
            Debug.WriteLine($"\t\t¦ Thread ID: {Environment.CurrentManagedThreadId}");
            Debug.WriteLine($"\t\t¦ HashCode: {GetHashCode()}");
            Debug.WriteLine("\t\t¦ Call Stack:");

            for (int i = 0; i < Math.Min(stackTrace.FrameCount, 10); i++)
            {
                var frame = stackTrace.GetFrame(i);
                var method = frame.GetMethod();
                Debug.WriteLine($"\t\t¦   {i}: {method?.DeclaringType?.Name}.{method?.Name} (Line {frame.GetFileLineNumber()})");
            }
            Debug.WriteLine("\t\t+------------------------------------------------------------+\n\n");
        }

        public void Register<TMessage>(string Key, Func<TMessage, Task> handler)
        {
            try
            {
                if (string.IsNullOrEmpty(Key)) throw new ArgumentNullException("\n\t[Register] | Key is Empty | **Fail**");
                if (handler == null) throw new ArgumentNullException("\n\t[Register] | Handler is Null | **Fail**");
                var type = typeof(TMessage);
                if (!_subscribers.ContainsKey(type))
                {
                    _subscribers[type] = new List<(string key, Func<object, Task> Handler)>();
                }
                if (_subscribers[type].Any(h => h.key == Key))
                {
                    throw new Exception("\n\t[Register] | Key already registered for " + type.Name + " Type | **Fail**");
                }
                _subscribers[type].Add((Key, async (msg) => await handler((TMessage)msg)));
                Debug.WriteLine($"\n\t[Register] | Key='{Key}', Type='{type.Name}' | **Success**");
            }
            catch (Exception ex)
            {
                throw new Exception($"\n\t[Register] | Key='{Key} - Type='{typeof(TMessage).Name}' | **Fail** - {ex.Message}");
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
                _cacheControl.Remove(subriberKey);
                Debug.WriteLine($"\n\t[Unregister] | Key='{subriberKey}' | **Success**");
            }
            catch (Exception ex)
            {
                throw new Exception("\n\t[Unregister] | " + ex.Message + " | **Fail**");
            }
        }
        public async Task Publish<TMessage>(string key, TMessage message)
        {
            var type = typeof(TMessage);
            var semaphore = _locks.GetOrAdd(type, _ => new SemaphoreSlim(1, 1));
            await semaphore.WaitAsync();
            try
            {
                if (_factories.ContainsKey(key) && !_cacheControl.ContainsKey(key))
                {
                    await AutoInit(type, key);
                }

                if (!_subscribers.TryGetValue(type, out var handlers))
                {
                    throw new InvalidOperationException("\n\t[Publish] | No subscriber for " + type.Name + " Type | **Fail**");
                }

                var target = handlers.Where(h => h.key.Contains(key)).ToList();
                if (!target.Any())
                    throw new InvalidOperationException("\n\t[Publish] | No subscriber for Key " + key + " | **Fail**");
                try
                {
                    var task = target.Select(handler => handler.Handler(message!));
                    await Task.WhenAll(task);
                }
                catch (Exception ex)
                {
                    throw new Exception("\n\t[Publish] | Handler " + ex.Message + " | **Fail**");
                }
                Debug.WriteLine($"\n\t[Publish] | Key='{key}', Type='{type.Name}' | **Success**");
            }
            catch (Exception ex)
            {
                throw new Exception("\n\t[Publish] | " + ex.Message + " | **Fail**");
            }
            finally
            {
                semaphore.Release();
                Debug.WriteLine($"\n\t[Publish] | Key='{key}', Type='{type.Name}' | **Completed**");
            }
        }
        public async Task PublishForm<TMessage>(string key, TMessage message, Action<Control> ControlReady)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("\n\t[PublishForm] | Key is Empty | ", nameof(key));
            await Publish(key, message);
            try
            {
                if (_cacheControl.TryGetValue(key, out var control))
                    ControlReady?.Invoke(control);
                Debug.WriteLine($"\n\t[Form] - [Publish] | Key='{key}' | **Success**");
            }
            catch (Exception ex)
            {
                throw new Exception("\n\t[Form] - [Publish] | " + ex.Message + " | **Fail**");
            }
        }
        public async Task PublishList<TMessage>(string key, IEnumerable<TMessage> messages, Action<List<Control>> ControlReady)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("\n\t[List] - [Publish] | Key is Empty | - ", nameof(key));
            if (messages == null || !messages.Any())
            {
                ControlReady?.Invoke(new List<Control>());
                throw new ArgumentException("\n\t[List] - [Publish] | No Data to Publish | **Fail** - ", nameof(messages));
            }
            var type = typeof(TMessage);
            var semaphore = _locks.GetOrAdd(type, _ => new SemaphoreSlim(1, 1));
            await semaphore.WaitAsync();
            try
            {
                var controls = new List<Control>();
                foreach (var message in messages)
                {
                    ClearCache(key);
                    var control = await AutoInit(type, key);
                    string subcriberKey = control?.Name ?? string.Empty;
                    if (_subscribers.TryGetValue(type, out var handler))
                    {
                        var target = handler.Where(h => h.key == subcriberKey).ToList();
                        if (!target.Any())
                            throw new InvalidOperationException("\n\t[List] - [Publish] | No subscriber for Key " + key + " | **Fail**");
                        try
                        {
                            var task = target.Select(h => h.Handler(message!));
                            await Task.WhenAll(task);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("\n\t[List] - [Publish] | Handler " + ex.Message + " | **Fail**");
                        }
                    }
                    controls.Add(control!);
                    Debug.WriteLine($"\n\t[List] - [Publish] | message {message} add to control | **Success**");
                }
                ControlReady?.Invoke(controls);
                Debug.WriteLine($"\n\t[List] - [Publish] | Key='{key}' | **Success**");
            }
            catch (Exception ex)
            {
                throw new Exception("\n\t[List] - [Publish] | " + ex.Message + " | **Fail**");
            }
            finally
            {
                semaphore.Release();
                Debug.WriteLine($"\n\t[List] - [Publish] | Key='{key}' | **Completed**");
            }
        }
        public void RegisterFactory(string key, Func<Control> factory)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                    throw new ArgumentException("\n\t[Register] - [Factory] | Key is Empty | ", nameof(key));
                if (factory == null)
                    throw new ArgumentNullException("\n\t[Register] - [Factory] | Factory is Null | ", nameof(factory));
                Debug.WriteLine($"[Register] - [Factory] | Key='{key}' | **Success**");
                _factories[key] = factory;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"\n\t[Register] - [Factory] | Key='{key}' | " + ex.Message + " | **Fail**");
            }
        }
        private void ClearCache(string key)
        {
            _cacheControl.Remove(key);
            Debug.WriteLine($"[Control] - [Clear] - [Cache] | **Success**");
        }
        private async Task<Control> AutoInit(Type MessageType, string key)
        {
            await _lock.WaitAsync();
            try
            {
                if (_cacheControl.TryGetValue(key, out var cache))
                {
                    if (!cache.IsDisposed)
                        return cache;
                    _cacheControl.Remove(key);
                }
                if (_factories.TryGetValue(key, out var factory))
                {


                    Control factoryInstance = null;
                    if (Application.OpenForms.Count > 0)
                    {
                        var MainForm = Application.OpenForms[0];
                        if (MainForm!.InvokeRequired)
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
                                        throw new Exception("\n\t[Auto-Init] | Thread UI: " + ex.Message + " | **Fail**");
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
                        throw new Exception("\n\t[Auto-Init] - [Create] | Key not found |");


                    _cacheControl[key] = factoryInstance;
                    factoryInstance.Disposed += (_, _) => Unregister(factoryInstance.Name);
                    Debug.WriteLine($"\n\t[Auto-Init] | Key='{key}' factory='{factoryInstance.Name}' | **Success**");
                    return factoryInstance;
                }
                else
                {
                    Debug.WriteLine($"\n\t[Auto-Init] | Key='{key}' Factory Not Found | **Fail**");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("\n\t[Auto-Init] | " + ex.Message + " | **Fail**");
            }
            finally
            {
                _lock.Release();
                Debug.WriteLine($"\n\t[Auto-Init] | Key='{key}' | **Completed**");
            }
            return null;
        }
        public bool TryLock(string key)
        {
            if (_formActive.Contains(key))
                return false;
            _formActive.Add(key);
            Debug.WriteLine($"\n\t[Lock] | Key='{key}' | **Success**");
            return true;
        }
        public void ReleaseLock(string key)
        {
            _formActive.Remove(key);
            Debug.WriteLine($"\n\t[Release] [Lock] | Key='{key}' | **Success**");
        }
    }
}
