using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
namespace QuanLyPhongTro.src.Login
{
    public partial class Loginmain : Form
    {
        private Label? lblErrEmail;
        private Label? lblErrPass;

        public Loginmain()
        {
             InitializeComponent();

            // Dat placeholder
            SetPlaceholder(TbUsernameuser, "Nhập Email");
            SetPlaceholder(tbPassworduser, "Nhập mật khẩu");

            // Tao label loi
            CreateErrorLabels();

            // Ẩn ký tự password
            tbPassworduser.UseSystemPasswordChar = true;
        }
        
        private void CreateErrorLabels()
        {
            if (lblErrEmail != null) return;

            lblErrEmail = NewErrorLabelUnder(TbUsernameuser);
            lblErrPass = NewErrorLabelUnder(tbPassworduser);

            this.Controls.Add(lblErrEmail);
            this.Controls.Add(lblErrPass);
        }

        private Label NewErrorLabelUnder(Control ctrl)
        {
            Label lbl = new Label();
            lbl.ForeColor = Color.FromArgb(255, 60, 60);
            lbl.Font = new Font("Segoe UI", 8.5f, FontStyle.Regular);
            lbl.AutoSize = true;
            lbl.Text = "";
            lbl.Location = new Point(ctrl.Left, ctrl.Bottom + 2);
            return lbl;
        }
        private void btCreateaccount_Click(object sender, EventArgs e)
        {
            UserSignup signupForm = new UserSignup();
            signupForm.FormClosed += (s, args) => Application.Exit();
            signupForm.Show();
            this.Hide();
        }
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;



        // Ham dat placeholder mo
        private void SetPlaceholder(TextBox tb, string text)
        {
            // wParam = 0 => placeholder bien mat khi textbox duoc focus
            SendMessage(tb.Handle, EM_SETCUEBANNER, IntPtr.Zero, text);
        }

        // Neu muon kiem tra dieu kien hien placeholder theo y minh:
        private void UserLogin_Load(object sender, EventArgs e)
        {
            // Chi hien placeholder neu o nhap dang trong
            if (string.IsNullOrWhiteSpace(TbUsernameuser.Text))
                SetPlaceholder(TbUsernameuser, "Nhập Email");

            if (string.IsNullOrWhiteSpace(tbPassworduser.Text))
                SetPlaceholder(tbPassworduser, "Nhập mật khẩu");
        }

        private void LbForgetpass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            passwordrecovery frm = new passwordrecovery();

            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        // Hàm kiểm tra mật khẩu hợp lệ
        private bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 6;
        }
        private bool IsNetworkAvailable()
        {
            try
            {
                // Kiểm tra có kết nối mạng
                return NetworkInterface.GetIsNetworkAvailable();
            }
            catch
            {
                return false;
            }
        }
        private void btLoginuser_Click(object sender, EventArgs e)
        {
            if (!IsNetworkAvailable())
            {
                MessageBox.Show("Không có kết nối mạng. Vui lòng kiểm tra kết nối Internet.", "Lỗi mạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool ok = true;
            string username = TbUsernameuser.Text.Trim();
            string password = tbPassworduser.Text;

            // Kiểm tra email
            if (string.IsNullOrWhiteSpace(username))
            {
                lblErrEmail!.Text = "Không được để trống.";
                ok = false;
            }
            else if (!IsValidEmail(username))
            {
                lblErrEmail!.Text = "Sai định dạng email.";
                ok = false;
            }
            else
            {
                lblErrEmail!.Text = "";
            }

            // Kiểm tra mật khẩu
            if (string.IsNullOrWhiteSpace(password))
            {
                lblErrPass!.Text = "Không được để trống.";
                ok = false;
            }
            else if (!IsValidPassword(password))
            {
                lblErrPass!.Text = "Mật khẩu phải ≥ 6 ký tự.";
                ok = false;
            }
            else
            {
                lblErrPass!.Text = "";
            }

            if (!ok) return;
            UserSession.UserSession.Instance.Login(username, password);

            // Kiểm tra đăng nhập (ví dụ admin)
            if (UserSession.UserSession.Instance.IsAuthenticated)
            {
                switch (UserSession.UserSession.Instance?._user?.Role)
                {
                    case "Owner":
                        lblErrEmail.Text = "";
                        lblErrPass.Text = "";
                        Owner_TrangChu ownform = new();
                        ownform.FormClosed += (s, args) => Application.Exit();
                        ownform.Show();
                        this.Hide();
                        break;
                    case "Renter":
                        lblErrEmail.Text = "";
                        lblErrPass.Text = "";
                        Renter_TrangChu rentform = new();
                        rentform.FormClosed += (s, args) => Application.Exit();
                        rentform.Show();
                        this.Hide();
                        break;
                    default:
                        lblErrEmail.Text = "";
                        lblErrPass.Text = "";
                        ChooseLogin chooseLogin = new ChooseLogin();
                        chooseLogin.FormClosed += (s, args) => Application.Exit();
                        chooseLogin.Show();
                        this.Hide();
                        return;
                }
            }
            else
            {
                lblErrPass.Text = "Sai email hoặc mật khẩu.";
            }
        }
        private void TbUsernameuser_TextChanged(object sender, EventArgs e)
        {
            string email = TbUsernameuser.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
                lblErrEmail!.Text = "Không được để trống.";
            else if (!IsValidEmail(email))
                lblErrEmail!.Text = "Sai định dạng email.";
            else
                lblErrEmail!.Text = "";
        }

        private void tbPassworduser_TextChanged(object sender, EventArgs e)
        {
            string pass = tbPassworduser.Text;
            if (string.IsNullOrWhiteSpace(pass))
                lblErrPass!.Text = "Không được để trống.";
            else if (pass.Length < 6)
                lblErrPass!.Text = "Mật khẩu phải ≥ 6 ký tự.";
            else
                lblErrPass!.Text = "";
        }
    }
}

