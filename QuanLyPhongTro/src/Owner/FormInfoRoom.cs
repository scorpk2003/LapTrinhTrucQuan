using QuanLyPhongTro.src.Test.Model;
using QuanLyPhongTro.src.Test.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class FormInfoRoom : Form
    {
        private Room _roomToView; 
        private readonly Person _user;
        private readonly bool _isRenterView;

        private readonly RoomService _roomService;
        private readonly ContractService _contractService;

        public bool DataChanged { get; private set; } = false;

        private List<RoomImage> _roomImages = new List<RoomImage>();
        private int _currentImageIndex = 0;

        public FormInfoRoom(Room room, Person user, bool isRenter = false)
        {
            InitializeComponent();
            _roomToView = room; 
            _user = user;
            _isRenterView = isRenter;

            _roomService = new RoomService();
            _contractService = new ContractService();

            this.Load += FormInfoRoom_Load;
            this.btnEdit.Click += BtnEdit_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.btnClose.Click += (s, e) => this.Close();
            this.btnPrevImage.Click += BtnPrevImage_Click;
            this.btnNextImage.Click += BtnNextImage_Click;
        }

        private void FormInfoRoom_Load(object sender, EventArgs e)
        {
            // Tải lại dữ liệu phòng MỚI NHẤT từ CSDL (bao gồm cả ảnh)
            _roomToView = _roomService.GetRoomWithDetails(_roomToView.Id);
            if (_roomToView == null)
            {
                MessageBox.Show("Phòng này có thể đã bị xóa.");
                this.Close();
                return;
            }


            // Ẩn nút nếu là Renter
            if (_isRenterView)
            {
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnClose.Location = new Point(
                    (this.ClientSize.Width - btnClose.Width) / 2,
                    btnClose.Location.Y);
            }

            // 1. Tải thông tin phòng 
            lblRoomName.Text = _roomToView.Name;
            lblPrice.Text = $"Giá: {_roomToView.Price:N0} VND";
            lblArea.Text = $"Diện tích: {_roomToView.Area} m²";
            lblAddress.Text = $"Địa chỉ: {_roomToView.Address}";
            lblStatus.Text = $"Trạng thái: {_roomToView.Status}";

            // 2. Tải thông tin hợp đồng
            if (_roomToView.Status == "Đã thuê")
            {
                lblStatus.ForeColor = Color.DarkRed;
                grpContractInfo.Visible = true;
                Contract activeContract = _contractService.GetActiveContractByRoom(_roomToView.Id);
                if (activeContract != null)
                {
                    lblRenterName.Text = $"Người thuê: {activeContract.Renter?.Username ?? "N/A"}";
                    lblStartDate.Text = $"Ngày bắt đầu: {activeContract.StartDate?.ToString("dd/MM/yyyy") ?? "N/A"}";
                    lblEndDate.Text = $"Ngày kết thúc: {activeContract.EndDate?.ToString("dd/MM/yyyy") ?? "N/A"}";
                }
            }
            else
            {
                lblStatus.ForeColor = Color.DarkGreen;
                grpContractInfo.Visible = false;
            }

            // 3. Tải hình ảnh (từ đối tượng _roomToView đã được cập nhật)
            LoadRoomImages();
        }

        #region Xử lý Image Carousel

        private void LoadRoomImages()
        {
            if (_roomToView.RoomImages != null && _roomToView.RoomImages.Count > 0)
            {
                _roomImages = _roomToView.RoomImages.ToList();
                _currentImageIndex = 0;
                ShowImageAtIndex(_currentImageIndex);
                btnPrevImage.Enabled = true;
                btnNextImage.Enabled = true;
            }
            else
            {
                // Dọn dẹp ảnh cũ (nếu phòng bị xóa hết ảnh)
                if (picRoomPreview.Image != null) picRoomPreview.Image.Dispose();
                picRoomPreview.Image = null;
                lblImageCounter.Text = "0 / 0";
                btnPrevImage.Enabled = false;
                btnNextImage.Enabled = false;
            }
        }

        private void ShowImageAtIndex(int index)
        {
            if (_roomImages.Count == 0) return;
            RoomImage img = _roomImages[index];
            string fullPath = Path.Combine(Application.StartupPath, img.ImageUrl);
            if (File.Exists(fullPath))
            {
                try
                {
                    if (picRoomPreview.Image != null) picRoomPreview.Image.Dispose();
                    picRoomPreview.Image = Image.FromFile(fullPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi tải ảnh {img.ImageUrl}: {ex.Message}");
                    picRoomPreview.Image = null;
                }
            }
            else { picRoomPreview.Image = null; }
            _currentImageIndex = index;
            lblImageCounter.Text = $"{_currentImageIndex + 1} / {_roomImages.Count}";
        }

        private void BtnPrevImage_Click(object sender, EventArgs e)
        {
            if (_roomImages.Count == 0) return;
            _currentImageIndex--;
            if (_currentImageIndex < 0) { _currentImageIndex = _roomImages.Count - 1; }
            ShowImageAtIndex(_currentImageIndex);
        }

        private void BtnNextImage_Click(object sender, EventArgs e)
        {
            if (_roomImages.Count == 0) return;
            _currentImageIndex++;
            if (_currentImageIndex >= _roomImages.Count) { _currentImageIndex = 0; }
            ShowImageAtIndex(_currentImageIndex);
        }
        #endregion

        #region Xử lý Nút Sửa/Xóa

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            using (FormEditRoom frm = new FormEditRoom(_roomToView))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.DataChanged = true;

                    FormInfoRoom_Load(null, null);
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa (ẩn) phòng '{_roomToView.Name}' không?",
                                          "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                bool success = _roomService.DeleteRoom(_roomToView.Id);
                if (success)
                {
                    MessageBox.Show("Xóa phòng thành công!");
                    this.DataChanged = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Xóa phòng thất bại.");
                }
            }
        }
        #endregion

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (picRoomPreview.Image != null)
            {
                picRoomPreview.Image.Dispose();
            }
            base.OnFormClosing(e);
        }
    }
}