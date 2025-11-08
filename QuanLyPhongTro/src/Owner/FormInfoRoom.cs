using QuanLyPhongTro.Model;
using QuanLyPhongTro.Services;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class FormInfoRoom : Form
    {
        private readonly Room _roomToView; // Phòng được truyền vào
        private readonly Person _currentOwner; // Chủ trọ

        private readonly RoomService _roomService;
        private readonly ContractService _contractService;

        public bool DataChanged { get; private set; } = false;

        public FormInfoRoom(Room room, Person owner)
        {
            InitializeComponent();
            _roomToView = room;
            _currentOwner = owner;
            _roomService = new RoomService();
            _contractService = new ContractService();

            // Gán sự kiện
            this.Load += FormInfoRoom_Load;
            this.btnEdit.Click += BtnEdit_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.btnClose.Click += (s, e) => this.Close();
        }

        // --- HÀM NÀY ĐÃ ĐƯỢC SỬA LẠI HOÀN TOÀN ---
        private void FormInfoRoom_Load(object sender, EventArgs e)
        {
            // 1. Tải thông tin phòng (luôn luôn)
            lblRoomName.Text = _roomToView.Name;
            lblPrice.Text = $"Giá: {_roomToView.Price:N0} VND";
            lblArea.Text = $"Diện tích: {_roomToView.Area} m²";
            lblAddress.Text = $"Địa chỉ: {_roomToView.Address}";

            // 2. Tải ảnh (lấy ảnh đầu tiên nếu có)
            var roomWithImages = _roomService.GetRoomWithDetails(_roomToView.Id);
            if (roomWithImages != null && roomWithImages.RoomImages.Count > 0)
            {
                string firstImage = roomWithImages.RoomImages.First().ImageUrl;
                string fullPath = Path.Combine(Application.StartupPath, firstImage);
                if (File.Exists(fullPath))
                {
                    // Dùng try-catch để tránh lỗi file đang được sử dụng
                    try
                    {
                        picRoom.Image = Image.FromFile(fullPath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi tải ảnh: {ex.Message}");
                        picRoom.Image = null; // Đặt là null nếu lỗi
                    }
                }
            }

            // 3. SỬA LỖI TRẠNG THÁI VÀ HỢP ĐỒNG
            // Lấy trạng thái trực tiếp từ phòng
            lblStatus.Text = $"Trạng thái: {_roomToView.Status}";

            if (_roomToView.Status == "Đã thuê")
            {
                // Nếu Đã thuê -> Hiển thị màu đỏ VÀ tìm hợp đồng
                lblStatus.ForeColor = Color.DarkRed;
                grpContractInfo.Visible = true;

                Contract activeContract = _contractService.GetActiveContractByRoom(_roomToView.Id);

                if (activeContract != null)
                {
                    // SỬA LỖI: Thêm "?." (toán tử an toàn)
                    // để tránh lỗi nếu Renter hoặc Date bị null
                    lblRenterName.Text = $"Người thuê: {activeContract.Renter?.Username ?? "N/A"}";
                    lblStartDate.Text = $"Ngày bắt đầu: {activeContract.StartDate?.ToString("dd/MM/yyyy") ?? "N/A"}";
                    lblEndDate.Text = $"Ngày kết thúc: {activeContract.EndDate?.ToString("dd/MM/yyyy") ?? "N/A"}";
                }
                else
                {
                    // Trường hợp CSDL lỗi: Status là "Đã thuê" nhưng không có HĐ
                    lblRenterName.Text = "Người thuê: (Lỗi dữ liệu HĐ)";
                    lblStartDate.Text = "Ngày bắt đầu: N/A";
                    lblEndDate.Text = "Ngày kết thúc: N/A";
                }
            }
            else
            {
                // Nếu "Còn trống" hoặc "Đang sửa chữa"
                lblStatus.ForeColor = Color.DarkGreen;
                grpContractInfo.Visible = false; // Ẩn group hợp đồng
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            // Mở Form Sửa (FormEditRoom)
            // (Đảm bảo FormEditRoom của bạn đã hoàn chỉnh)
            using (FormEditRoom frm = new FormEditRoom(_roomToView))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.DataChanged = true;
                    // Tải lại thông tin (đã được cập nhật) lên form này
                    FormInfoRoom_Load(null, null);
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa (ẩn) phòng '{_roomToView.Name}' không?",
                                          "Xác nhận xóa",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);
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

        // Giải phóng ảnh khi đóng
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (picRoom.Image != null)
            {
                picRoom.Image.Dispose();
            }
            base.OnFormClosing(e);
        }
    }
}