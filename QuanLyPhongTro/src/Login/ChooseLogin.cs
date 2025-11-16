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

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (!IsConnectedToInternet())
            {
                MessageBox.Show("Không có kết nối mạng. Vui lòng kiểm tra mạng trước khi đăng nhập.", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Loginmain userlogin = new Loginmain();
            this.Hide();
            userlogin.FormClosed += (s, args) => this.Close();
            userlogin.Show();

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
           
        }
    }
}
    

