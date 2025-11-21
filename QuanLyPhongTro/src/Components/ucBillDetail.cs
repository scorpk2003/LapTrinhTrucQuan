using QuanLyPhongTro.src.Models;
using QuanLyPhongTro.src.Services1;
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
        private BillDetail? bill_detail_session;

        public event EventHandler<Guid>? ExportPDFClicked;
        public event EventHandler<Guid>? EditDetailsClicked;

        public ucBillDetail()
        {
            InitializeComponent();
            Mediator.Mediator.Instance.Register<BillDetail>(Name, async (billDetail) =>
            {
                if (billDetail == null) return;
                bill_detail_session = billDetail;
                BindData();
                await Task.CompletedTask;
            });
            this.btnSendBill.Click += (s, e) => EditDetailsClicked?.Invoke(this, bill_detail_session!.IdBillNavigation!.Id);
            this.btnExportPDF.Click += (s, e) => ExportPDFClicked?.Invoke(this, bill_detail_session!.IdBillNavigation!.Id);

        }

        private async void pay_btn_Click(object sender, EventArgs e)
        {
            if(bill_detail_session?.IdBillNavigation != null)
                bill_detail_session.IdBillNavigation.Status = State.Paid;
            pay_btn.Enabled = false;
            BillService billService = new BillService();
            bool result = billService.PayBill(bill_detail_session!.IdBillNavigation!.Id, 1, "");
            await Mediator.Mediator.Instance.Publish<Bill>("ucBill", bill_detail_session?.IdBillNavigation!);
        }
        private void BindData()
        {
            name_lb.Text = bill_detail_session?.IdBillNavigation?.IdRoomNavigation?.Name;
            if (bill_detail_session?.IdBillNavigation?.Status == State.Paid)
            {
                pay_btn.Enabled = false;
                pay_btn.Text = bill_detail_session?.IdBillNavigation?.Status;
            }
        }
    }
}
