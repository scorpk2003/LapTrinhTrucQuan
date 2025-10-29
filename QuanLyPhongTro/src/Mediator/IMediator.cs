using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.src.Mediator
{
    public interface IMediator
    {
        public void Register<TMessage>(string subcriberKey, Func<TMessage, Task> handler);
        public void Unregister(string subcriberKey);
        public Task Publish<TMessage>(string key, TMessage message);
        public void RegisterFactory(string key, Func<Control> factory);
    }
}
