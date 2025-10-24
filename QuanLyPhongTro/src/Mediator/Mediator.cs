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
        private readonly Dictionary<Type, List<(string key, Func<Object, Task> Handler)>> _subcribers = new();
        private readonly Dictionary<string, Func<Control>> _factories = new();
        private readonly HashSet<string> _initialized = new HashSet<string>();
        private readonly ConcurrentDictionary<Type, SemaphoreSlim> _locks = new();

        private static readonly Lazy<Mediator> _instance = new Lazy<Mediator>(() => new Mediator());
        public static Mediator Instance => _instance.Value;

        public void Register<Type>(string Key, Func<Type, Task> handler)
        {
            var type = typeof(Type);
            if (!_subcribers.ContainsKey(type))
            {
                _subcribers[type] = new List<(string key, Func<object, Task> Handler)>();
            }
            _subcribers[type].Add((Key, async (msg) => await handler((Type)msg)));
            _initialized.Add(Key);
        }
        public void Unregister(string subriberKey) { 
            foreach (var key in _subcribers.Values)
            {
                key.RemoveAll(k => k.key == subriberKey);
            }
            _initialized.Remove(subriberKey);
        }
        public async Task Publish<Type>(String key, Type message) {
            var type = typeof(Type);
            var semaphore = _locks.GetOrAdd(type, _ => new SemaphoreSlim(1, 1));
            await semaphore.WaitAsync();
            try
            {
                if (_subcribers.ContainsKey(type))
                {
                    foreach (var item in _factories)
                    {
                        if (!_initialized.Contains(item.Key))
                        {
                            var factoryInstance = item.Value();
                            if (factoryInstance is Control control)
                            {
                                control.Disposed += (_, _) => Unregister(item.Key);
                            }
                        }
                    }
                }
                if (_subcribers.TryGetValue(type, out var handlers))
                {
                    var target = handlers.Where(h => h.key != key);
                    var task = target.Select(handler => handler.Handler(message));
                    await Task.WhenAll(task);
                }
                else
                {
                    throw new Exception("No subscriber for this message type");
                }
            }
            finally
            {
                semaphore.Release();
            }
        }
        public void RegisterFactory(string key, Func<Control> factory) => _factories[key] = factory;
    }
}
