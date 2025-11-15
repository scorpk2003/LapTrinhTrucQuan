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
    public partial class ucBillDetail : UserControl
    {
        private BillDetail bill_detail_session = new();
        public ucBillDetail()
        {
            InitializeComponent();
            Mediator.Mediator.Instance.Register<BillDetail>(Name, async (billDetail) =>
            {
                bill_detail_session = billDetail;
                BindData();
                await Task.CompletedTask;
            });
        }

        private async void pay_btn_Click(object sender, EventArgs e)
        {
            bill_detail_session.Bill.Status = "Đã Thanh Toán";
            pay_btn.Enabled = false;
            await Mediator.Mediator.Instance.Publish<Bill>("ucBill", bill_detail_session.Bill);
        }
        private void BindData()
        {
            name_lb.Text = bill_detail_session?.Bill.Id.ToString().Substring(0, 4);
            if (bill_detail_session?.Bill.Status == "Đã Thanh Toán")
            {
                pay_btn.Enabled = false;
                pay_btn.Text = bill_detail_session?.Bill.Status;
            }
        }
    }
}
