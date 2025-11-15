using QuanLyPhongTro.src.Messages;
using QuanLyPhongTro.Model;
using QuanLyPhongTro.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class FormCreateRoom : Form
    {
        private readonly Guid _ownerId;
        private readonly RoomService _roomService;
        //private readonly Mediator _mediator;

        // Dùng Dictionary để lưu tên file (hiển thị) và đường dẫn gốc (để copy)
        private readonly Dictionary<string, string> _imagePaths = new Dictionary<string, string>();
        private List<string> _copiedImagePaths = new List<string>();
        public FormCreateRoom(Guid ownerId)
        {
            InitializeComponent();

            _ownerId = ownerId;
            _roomService = new RoomService();
            //_mediator = Mediator.Instance;

            // Gán sự kiện cho các nút
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += BtnCancel_Click;
            this.btnAddImage.Click += BtnAddImage_Click;
            this.btnDeleteImage.Click += BtnDeleteImage_Click; // Nút xóa ảnh
            this.lstImages.SelectedIndexChanged += LstImages_SelectedIndexChanged;
        }

        /// <summary>
        /// Mở file dialog, thêm ảnh vào danh sách và tự động chọn ảnh cuối
        /// </summary>
        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                int lastAddedIndex = -1; // Lưu chỉ số của ảnh cuối cùng được thêm

                foreach (string fullPath in openFileDialog.FileNames)
                {
                    string fileName = Path.GetFileName(fullPath);
                    if (!_imagePaths.ContainsKey(fileName))
                    {
                        _imagePaths.Add(fileName, fullPath);
                        lastAddedIndex = lstImages.Items.Add(fileName); // Thêm và lấy chỉ số
                    }
                }

                // Tự động chọn ảnh cuối cùng vừa thêm
                if (lastAddedIndex != -1)
                {
                    lstImages.SelectedIndex = lastAddedIndex;
                }
            }
        }

        /// <summary>
        /// Xóa ảnh được chọn khỏi danh sách
        /// </summary>
        private void BtnDeleteImage_Click(object sender, EventArgs e)
        {
            if (lstImages.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh cần xóa từ danh sách.", "Chưa chọn ảnh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string selectedFileName = lstImages.SelectedItem.ToString();

            // Xóa khỏi data
            _imagePaths.Remove(selectedFileName);
            lstImages.Items.Remove(selectedFileName);

            // Xóa ảnh xem trước
            if (picPreview.Image != null)
            {
                picPreview.Image.Dispose();
                picPreview.Image = null;
            }

            // Tự động chọn ảnh đầu tiên nếu vẫn còn
            if (lstImages.Items.Count > 0)
            {
                lstImages.SelectedIndex = 0;
            }
        }


        /// <summary>
        /// Hiển thị ảnh xem trước khi người dùng click vào ListBox
        /// </summary>
        private void LstImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstImages.SelectedItem == null)
            {
                // Nếu xóa hết ảnh, xóa luôn picPreview
                if (picPreview.Image != null) picPreview.Image.Dispose();
                picPreview.Image = null;
                return;
            }

            string selectedFileName = lstImages.SelectedItem.ToString();
            if (_imagePaths.TryGetValue(selectedFileName, out string fullPath))
            {
                try
                {
                    // Giải phóng ảnh cũ
                    if (picPreview.Image != null) picPreview.Image.Dispose();
                    // Tải ảnh mới
                    picPreview.Image = Image.FromFile(fullPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể tải ảnh: {ex.Message}");
                    picPreview.Image = null;
                }
            }
        }

        /// <summary>
        /// Lưu phòng mới (bao gồm cả sao chép ảnh)
        /// </summary>
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            // --- Kiểm tra dữ liệu đầu vào ---
            if (string.IsNullOrWhiteSpace(txtRoomName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRoomName.Focus();
                return;
            }
            if (numPrice.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập giá thuê hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPrice.Focus();
                return;
            }

            // 1. Tạo đối tượng Room
            Room newRoom = new Room
            {
                Name = txtRoomName.Text,
                Address = txtAddress.Text,
                Price = numPrice.Value,
                Area = numArea.Value,
                Status = "Trống",
                IdOwner = _ownerId
            };

            // 2. Xử lý sao chép ảnh và lấy đường dẫn tương đối
            List<string> relativeImagePaths = new List<string>();
            try
            {
                // Thư mục lưu ảnh (ví dụ: /bin/Debug/RoomImages)
                string imageFolder = Path.Combine(Application.StartupPath, "RoomImages");
                Directory.CreateDirectory(imageFolder); // Tạo nếu chưa có

                foreach (string sourcePath in _imagePaths.Values)
                {
                    // Tạo tên file mới, duy nhất
                    string newFileName = $"{Guid.NewGuid()}{Path.GetExtension(sourcePath)}";
                    string destinationPath = Path.Combine(imageFolder, newFileName);

                    File.Copy(sourcePath, destinationPath);

                    // Lưu đường dẫn tương đối để lưu vào CSDL
                    relativeImagePaths.Add(Path.Combine("RoomImages", newFileName));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CleanupCopiedImages();
                return;
            }

            // 3. Gọi Service để lưu vào CSDL
            bool success = _roomService.CreateRoom(newRoom, relativeImagePaths);

            if (success)
            {
                // 4. Báo cho Owner_TrangChu biết qua Mediator
                //await _mediator.Publish(new RoomCreatedMessage(newRoom));
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

        /// <summary>
        /// (Hàm trợ giúp) Dọn dẹp các file ảnh đã được copy
        /// (Được gọi khi việc lưu Room vào CSDL thất bại)
        /// </summary>
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
            this.Close();
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