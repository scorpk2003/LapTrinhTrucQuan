using QuanLyPhongTro.src.Models;
using QuanLyPhongTro.src.Services1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class FormEditRoom : Form
    {
        private readonly ApiService _apiService;
        private Room _roomToEdit;

        private readonly Dictionary<string, RoomImage> _imageMap = new Dictionary<string, RoomImage>();

        public FormEditRoom(Room roomToEdit)
        {
            InitializeComponent();
            _apiService = new ApiService();
            _roomToEdit = roomToEdit;

            this.Load += FormEditRoom_Load;
            this.btnUpdate.Click += BtnUpdate_Click;
            this.btnAddImage.Click += BtnAddImage_Click;
            this.btnDeleteImage.Click += BtnDeleteImage_Click;
            this.btnEditListRoom.Click += BtnEditListRoom_Click;
            this.lstImages.SelectedIndexChanged += LstImages_SelectedIndexChanged;
            this.btnCancel.Click += (s, e) => this.Close();
        }

        private async void FormEditRoom_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Tải chi tiết phòng (bao gồm ảnh) từ CSDL
                _roomToEdit = await _apiService.GetRoomByIdAsync(_roomToEdit.Id);

                if (_roomToEdit == null)
                {
                    MessageBox.Show("Lỗi: Không tìm thấy chi tiết phòng.");
                    this.Close();
                    return;
                }

                // 2. Load danh sách ListRoom
                await LoadListRoomComboBoxAsync();

            // 3. Đổ dữ liệu vào form
            txtRoomName.Text = _roomToEdit.Name;
            numPrice.Value = _roomToEdit.Price ?? 0;
            numArea.Value = _roomToEdit.Area ?? 0; // ✅ THÊM dòng này để load Area

            if (cboStatus.Items.Count == 0)
            {
                cboStatus.Items.Add("Trống");
                cboStatus.Items.Add("Đã thuê");
            }
            cboStatus.SelectedItem = _roomToEdit.Status;
            if (cboStatus.SelectedIndex == -1) cboStatus.SelectedItem = "Trống";

                // 4. Đổ dữ liệu ảnh
                LoadImageList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async Task LoadListRoomComboBoxAsync()
        {
            try
            {
                var listRooms = await _apiService.GetListRoomsByOwnerAsync(_roomToEdit.IdOwner.Value);
            
                cboListRoom.DataSource = null;
                cboListRoom.Items.Clear();
            
                cboListRoom.DataSource = listRooms;
                cboListRoom.DisplayMember = "Name";
                cboListRoom.ValueMember = "Id";

                // Chọn ListRoom hiện tại của phòng
                if (_roomToEdit.IdListRoom.HasValue)
                {
                    for (int i = 0; i < cboListRoom.Items.Count; i++)
                    {
                        if (((ListRoom)cboListRoom.Items[i]).Id == _roomToEdit.IdListRoom.Value)
                        {
                            cboListRoom.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dãy trọ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnEditListRoom_Click(object sender, EventArgs e)
        {
            if (cboListRoom.SelectedItem == null) return;

            var selectedListRoom = (ListRoom)cboListRoom.SelectedItem;
            
            using (var frm = new FormListRoomEditor(selectedListRoom))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    await LoadListRoomComboBoxAsync();
                }
            }
        }

        private void LoadImageList()
        {
            lstImages.Items.Clear();
            _imageMap.Clear();
            if (picPreview.Image != null) picPreview.Image.Dispose();
            picPreview.Image = null;

            if (_roomToEdit.RoomImages != null)
            {
                foreach (var img in _roomToEdit.RoomImages)
                {
                    string displayName = Path.GetFileName(img.ImageUrl);
                    string uniqueDisplayName = displayName;
                    int count = 1;
                    while (_imageMap.ContainsKey(uniqueDisplayName))
                    {
                        uniqueDisplayName = $"{Path.GetFileNameWithoutExtension(displayName)} ({count++}){Path.GetExtension(displayName)}";
                    }

                    _imageMap.Add(uniqueDisplayName, img);
                    lstImages.Items.Add(uniqueDisplayName);
                }
            }
            if (lstImages.Items.Count > 0)
            {
                lstImages.SelectedIndex = 0;
            }
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (cboListRoom.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn dãy trọ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedListRoom = (ListRoom)cboListRoom.SelectedItem;

            _roomToEdit.Name = txtRoomName.Text;
            _roomToEdit.Price = numPrice.Value;
            _roomToEdit.Area = numArea.Value;
            _roomToEdit.Status = cboStatus.SelectedItem.ToString();
            _roomToEdit.IdListRoom = selectedListRoom.Id;

            bool success = await _apiService.UpdateRoomAsync(_roomToEdit);

            if (success)
            {
                MessageBox.Show("Cập nhật thông tin phòng thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.");
            }
        }

        private async void BtnAddImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = openFileDialog.FileName;
                string destinationPath = ""; 

                try
                {
                    // 1. Sao chép ảnh
                    string imageFolder = Path.Combine(Application.StartupPath, "RoomImages");
                    Directory.CreateDirectory(imageFolder);
                    string newFileName = $"{Guid.NewGuid()}{Path.GetExtension(sourcePath)}";
                    destinationPath = Path.Combine(imageFolder, newFileName);
                    File.Copy(sourcePath, destinationPath);

                    string relativePath = Path.Combine("RoomImages", newFileName);

                    // 2. GỌI API: Thêm ảnh mới vào CSDL
                    RoomImage newImage = await _apiService.AddImageToRoomAsync(_roomToEdit.Id, relativePath);

                    if (newImage != null)
                    {
                        // 3. Cập nhật lại UI
                        string displayName = Path.GetFileName(newImage.ImageUrl);
                        _imageMap.Add(displayName, newImage);
                        int newIndex = lstImages.Items.Add(displayName);
                        lstImages.SelectedIndex = newIndex;
                    }
                    else
                    {
                        MessageBox.Show("Thêm ảnh thất bại.");
                        if (File.Exists(destinationPath))
                            File.Delete(destinationPath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm ảnh: {ex.Message}");
                    if (File.Exists(destinationPath))
                        File.Delete(destinationPath);
                }
            }
        }

        private async void BtnDeleteImage_Click(object sender, EventArgs e)
        {
            if (lstImages.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh cần xóa.");
                return;
            }

            string displayName = lstImages.SelectedItem.ToString();

            if (_imageMap.TryGetValue(displayName, out RoomImage imageToDelete))
            {
                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa ảnh '{displayName}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.No) return;

                // 1. GỌI API: Xóa ảnh
                bool success = await _apiService.DeleteRoomImageAsync(imageToDelete.Id);

                if (success)
                {
                    // 2. Cập nhật UI (tải lại danh sách)
                    LoadImageList();
                }
                else
                {
                    MessageBox.Show("Xóa ảnh thất bại.");
                }
            }
        }

        private void LstImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstImages.SelectedItem == null)
            {
                if (picPreview.Image != null) picPreview.Image.Dispose();
                picPreview.Image = null;
                return;
            }

            string displayName = lstImages.SelectedItem.ToString();
            if (_imageMap.TryGetValue(displayName, out RoomImage imageToShow))
            {
                try
                {
                    string fullPath = imageToShow.ImageUrl;

                    if (File.Exists(fullPath))
                    {
                        if (picPreview.Image != null) picPreview.Image.Dispose();
                        picPreview.Image = Image.FromFile(fullPath);
                    }
                    else
                    {
                        if (picPreview.Image != null) picPreview.Image.Dispose();
                        picPreview.Image = null;
                    }
                }
                catch (Exception)
                {
                    if (picPreview.Image != null) picPreview.Image.Dispose();
                    picPreview.Image = null;
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (picPreview.Image != null)
            {
                picPreview.Image.Dispose();
            }
            
            // Dispose ApiService
            _apiService?.Dispose();
            
            base.OnFormClosing(e);
        }
    }
}