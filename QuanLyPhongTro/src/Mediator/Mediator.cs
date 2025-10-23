using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.src.Mediator
{
    internal class EvenMediator: IMediator
    {
        private readonly Dictionary<Type, List<(string key, Func<Object, Task> Handler)>> _subcribers = new();
        private readonly Dictionary<string, Func<object>> _factories = new();
        private readonly HashSet<string> _initialized = new HashSet<string>();

        private static readonly Lazy<EvenMediator> _instance = new (() => new EvenMediator());
        public static EvenMediator Instance => _instance.Value;

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
        public async Task Publish<Type>(Type message) {
            var type = typeof(Type);
            if (_subcribers.ContainsKey(type))
            {
                foreach(var item in _factories)
                {
                    if(!_initialized.Contains(item.Key))
                    {
                        var factoryInstance = item.Value();
                    }
                }
            }
            if(_subcribers.TryGetValue(type, out var handlers))
            {
                var task = handlers.Select(handler => handler.Handler(message));
                await Task.WhenAll(task);
            }else
            {
                throw new Exception("No subscriber for this message type");
            }
        }
        public void RegisterFactory(string key, Func<object> factory) => _factories[key] = factory;
    }
}
