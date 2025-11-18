using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
namespace QuanLyPhongTro.src.Login
{
    public partial class ChooseLogin : Form
    {
        public ChooseLogin()
        {
            InitializeComponent();
        }
        private bool IsConnectedToInternet()
        {
            try
            {
                using (var ping = new Ping())
                {
                    var reply = ping.Send("8.8.8.8", 1000); // Ping Google DNS
                    return reply.Status == IPStatus.Success;
                }
            }
            catch
            {
                return false;
            }
        }

        private async void btnUser_Click(object sender, EventArgs e)
        {
            Renter_TrangChu form = new();
            form.Show();
            this.Hide();
            await Task.CompletedTask;
        }

        private async void btnAdmin_Click(object sender, EventArgs e)
        {
            Owner_TrangChu form = new();
            form.Show();
            this.Hide();
            await Task.CompletedTask;
        }
    }
}
    

