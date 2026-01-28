using QuanLyPhongTro.src.Test.Models;
using QuanLyPhongTro.Services;
using System;
using System.Windows.Forms;

namespace QuanLyPhongTro.src.Login
{
    public partial class Login : UserControl
    {
        private readonly PersonService _personService;

        public event Action<Person> LoginSuccess;
        public event EventHandler GoToSignup;

        public Login()
        {
            InitializeComponent();
            _personService = new PersonService();

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

            Person person = _personService.GetAccount(username, password);

            if (person == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LoginSuccess?.Invoke(person);
            }
        }

        private void LlblGoToSignup_Click(object sender, EventArgs e)
        {
            GoToSignup?.Invoke(this, EventArgs.Empty);
        }
    }
}