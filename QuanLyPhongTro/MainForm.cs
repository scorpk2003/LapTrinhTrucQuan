using QuanLyPhongTro.src.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {

            // Tạo đối tượng form đăng nhập người dùng
            UserLogin loginForm = new UserLogin();

            // Ẩn form hiện tại (MainForm)
            this.Hide();

            // Hiển thị form đăng nhập
            loginForm.ShowDialog();
        
           
            // Sau khi đóng form đăng nhập, hiện lại form chính (nếu cần)
            this.Show();


        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {

            AdminLogin adminLoginForm = new AdminLogin();
            this.Hide();
            adminLoginForm.ShowDialog();
           
          
            this.Show();
        }
   
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
