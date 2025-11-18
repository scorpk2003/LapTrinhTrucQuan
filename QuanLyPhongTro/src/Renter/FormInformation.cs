using QuanLyPhongTro.src.Models;
using QuanLyPhongTro.src.Services1;
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
        private PersonDetail _personDetail;

        public FormInformation(Person loggedInPerson)
        {
            InitializeComponent();
            _personService = new PersonService();
            _currentPerson = loggedInPerson;

            this.Load += FormInformation_Load;
            this.btnChonAnh.Click += BtnChonAnh_Click;
            this.btnEditSave.Click += BtnEditSave_Click;
            this.btnClose.Click += (s, e) => this.Close();
        }

        private void FormInformation_Load(object sender, EventArgs e)
        {
            LoadPersonInfo();
            SetEditMode(false);
        }

        /// <summary>
        /// T?i thông tin Person và PersonDetail lên Form
        /// </summary>
        private void LoadPersonInfo()
        {
            if (_currentPerson == null) return;

            txtUsername.Text = _currentPerson.Username;

            if (!_currentPerson.IdDetail.HasValue)
            {
                MessageBox.Show("Lỗi: Tài khoản này thiếu thông tin chi tiết.");
                this.Close();
                return;
            }

            _personDetail = _personService.GetPersonDetail(_currentPerson.IdDetail.Value);

            if (_personDetail != null)
            {
                txtName.Text = _personDetail.Name;
                txtCCCD.Text = _personDetail.Cccd;
                txtPhone.Text = _personDetail.Phone;

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
        /// B?t/T?t ch? d? ch?nh s?a
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
                if (picAvatar.Image != null)
                {
                    picAvatar.Image.Dispose();
                }
                picAvatar.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void BtnEditSave_Click(object sender, EventArgs e)
        {
            if (btnEditSave.Text == "Sửa")
            {
                SetEditMode(true);
            }
            else
            {
                try
                {
                    _personDetail.Name = txtName.Text;
                    _personDetail.Cccd = txtCCCD.Text;
                    _personDetail.Phone = txtPhone.Text;
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
        }

        #region Hàm h? tr? chuy?n d?i ?nh

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
