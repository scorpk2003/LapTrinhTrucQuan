using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyPhongTro.Model;
using QuanLyPhongTro.src.Mediator;
using QuanLyPhongTro.src.UserSession;

namespace QuanLyPhongTro.src.Components
{
    public partial class BillControl : UserControl
    {
        private readonly IMediator _mediator = Mediator.Mediator.Instance;
        private readonly UserSession.UserSession _user = UserSession.UserSession.Instance;
        private Mediator.MedComponent _component = new();
        public BillControl()
        {
            InitializeComponent();
        }

        private async Task GetBill(Bill bill)
        {
            name_room.Text = "abc";
            name_renter.Text = "abc";
            if (bill.Status == "Unpaid")
            {
                stat.Text = "Unpaid";
            }
            else
            {
                stat.Text = "Paid";
            }
            await _mediator.Publish(Name, this);
        }

        private void stat_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Bill_Click(object sender, EventArgs e)
        {
        }
    }
}
