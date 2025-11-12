using QuanLyPhongTro.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace QuanLyPhongTro.src.Components
{
    public partial class BillDetailControl : UserControl
    {
        private BillDetail bill_detail_session;
        public BillDetailControl()
        {
            InitializeComponent();
            Mediator.Mediator.Instance.Register<string>("BillDetailControl", async (state) =>
            {
                await UpdateState(state);
            });
            Mediator.Mediator.Instance.Register<BillDetail>(Name, async (billDetail) =>
            {
                bill_detail_session = billDetail;
                name_lb.Text = billDetail?.Bill.Id.ToString().Substring(0, 4);
                await Task.CompletedTask;
            });
        }

        private async void pay_btn_Click(object sender, EventArgs e)
        {
            bill_detail_session.Bill.Status = "paid";
            pay_btn.Enabled = false;
            await Mediator.Mediator.Instance.Publish<Bill>("BillControl", bill_detail_session.Bill);
        }
        private async Task UpdateState(string state)
        {
            try
            {
                if(state == "paid")
                {
                    pay_btn.Enabled = false;
                }
                else
                {
                    pay_btn.Enabled = true;
                }
                await Mediator.Mediator.Instance.Publish<string>("BillControl", state);
            }
            catch(Exception ex)
            {
                MessageBox.Show("BillDetailControl Update State: " + ex.Message);
            }
        }
    }
}
