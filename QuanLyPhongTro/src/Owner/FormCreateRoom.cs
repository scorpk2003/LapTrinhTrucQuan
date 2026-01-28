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
    public partial class FormCreateRoom : Form
    {
        private readonly Guid _ownerId;
        private readonly ApiService _apiService;

        private readonly Dictionary<string, string> _imagePaths = new Dictionary<string, string>();
        private List<string> _copiedImagePaths = new List<string>();

        public FormCreateRoom(Guid ownerId)
        {
            InitializeComponent();

            _ownerId = ownerId;
            _apiService = new ApiService();

            this.Load += FormCreateRoom_Load;
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += BtnCancel_Click;
            this.btnAddImage.Click += BtnAddImage_Click;
            this.btnDeleteImage.Click += BtnDeleteImage_Click;
            this.btnNewListRoom.Click += BtnNewListRoom_Click;
            this.lstImages.SelectedIndexChanged += LstImages_SelectedIndexChanged;
        }

        private async void FormCreateRoom_Load(object sender, EventArgs e)
        {
            await LoadListRoomComboBoxAsync();
        }

        private async Task LoadListRoomComboBoxAsync()
        {
            try
            {
                var listRooms = await _apiService.GetListRoomsByOwnerAsync(_ownerId);
            
                cboListRoom.DataSource = null;
                cboListRoom.Items.Clear();
            
                if (listRooms.Count == 0)
                {
                    // Tạo ListRoom mặc định nếu chưa có
                    var defaultListRoom = new ListRoom
                    {
                        Id = Guid.NewGuid(),
                        IdOwner = _ownerId,
                        Name = "Dãy trọ mặc định",
                        Address = "Chưa cập nhật",
                        Status = "Active"
                    };
                    
                    if (await _apiService.CreateListRoomAsync(defaultListRoom))
                    {
                        listRooms.Add(defaultListRoom);
                    }
                }

                cboListRoom.DataSource = listRooms;
                cboListRoom.DisplayMember = "Name";
                cboListRoom.ValueMember = "Id";

                if (cboListRoom.Items.Count > 0)
                {
                    cboListRoom.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dãy trọ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnNewListRoom_Click(object sender, EventArgs e)
        {
            using (var frm = new FormListRoomEditor(_ownerId))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    await LoadListRoomComboBoxAsync();
                    
                    // Chọn ListRoom mới tạo
                    if (frm.ResultListRoom != null)
                    {
                        for (int i = 0; i < cboListRoom.Items.Count; i++)
                        {
                            if (((ListRoom)cboListRoom.Items[i]).Id == frm.ResultListRoom.Id)
                            {
                                cboListRoom.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                int lastAddedIndex = -1;
                foreach (string fullPath in openFileDialog.FileNames)
                {
                    string fileName = Path.GetFileName(fullPath);
                    if (!_imagePaths.ContainsKey(fileName))
                    {
                        _imagePaths.Add(fileName, fullPath);
                        lastAddedIndex = lstImages.Items.Add(fileName);
                    }
                }
                if (lastAddedIndex != -1)
                {
                    lstImages.SelectedIndex = lastAddedIndex;
                }
            }
        }

        private void BtnDeleteImage_Click(object sender, EventArgs e)
        {
            if (lstImages.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh cần xóa.", "Chưa chọn ảnh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string selectedFileName = lstImages.SelectedItem.ToString();
            _imagePaths.Remove(selectedFileName);
            lstImages.Items.Remove(selectedFileName);
            if (picPreview.Image != null)
            {
                picPreview.Image.Dispose();
                picPreview.Image = null;
            }
            if (lstImages.Items.Count > 0)
            {
                lstImages.SelectedIndex = 0;
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
            string selectedFileName = lstImages.SelectedItem.ToString();
            if (_imagePaths.TryGetValue(selectedFileName, out string fullPath))
            {
                try
                {
                    if (picPreview.Image != null) picPreview.Image.Dispose();
                    picPreview.Image = Image.FromFile(fullPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể tải ảnh: {ex.Message}");
                    picPreview.Image = null;
                }
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoomName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRoomName.Focus();
                return;
            }

            if (cboListRoom.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn dãy trọ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboListRoom.Focus();
                return;
            }

            if (numPrice.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập giá thuê hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPrice.Focus();
                return;
            }

            // Lấy ListRoom được chọn
            var selectedListRoom = (ListRoom)cboListRoom.SelectedItem;

            // 1. Tạo đối tượng Room
            Room newRoom = new Room
            {
                Name = txtRoomName.Text,
                Price = numPrice.Value,
                Area = numArea.Value, 
                Status = "Trống",
                IdOwner = _ownerId,
                IdListRoom = selectedListRoom.Id
            };

            // 2. Xử lý sao chép ảnh
            List<string> relativeImagePaths = new List<string>();
            _copiedImagePaths.Clear();

            try
            {
                string imageFolder = Path.Combine(Application.StartupPath, "RoomImages");
                Directory.CreateDirectory(imageFolder);

                foreach (string sourcePath in _imagePaths.Values)
                {
                    string newFileName = $"{Guid.NewGuid()}{Path.GetExtension(sourcePath)}";
                    string destinationPath = Path.Combine(imageFolder, newFileName);

                    File.Copy(sourcePath, destinationPath);
                    _copiedImagePaths.Add(destinationPath);
                    relativeImagePaths.Add(Path.Combine("RoomImages", newFileName));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CleanupCopiedImages();
                return;
            }

            // 3. Gọi API để lưu vào CSDL
            bool success = await _apiService.CreateRoomAsync(newRoom, relativeImagePaths);

            if (success)
            {
                MessageBox.Show("Tạo phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tạo phòng thất bại! Vui lòng kiểm tra lại thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CleanupCopiedImages();
                return;
            }
        }

        private void CleanupCopiedImages()
        {
            if (_copiedImagePaths == null || _copiedImagePaths.Count == 0)
            {
                return;
            }
            foreach (string path in _copiedImagePaths)
            {
                try
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi xóa ảnh (dọn dẹp): {ex.Message}");
                }
            }
            _copiedImagePaths.Clear();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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