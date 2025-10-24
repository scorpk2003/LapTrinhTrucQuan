using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.src.Mediator
{
    internal interface IMediator
    {
        public void Register<Type>(String subriberKey, Func<Type, Task> handler);
        public void Unregister(String subriberKey);
        public Task Publish<Type>(String key, Type message);
        public void RegisterFactory(String key, Func<Control> factory);
    }
}
