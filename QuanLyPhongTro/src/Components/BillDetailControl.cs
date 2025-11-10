using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro.src.Components
{
    public partial class BillDetailControl : UserControl
    {
        public BillDetailControl()
        {
            InitializeComponent();
            Mediator.Mediator.Instance.Register<string>("BillDetailControl", async (state) =>
            {
                await UpdateState(state);
            });
        }

        private void pay_btn_Click(object sender, EventArgs e)
        {

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
                await Task.CompletedTask;
            }
            catch(Exception ex)
            {
                MessageBox.Show("BillDetailControl Update State: " + ex.Message);
            }
        }
    }
}
