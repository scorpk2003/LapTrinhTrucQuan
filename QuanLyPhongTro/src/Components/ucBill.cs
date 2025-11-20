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
    public partial class ucBill : UserControl
    {
        private Bill bill_session = new();
        public ucBill()
        {
            InitializeComponent();
            Name = "ucBill" + Guid.NewGuid().ToString().Substring(0, 4);
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

                name_room.Text = bill_session?.Room?.Name;
                name_opp.Text = bill_session?.Person?.Username;
                date_create.Value = bill_session.PaymentDate;
                date_create.Enabled = false;

                /*
                 * Get User -> Role -> Bind Role to label
                 */

                // End Bind

                if (bill.Status == "Chưa Thanh Toán")
                {
                    stat.Text = bill.Status;
                    stat.BackColor = Color.Red;
                }
                else
                {
                    stat.Text = bill.Status;
                    stat.BackColor = Color.Green;
                }
                await Task.CompletedTask;
            }
            catch(Exception ex)
            {
                MessageBox.Show("BillControl: " + ex.Message);
            }
        }

        private async void Bill_Click(object sender, EventArgs e)
        {
            if (!Mediator.Mediator.Instance.TryLock("ucBillDetail")) return;
            Form Detail = new();
            Detail.AutoSize = true;
            BillDetail detail = new();
            detail.Bill = bill_session;
            await Mediator.Mediator.Instance.PublishForm<BillDetail>("ucBillDetail", detail, async (control) =>
            {
                Detail.Controls.Add(control);
                Detail.FormClosed += (_, _) =>
                {
                    Mediator.Mediator.Instance.ReleaseLock("ucBillDetail");
                };
                Detail.Show();
                await Task.CompletedTask;
            });
            System.Diagnostics.Debug.WriteLine($"[-- {Name} --] Clicked BillControl");
        }
    }
}
