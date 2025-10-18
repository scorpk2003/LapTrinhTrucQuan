using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    // Đổi tên class để phù hợp với chức năng người đã thuê phòng
    public partial class RenterForm : Form
    {
        public RenterForm()
        {
            InitializeComponent();
            Load += Renter_MainMenu_Load;

            // Gán sự kiện click cho các nút mới
            btnInfo.Click += BtnInfo_Click;
            btnViewBill.Click += BtnViewBill_Click;
            btnViewContract.Click += BtnViewContract_Click;
            btnEndOfContract.Click += BtnEndOfContract_Click;
            btnReport.Click += BtnReport_Click;
            btnLogout.Click += BtnLogout_Click;

            // Cập nhật tiêu đề
            lblTitle.Text = "Renter Main Menu";
            lblRenterName.Text = "Welcome, Renter A (Rented)";
        }

        private void Renter_MainMenu_Load(object sender, EventArgs e)
        {
            // Tải nội dung mặc định cho khu vực 'Renter View' (ví dụ: thông tin phòng hiện tại)
            LoadDefaultView();
        }

        private void LoadDefaultView()
        {
            // Khu vực flowPanelRooms (nay là Renter View) sẽ hiển thị thông tin phòng đã thuê
            flowPanelContent.Controls.Clear();

            // Panel trung gian để chứa hai label, đảm bảo layout không bị đè
            Panel infoPanel = new Panel();
            infoPanel.Dock = DockStyle.Fill;
            infoPanel.Padding = new Padding(30, 40, 30, 40);
            infoPanel.BackColor = Color.White;

            Label lblWelcome = new Label();
            lblWelcome.Text = "Chào mừng đến với trang quản lý phòng đã thuê.\nPhòng của bạn: P101";
            lblWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            lblWelcome.Dock = DockStyle.Top;
            lblWelcome.Padding = new Padding(20);
            lblWelcome.Height = 180;
            infoPanel.Controls.Add(lblWelcome);

            Label lblNotice = new Label();
            lblNotice.Text = "Sử dụng menu bên trái để xem Hóa đơn, Hợp đồng hoặc Báo cáo sự cố.";
            lblNotice.Font = new Font("Segoe UI", 14F, FontStyle.Italic);
            lblNotice.TextAlign = ContentAlignment.MiddleCenter;
            lblNotice.Dock = DockStyle.Fill;
            lblNotice.Padding = new Padding(20, 10, 20, 10);
            infoPanel.Controls.Add(lblNotice);

            flowPanelContent.Controls.Add(infoPanel);
        }

        // === Event Handlers cho Menu bên trái ===

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            // Chức năng: Mở form xem/chỉnh sửa thông tin cá nhân
            MessageBox.Show("Mở Form Thông tin cá nhân (Information).", "Chức năng", MessageBoxButtons.OK, MessageBoxIcon.Information);
             using (var formInfo = new FormInformation()) { formInfo.ShowDialog(this); }
        }

        private void BtnViewBill_Click(object sender, EventArgs e)
        {
            // Chức năng: Hiển thị danh sách hóa đơn điện, nước, dịch vụ...
            MessageBox.Show("Mở Form xem Danh sách Hóa đơn (View Bill).", "Chức năng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnViewContract_Click(object sender, EventArgs e)
        {
            // Chức năng: Hiển thị bản sao hợp đồng thuê phòng
            MessageBox.Show("Mở Form xem Hợp đồng (View Contract).", "Chức năng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnEndOfContract_Click(object sender, EventArgs e)
        {
            // Chức năng: Yêu cầu chấm dứt hợp đồng
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn gửi Yêu cầu Chấm dứt Hợp đồng?\nĐiều này có thể yêu cầu thông báo trước.",
                                                 "Xác nhận Chấm dứt Hợp đồng",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Yêu cầu chấm dứt hợp đồng đã được gửi. Vui lòng chờ xác nhận từ Chủ trọ.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // === Event Handlers cho Menu trên cùng ===

        private void BtnReport_Click(object sender, EventArgs e)
        {
            // Chức năng: Báo cáo sự cố/phản hồi (Nút tròn trong hình)
            MessageBox.Show("Mở Form Báo cáo sự cố hoặc Phản hồi (Report).", "Chức năng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?",
                                                 "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                // Logic chuyển về Form Login sẽ được thêm tại đây
            }
        }
    }
}