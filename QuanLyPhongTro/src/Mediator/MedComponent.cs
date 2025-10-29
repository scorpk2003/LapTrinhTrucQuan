using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.src.Mediator
{
    internal class MedComponent
    {
        public string Type { get; set; }
        public Control control { get; set; }
        public MedComponent() { 
            this.Type = "";
            this.control = new Control();
        }
        public MedComponent(string Type, Control control) {
            this.Type = Type;
            this.control = control;
        }
    }
}
