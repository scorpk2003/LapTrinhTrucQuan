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
        public BillControl()
        {
            InitializeComponent();
            Name = "BillControl" + Guid.NewGuid().ToString().Substring(0, 4);
            System.Diagnostics.Debug.WriteLine($"[-- {Name} --] Mediator has code: {Mediator.Mediator.Instance.GetHashCode()}");
            Mediator.Mediator.Instance.Register<Bill>(Name, async (bill) =>
            {
                await GetBill(bill);
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

        private void Bill_Click(object sender, EventArgs e)
        {
            name_renter.Text = name_renter.Text == "Clicked!" ? "UnCliked" : "Clicked!";
            stat.BackColor = AppColors.Success.IsEmpty ? AppColors.Fail: AppColors.Success;
            System.Diagnostics.Debug.WriteLine($"[-- {Name} --] Clicked BillControl");
        }
    }
}
