using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyPhongTro.src.Mediator;

namespace QuanLyPhongTro.src.Components
{
    public partial class Bill : UserControl
    {
        private readonly IMediator _mediator = EvenMediator.Instance;
        public Bill()
        {
            InitializeComponent();
        }

        private void stat_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
