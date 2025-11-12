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
        private Bill bill_session;
        public BillControl()
        {
            InitializeComponent();
            Name = "BillControl" + Guid.NewGuid().ToString().Substring(0, 4);
            System.Diagnostics.Debug.WriteLine($"[-- {Name} --] Mediator has code: {Mediator.Mediator.Instance.GetHashCode()}");
            Mediator.Mediator.Instance.Register<Bill>(Name, async (bill) =>
            {
                if (bill_session == null)
                    bill_session = bill;
                await GetBill(bill_session);
            });
        }

        private async Task GetBill(Bill bill)
        {
            try
            {
                if(bill == null)
                {
                    throw new Exception("GetBill: bill is null");
                }

                // Bind Bill data here

                name_renter.Text = bill.Id.ToString().Substring(0, 4);

                // End Bind

                if (bill.Status == "Unpaid")
                {
                    stat.Text = "Unpaid";
                    stat.BackColor = Color.Red;
                }
                else
                {
                    stat.Text = "Paid";
                    stat.BackColor = Color.Green;
                }
                await Task.CompletedTask;
            }
            catch(Exception ex)
            {
                MessageBox.Show("BillControl: " + ex.Message);
            }
        }

        private void stat_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void Bill_Click(object sender, EventArgs e)
        {
            if (!Mediator.Mediator.Instance.TryLock("BillDetailControl")) return;
            Form Detail = new();
            Detail.Width = 450;
            Detail.Height = 600;
            BillDetail detail = new();
            detail.Bill = bill_session;
            await Mediator.Mediator.Instance.PublishForm<BillDetail>("BillDetailControl", detail, async (control) =>
            {
                Detail.Controls.Add(control);
                Detail.FormClosed += (_, _) =>
                {
                    Mediator.Mediator.Instance.ReleaseLock("BillDetailControl");
                };
                Detail.Show();
                await Task.CompletedTask;
            });
            System.Diagnostics.Debug.WriteLine($"[-- {Name} --] Clicked BillControl");
        }
    }
}
