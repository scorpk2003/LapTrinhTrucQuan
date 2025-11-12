using QuanLyPhongTro.src.Test.Model;
using QuanLyPhongTro.src.Test.Services;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyPhongTro
{
    public partial class FormInformation : Form
    {
        private readonly PersonService _personService;
        private readonly Person _currentPerson;
        private PersonDetailcs _personDetail; // Biến lưu trữ thông tin chi tiết

        public FormInformation(Person loggedInPerson)
        {
            InitializeComponent();
            _personService = new PersonService();
            _currentPerson = loggedInPerson;

            // Gán sự kiện
            this.Load += FormInformation_Load;
            this.btnChonAnh.Click += BtnChonAnh_Click;
            this.btnEditSave.Click += BtnEditSave_Click;
            this.btnClose.Click += (s, e) => this.Close();
        }

        private void FormInformation_Load(object sender, EventArgs e)
        {
            // 1. Tải thông tin
            LoadPersonInfo();
            // 2. Đặt chế độ chỉ đọc (Read-only) ban đầu
            SetEditMode(false);
        }

        /// <summary>
        /// Tải thông tin Person và PersonDetail lên Form
        /// </summary>
        private void LoadPersonInfo()
        {
            if (_currentPerson == null) return;

            // Hiển thị tên đăng nhập
            txtUsername.Text = _currentPerson.Username;

            // Lấy thông tin chi tiết từ Service
            _personDetail = _personService.GetPersonDetail(_currentPerson.Id);

            if (_personDetail != null)
            {
                // Hiển thị thông tin
                txtName.Text = _personDetail.Name;
                txtCCCD.Text = _personDetail.CCCD;
                txtPhone.Text = _personDetail.Phone;

                // Hiển thị avatar (chuyển byte[] -> Image)
                if (_personDetail.Avatar != null && _personDetail.Avatar.Length > 0)
                {
                    picAvatar.Image = ConvertByteArrayToImage(_personDetail.Avatar);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin chi tiết người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        /// <summary>
        /// Bật/Tắt chế độ chỉnh sửa
        /// </summary>
        private void SetEditMode(bool isEditing)
        {
            txtName.ReadOnly = !isEditing;
            txtCCCD.ReadOnly = !isEditing;
            txtPhone.ReadOnly = !isEditing;
            btnChonAnh.Enabled = isEditing;

            btnEditSave.Text = isEditing ? "Lưu" : "Sửa";
        }

        private void BtnChonAnh_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Giải phóng ảnh cũ (nếu có)
                if (picAvatar.Image != null)
                {
                    picAvatar.Image.Dispose();
                }
                // Hiển thị ảnh mới
                picAvatar.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void BtnEditSave_Click(object sender, EventArgs e)
        {
            if (btnEditSave.Text == "Sửa")
            {
                // Chuyển sang chế độ Sửa
                SetEditMode(true);
            }
            else
            {
                // Đang ở chế độ Lưu -> Thực hiện lưu
                try
                {
                    // 1. Cập nhật đối tượng _personDetail từ Form
                    _personDetail.Name = txtName.Text;
                    _personDetail.CCCD = txtCCCD.Text;
                    _personDetail.Phone = txtPhone.Text;
                    _personDetail.Avatar = ConvertImageToByteArray(picAvatar.Image);

                    // 2. Gọi Service
                    bool success = _personService.UpdatePersonDetail(_personDetail);

                    if (success)
                    {
                        MessageBox.Show("Cập nhật thông tin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // 3. Chuyển về chế độ chỉ đọc
                        SetEditMode(false);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region Hàm hỗ trợ chuyển đổi Ảnh

        private byte[] ConvertImageToByteArray(Image image)
        {
            if (image == null)
            {
                return null;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private Image ConvertByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
            {
                return null;
            }
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        #endregion

        // Giải phóng ảnh khi đóng Form
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (picAvatar.Image != null)
            {
                picAvatar.Image.Dispose();
            }
            base.OnFormClosing(e);
        }
    }
}