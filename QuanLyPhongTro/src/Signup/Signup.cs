using QuanLyPhongTro.Model;
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

        // Định nghĩa Event
        public event EventHandler GoToLogin; // Báo cho Form cha chuyển

        public Signup()
        {
            InitializeComponent();
            _personService = new PersonService();

            // Gán sự kiện
            this.btnChonAnh.Click += BtnChonAnh_Click;
            this.btnSignup.Click += BtnSignup_Click;
            this.llblGoToLogin.Click += LlblGoToLogin_Click;
        }

        private void BtnChonAnh_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Hiển thị ảnh
                picAvatar.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void LlblGoToLogin_Click(object sender, EventArgs e)
        {
            // Gửi sự kiện báo cho Form cha
            GoToLogin?.Invoke(this, EventArgs.Empty);
        }

        private void BtnSignup_Click(object sender, EventArgs e)
        {
            // --- 1. Validation (Kiểm tra dữ liệu) ---
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

            // --- 2. Tạo đối tượng ---
            PersonDetailcs detail = new PersonDetailcs
            {
                Name = txtName.Text,
                CCCD = txtCCCD.Text,
                Phone = txtPhone.Text,
                Avatar = ConvertImageToByteArray(picAvatar.Image) // Chuyển ảnh
            };

            Person person = new Person
            {
                Username = txtUsername.Text,
                // LƯU Ý: Đây là mật khẩu thô, rất không an toàn
                // Trong dự án thật, bạn PHẢI băm (hash) mật khẩu này
                Password = txtPassword.Text,
                Role = role
            };

            // --- 3. Gọi Service ---
            // Hàm SignUp của bạn đã có Transaction, rất tốt!
            bool success = _personService.SignUp(person, detail);

            if (success)
            {
                MessageBox.Show("Đăng ký thành công! Vui lòng đăng nhập.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Tự động chuyển về trang đăng nhập
                GoToLogin?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại! Tên đăng nhập có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // --- Hàm Hỗ Trợ Chuyển Đổi Ảnh ---

        /// <summary>
        /// Chuyển đổi một đối tượng Image thành mảng byte (byte[]).
        /// </summary>
        private byte[] ConvertImageToByteArray(Image image)
        {
            if (image == null)
            {
                return null;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                // Lưu ảnh với định dạng Jpeg để tiết kiệm dung lượng
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
    }
}