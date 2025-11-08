using QuanLyPhongTro.Model;
using QuanLyPhongTro.Services;
using System;
using System.Windows.Forms;

namespace QuanLyPhongTro.src.Login
{
    public partial class Login : UserControl
    {
        private readonly PersonService _personService;

        // Định nghĩa các Event để giao tiếp với Form cha
        public event Action<Person> LoginSuccess; // Gửi thông tin User khi thành công
        public event EventHandler GoToSignup;     // Báo cho Form cha chuyển

        public Login()
        {
            InitializeComponent();
            _personService = new PersonService();

            // Gán sự kiện
            this.btnLogin.Click += BtnLogin_Click;
            this.llblGoToSignup.Click += LlblGoToSignup_Click;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.");
                return;
            }

            // Gọi service
            Person person = _personService.GetAccount(username, password);

            if (person == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Đăng nhập thành công!
                // Gửi sự kiện (event) báo cho Form cha
                LoginSuccess?.Invoke(person);
            }
        }

        private void LlblGoToSignup_Click(object sender, EventArgs e)
        {
            // Gửi sự kiện báo cho Form cha chuyển sang UserControl Đăng Ký
            GoToSignup?.Invoke(this, EventArgs.Empty);
        }
    }
}