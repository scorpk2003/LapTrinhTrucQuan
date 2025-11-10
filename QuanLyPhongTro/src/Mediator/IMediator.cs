using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.src.Mediator
{
    public interface IMediator
    {
        public void Register<TMessage>(string subriberKey, Func<TMessage, Task> handler);
        public void Unregister(string subriberKey);
        public Task Publish<TMessage>(string key, TMessage message);
        public void RegisterFactory(string key, Func<Control> factory);
        public Task PublishForm<TMessage>(string key, TMessage message, Action<Control> ControlReady);
        public Task PublishList<TMessage>(string key, IEnumerable<TMessage> message, Action<List<Control>> ControlReady);
        public void Dispose<TMessage>();
    }
}
