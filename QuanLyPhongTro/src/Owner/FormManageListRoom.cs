using QuanLyPhongTro.src.Models;
using QuanLyPhongTro.src.Services1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class FormManageListRoom : Form
    {
        private readonly Guid _ownerId;
        private readonly ListRoomService _listRoomService;
        private List<ListRoom> _allListRooms;

        public FormManageListRoom(Guid ownerId)
        {
            InitializeComponent();
            _ownerId = ownerId;
            _listRoomService = new ListRoomService();

            this.Load += FormManageListRoom_Load;
            this.btnCreate.Click += BtnCreate_Click;
            this.btnEdit.Click += BtnEdit_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.btnClose.Click += (s, e) => this.Close();
            this.dgvListRooms.SelectionChanged += DgvListRooms_SelectionChanged;
        }

        private void FormManageListRoom_Load(object sender, EventArgs e)
        {
            LoadListRooms();
        }

        private void LoadListRooms()
        {
            _allListRooms = _listRoomService.GetListRoomsByOwner(_ownerId);

            dgvListRooms.DataSource = null;
            dgvListRooms.Rows.Clear();
            dgvListRooms.Columns.Clear();

            dgvListRooms.AutoGenerateColumns = false;
            dgvListRooms.AllowUserToAddRows = false;
            dgvListRooms.ReadOnly = true;
            dgvListRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListRooms.MultiSelect = false;

            // Thêm cột
            dgvListRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Visible = false
            });

            dgvListRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Tên dãy trọ",
                DataPropertyName = "Name",
                Width = 200
            });

            dgvListRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Address",
                HeaderText = "Địa chỉ",
                DataPropertyName = "Address",
                Width = 350,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvListRooms.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Trạng thái",
                DataPropertyName = "Status",
                Width = 100
            });

            dgvListRooms.DataSource = _allListRooms;

            UpdateButtonStates();
        }

        private void DgvListRooms_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = dgvListRooms.SelectedRows.Count > 0;
            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            using (var frm = new FormListRoomEditor(_ownerId))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadListRooms();
                    MessageBox.Show("Tạo dãy trọ mới thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvListRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dãy trọ cần sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedListRoom = (ListRoom)dgvListRooms.SelectedRows[0].DataBoundItem;

            using (var frm = new FormListRoomEditor(selectedListRoom))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadListRooms();
                    MessageBox.Show("Cập nhật dãy trọ thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvListRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dãy trọ cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedListRoom = (ListRoom)dgvListRooms.SelectedRows[0].DataBoundItem;

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa dãy trọ '{selectedListRoom.Name}'?\n\n" +
                "Lưu ý: Các phòng thuộc dãy trọ này sẽ không bị xóa nhưng cần được gán lại vào dãy trọ khác.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool success = _listRoomService.DeleteListRoom(selectedListRoom.Id);

                if (success)
                {
                    LoadListRooms();
                    MessageBox.Show("Xóa dãy trọ thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa dãy trọ thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
