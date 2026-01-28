using QuanLyPhongTro.src.Test.Models;
using QuanLyPhongTro.Services;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuanLyPhongTro.src.Signup
{
    public partial class Signup : UserControl
    {
        private readonly PersonService _personService;

        public event EventHandler GoToLogin;

        public Signup()
        {
            InitializeComponent();
            _personService = new PersonService();

            this.btnChonAnh.Click += BtnChonAnh_Click;
            this.btnSignup.Click += BtnSignup_Click;
            this.llblGoToLogin.Click += LlblGoToLogin_Click;
        }

        private void BtnChonAnh_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picAvatar.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void LlblGoToLogin_Click(object sender, EventArgs e)
        {
            GoToLogin?.Invoke(this, EventArgs.Empty);
        }

        private void BtnSignup_Click(object sender, EventArgs e)
        {
            // --- SỬA LỖI 2 (Encoding) ---
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtCCCD.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng điền tất cả thông tin bắt buộc.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = "";
            if (rdoOwner.Checked)
            {
                role = "Owner";
            }
            else if (rdoRenter.Checked)
            {
                role = "Renter";
            }
            else
            {
                MessageBox.Show("Vui lòng chọn vai trò (Chủ trọ / Người thuê).", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PersonDetail detail = new PersonDetail
            {
                Name = txtName.Text,
                Cccd = txtCCCD.Text, 
                Phone = txtPhone.Text,
                Avatar = ConvertImageToByteArray(picAvatar.Image)
            };

            Person person = new Person
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                Role = role
            };
            bool success = _personService.SignUp(person, detail);

            if (success)
            {
                MessageBox.Show("Đăng ký thành công! Vui lòng đăng nhập.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GoToLogin?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại! Tên đăng nhập có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] ConvertImageToByteArray(Image image)
        {
            if (image == null) return null;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
    }
}