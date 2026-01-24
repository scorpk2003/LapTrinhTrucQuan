using QuanLyPhongTro.src.Test.Models;
using QuanLyPhongTro.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class FormInformation : Form
    {
        private readonly PersonService _personService;
        private readonly Person _currentPerson;
        private PersonDetail _personDetail;

        private bool _isEditing = false;

        public FormInformation(Person loggedInPerson)
        {
            InitializeComponent();

            _personService = new PersonService();
            _currentPerson = loggedInPerson;

            this.Load += FormInformation_Load;

            this.btnChonAnh.Click += BtnChonAnh_Click;
            this.btnEditSave.Click += BtnEditSave_Click;

            // Với UI mới: có btnCloseTop. Nếu bạn chưa thêm nút này thì dòng này có thể xóa.
            if (this.Controls.Find("btnCloseTop", true).Length > 0)
            {
                btnCloseTop.Click += (s, e) => this.Close();
            }

            this.btnClose.Click += (s, e) => this.Close();

            // Để avatar bo tròn theo kích thước thực tế
            this.picAvatar.SizeChanged += (s, e) => ApplyCircularAvatarMask();
        }

        private void FormInformation_Load(object sender, EventArgs e)
        {
            // Nếu bạn muốn “lấp đầy màn hình” thật sự, bật Maximize.
            // Nếu muốn cố định đúng 2550x1435 thì comment dòng này.
            // this.WindowState = FormWindowState.Maximized;

            LoadPersonInfo();
            SetEditMode(false);
            ApplyCircularAvatarMask();
        }

        private void LoadPersonInfo()
        {
            if (_currentPerson == null) return;

            txtUsername.Text = _currentPerson.Username;

            if (!_currentPerson.IdDetail.HasValue)
            {
                MessageBox.Show("Lỗi: Tài khoản này thiếu thông tin chi tiết.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            _personDetail = _personService.GetPersonDetail(_currentPerson.IdDetail.Value);

            if (_personDetail == null)
            {
                MessageBox.Show("Không tìm thấy thông tin chi tiết người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtName.Text = _personDetail.Name ?? "";
            txtCCCD.Text = _personDetail.Cccd ?? "";
            txtPhone.Text = _personDetail.Phone ?? "";

            // Load avatar
            if (_personDetail.Avatar != null && _personDetail.Avatar.Length > 0)
            {
                SetAvatarImage(ConvertByteArrayToImage(_personDetail.Avatar));
            }
            else
            {
                // Nếu bạn muốn đặt ảnh mặc định, có thể làm ở đây
                // SetAvatarImage(Properties.Resources.DefaultAvatar);
            }
        }

        private void SetEditMode(bool isEditing)
        {
            _isEditing = isEditing;

            txtName.ReadOnly = !isEditing;
            txtCCCD.ReadOnly = !isEditing;
            txtPhone.ReadOnly = !isEditing;

            // Khóa username luôn
            txtUsername.ReadOnly = true;

            btnChonAnh.Enabled = isEditing;
            btnEditSave.Text = isEditing ? "Lưu" : "Sửa";

            // Làm UI “đúng style”: khi readonly thì nền xám nhẹ, khi edit thì trắng
            ApplyReadonlyStyle(txtName, !isEditing);
            ApplyReadonlyStyle(txtCCCD, !isEditing);
            ApplyReadonlyStyle(txtPhone, !isEditing);
            ApplyReadonlyStyle(txtUsername, true);

            // Đổi màu nút theo trạng thái
            if (isEditing)
            {
                btnEditSave.BackColor = Color.FromArgb(39, 174, 96); // xanh: Lưu
                btnEditSave.ForeColor = Color.White;
                btnEditSave.FlatStyle = FlatStyle.Flat;
                btnEditSave.FlatAppearance.BorderSize = 0;
            }
            else
            {
                btnEditSave.BackColor = Color.Orange; // cam: Sửa
                btnEditSave.ForeColor = Color.White;
                btnEditSave.FlatStyle = FlatStyle.Flat;
                btnEditSave.FlatAppearance.BorderSize = 0;
            }
        }

        private void ApplyReadonlyStyle(TextBox tb, bool readOnly)
        {
            tb.ReadOnly = readOnly;
            tb.BackColor = readOnly ? Color.FromArgb(245, 247, 250) : Color.White;
            tb.ForeColor = Color.FromArgb(30, 30, 30);
        }

        private void BtnChonAnh_Click(object sender, EventArgs e)
        {
            if (!_isEditing) return;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Đọc file và tạo Bitmap độc lập, không khóa file
                    using (var fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    using (var tempImage = Image.FromStream(fileStream))
                    {
                        // Tạo bản sao Bitmap hoàn toàn độc lập
                        Bitmap newImage = new Bitmap(tempImage);
                        SetAvatarImage(newImage);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể đọc ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnEditSave_Click(object sender, EventArgs e)
        {
            if (!_isEditing)
            {
                SetEditMode(true);
                return;
            }

            // Đang ở chế độ Lưu
            try
            {
                if (_personDetail == null)
                {
                    MessageBox.Show("Không có dữ liệu người dùng để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _personDetail.Name = txtName.Text?.Trim();
                _personDetail.Cccd = txtCCCD.Text?.Trim();
                _personDetail.Phone = txtPhone.Text?.Trim();
                _personDetail.Avatar = ConvertImageToByteArray(picAvatar.Image);

                bool success = _personService.UpdatePersonDetail(_personDetail);

                if (success)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // Gán ảnh vào pictureBox, đảm bảo dispose ảnh cũ để tránh leak
        private void SetAvatarImage(Image img)
        {
            if (picAvatar.Image != null)
            {
                picAvatar.Image.Dispose();
                picAvatar.Image = null;
            }

            picAvatar.Image = img;
            ApplyCircularAvatarMask();
        }

        // Bo tròn avatar bằng Region
        private void ApplyCircularAvatarMask()
        {
            if (picAvatar.Width <= 0 || picAvatar.Height <= 0) return;

            int diameter = Math.Min(picAvatar.Width, picAvatar.Height);
            Rectangle rect = new Rectangle(
                (picAvatar.Width - diameter) / 2,
                (picAvatar.Height - diameter) / 2,
                diameter,
                diameter
            );

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(rect);
                picAvatar.Region = new Region(path);
            }
        }

        #region Convert Image <-> Byte[]

        private byte[] ConvertImageToByteArray(Image image)
        {
            if (image == null) return null;

            try
            {
                // Tạo một bản sao bitmap để tránh lỗi GDI+ khi ảnh gốc bị khóa
                using (Bitmap bitmap = new Bitmap(image))
                using (MemoryStream ms = new MemoryStream())
                {
                    // Sử dụng PNG để giữ chất lượng
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ConvertImageToByteArray: {ex.Message}");
                // Fallback: thử với JPEG nếu PNG thất bại
                try
                {
                    using (Bitmap bitmap = new Bitmap(image))
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        return ms.ToArray();
                    }
                }
                catch
                {
                    return null;
                }
            }
        }

        private Image ConvertByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0) return null;

            try
            {
                // Tạo một bản sao độc lập từ stream
                using (MemoryStream ms = new MemoryStream(byteArray))
                {
                    return new Bitmap(Image.FromStream(ms));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ConvertByteArrayToImage: {ex.Message}");
                return null;
            }
        }

        #endregion

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (picAvatar.Image != null)
            {
                picAvatar.Image.Dispose();
                picAvatar.Image = null;
            }
            base.OnFormClosing(e);
        }
    }
}
