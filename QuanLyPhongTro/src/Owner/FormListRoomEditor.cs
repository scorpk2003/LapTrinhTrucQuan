using QuanLyPhongTro.src.Models;
using QuanLyPhongTro.src.Services1;
using System;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class FormListRoomEditor : Form
    {
        private readonly ListRoomService _listRoomService;
        private readonly Guid _ownerId;
        private ListRoom _listRoomToEdit;
        private bool _isEditMode;

        public ListRoom ResultListRoom { get; private set; }

        // Constructor cho ch? ?? t?o m?i
        public FormListRoomEditor(Guid ownerId)
        {
            InitializeComponent();
            _listRoomService = new ListRoomService();
            _ownerId = ownerId;
            _isEditMode = false;

            this.Text = "Tạo dãy trọ mới";
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += (s, e) => this.Close();
        }

        // Constructor cho ch? ?? ch?nh s?a
        public FormListRoomEditor(ListRoom listRoom)
        {
            InitializeComponent();
            _listRoomService = new ListRoomService();
            _listRoomToEdit = listRoom;
            _ownerId = listRoom.IdOwner;
            _isEditMode = true;

            this.Text = "Chỉnh sửa dãy trọ";
            this.Load += FormListRoomEditor_Load;
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += (s, e) => this.Close();
        }

        private void FormListRoomEditor_Load(object sender, EventArgs e)
        {
            if (_isEditMode && _listRoomToEdit != null)
            {
                txtName.Text = _listRoomToEdit.Name;
                txtAddress.Text = _listRoomToEdit.Address;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên dãy trọ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return;
            }

            bool success;

            if (_isEditMode)
            {
                // Ch? ?? ch?nh s?a
                _listRoomToEdit.Name = txtName.Text.Trim();
                _listRoomToEdit.Address = txtAddress.Text.Trim();
                success = _listRoomService.UpdateListRoom(_listRoomToEdit);
                ResultListRoom = _listRoomToEdit;
            }
            else
            {
                // Ch? ?? t?o m?i
                var newListRoom = new ListRoom
                {
                    Id = Guid.NewGuid(),
                    IdOwner = _ownerId,
                    Name = txtName.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Status = "Active"
                };

                success = _listRoomService.CreateListRoom(newListRoom);
                ResultListRoom = newListRoom;
            }

            if (success)
            {
                MessageBox.Show(_isEditMode ? "Cập nhật thông tin dãy trọ thành công!" : "Tạo dãy trọ thành công!", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(_isEditMode ? "Cập nhật thông tin dãy trọ thất bại!" : "Tạo dãy trọ thất bại!", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
