using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.src.Mediator
{
    internal class Component
    {
        String Type { get; set; }
        Control control { get; set; }
        public Component() { 
            this.Type = "";
            this.control = new Control();
        }
        public Component(String Type, Control control) {
            this.Type = Type;
            this.control = control;
        }
    }
}
