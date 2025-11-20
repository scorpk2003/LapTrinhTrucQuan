using QuanLyPhongTro.src.Models;
using QuanLyPhongTro.src.Services1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class FormEditRoom : Form
    {
        private readonly RoomService _roomService;
        private Room _roomToEdit;

        private readonly Dictionary<string, RoomImage> _imageMap = new Dictionary<string, RoomImage>();

        public FormEditRoom(Room roomToEdit)
        {
            InitializeComponent();
            _roomService = new RoomService();
            _roomToEdit = roomToEdit;

            this.Load += FormEditRoom_Load;
            this.btnUpdate.Click += BtnUpdate_Click;
            this.btnAddImage.Click += BtnAddImage_Click;
            this.btnDeleteImage.Click += BtnDeleteImage_Click;
            this.lstImages.SelectedIndexChanged += LstImages_SelectedIndexChanged;
            this.btnCancel.Click += (s, e) => this.Close();
        }

        private void FormEditRoom_Load(object sender, EventArgs e)
        {
            // 1. Tải chi tiết phòng (bao gồm ảnh) từ CSDL
            _roomToEdit = _roomService.GetRoomWithDetails(_roomToEdit.Id);

            if (_roomToEdit == null)
            {
                MessageBox.Show("Lỗi: Không tìm thấy chi tiết phòng.");
                this.Close();
                return;
            }

            // 2. Đổ dữ liệu Text
            txtRoomName.Text = _roomToEdit.Name;
            numPrice.Value = _roomToEdit.Price ?? 0;

            if (cboStatus.Items.Count == 0)
            {
                cboStatus.Items.Add("Trống");
                cboStatus.Items.Add("Đã thuê");
            }
            cboStatus.SelectedItem = _roomToEdit.Status;
            if (cboStatus.SelectedIndex == -1) cboStatus.SelectedItem = "Trống";

            // 3. Đổ dữ liệu ảnh
            LoadImageList();
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

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            _roomToEdit.Name = txtRoomName.Text;
            //_roomToEdit.Address = txtAddress.Text;
            _roomToEdit.Price = numPrice.Value;
            _roomToEdit.Area = numArea.Value;
            _roomToEdit.Status = cboStatus.SelectedItem.ToString();

            bool success = _roomService.UpdateRoom(_roomToEdit);

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

        private void BtnAddImage_Click(object sender, EventArgs e)
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

                    // 2. GỌI SERVICE: Thêm ảnh mới vào CSDL
                    RoomImage newImage = _roomService.AddImageToRoom(_roomToEdit.Id, relativePath);

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

        private void BtnDeleteImage_Click(object sender, EventArgs e)
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

                // 1. GỌI SERVICE: Xóa ảnh
                bool success = _roomService.DeleteRoomImage(imageToDelete.Id);

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
            base.OnFormClosing(e);
        }
    }
}