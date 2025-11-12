using QuanLyPhongTro.Model; // <-- THÊM DÒNG NÀY
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class Renter_TrangChu : Form
    {
        // --- THÊM 2 BIẾN NÀY ---
        private readonly Person _currentRenter; // Lưu thông tin người thuê
        // private readonly PersonService _personService; (Sẽ cần sau)

        // --- SỬA HÀM KHỞI TẠO ---
        public Renter_TrangChu(Person loggedInRenter) // Nhận Person vào
        {
            InitializeComponent();

            // 1. Lưu thông tin người dùng
            _currentRenter = loggedInRenter;
            // _personService = new PersonService();

            // 2. Hiển thị tên
            lblRenterName.Text = $"Welcome, {_currentRenter.Username}";

            // Gán sự kiện
            Load += Renter_TrangChu_Load;
            btnFindRoom.Click += BtnFindRoom_Click;
            btnInfo.Click += btnInfo_Click_1; // Gán cho hàm đã có code
            btnReport.Click += BtnReport_Click;
            btnLogout.Click += BtnLogout_Click;
        }

        private void Renter_TrangChu_Load(object sender, EventArgs e)
        {
            // Tải danh sách phòng (Code demo của bạn)
            // (Sau này bạn sẽ thay bằng hàm gọi Service, ví dụ: _roomService.GetAllAvailableRooms())
            LoadRoomsDemo();
        }

        #region Các hàm tạo UI Demo và sự kiện (Giữ nguyên)

        // (Tất cả các hàm LoadRoomsDemo, BtnView_Click, BtnBook_Click...)
        // (Bạn giữ nguyên các hàm này)

        private void LoadRoomsDemo()
        {
            flowPanelRooms.Controls.Clear();
            for (int i = 1; i <= 3; i++)
            {
                Panel roomPanel = new Panel { /* ... Cài đặt ... */ };
                PictureBox picRoom = new PictureBox { /* ... Cài đặt ... */ };
                Label lblRoomName = new Label { /* ... Cài đặt ... */ Text = "Phòng " + i };
                Label lblStatus = new Label { /* ... Cài đặt ... */ Text = "Tình trạng: Còn trống" };
                FlowLayoutPanel buttonPanel = new FlowLayoutPanel { /* ... Cài đặt ... */ };
                Button btnView = new Button { /* ... Cài đặt ... */ Text = "Xem chi tiết", Tag = i };
                Button btnBook = new Button { /* ... Cài đặt ... */ Text = "Đặt phòng", Tag = i };

                btnView.Click += BtnView_Click;
                btnBook.Click += BtnBook_Click;

                buttonPanel.Controls.Add(btnView);
                buttonPanel.Controls.Add(btnBook);
                roomPanel.Controls.Add(picRoom);
                roomPanel.Controls.Add(lblRoomName);
                roomPanel.Controls.Add(lblStatus);
                roomPanel.Controls.Add(buttonPanel);
                flowPanelRooms.Controls.Add(roomPanel);
            }
        }
        private void BtnView_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int roomId = (int)btn.Tag;
            MessageBox.Show($"Thông tin chi tiết của phòng {roomId} sẽ hiển thị tại đây.", "Chi tiết phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void BtnBook_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int roomId = (int)btn.Tag;
            DialogResult result = MessageBox.Show($"Bạn có chắc muốn đặt phòng {roomId}?", "Xác nhận đặt phòng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                btn.Enabled = false;
                btn.Text = "Đã đặt";
                btn.BackColor = Color.Gray;
                MessageBox.Show($"Phòng {roomId} đã được đặt thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnFindRoom_Click(object sender, EventArgs e)
        {
            Form formFind = new Form { /* ... Cài đặt ... */ };
            Label lbl = new Label { /* ... Cài đặt ... */ Text = "Form tìm kiếm phòng trọ (demo)" };
            formFind.Controls.Add(lbl);
            formFind.ShowDialog();
        }
        private void BtnReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng báo cáo sự cố hoặc phản hồi cho chủ trọ.", "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                // Form AuthForm sẽ tự động mở lại (nếu bạn code AuthForm đúng)
            }
        }

        #endregion

        // --- SỬA HÀM NÀY ---
        // (Hàm BtnInfo_Click rỗng của bạn bị xóa)
        private void btnInfo_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Giờ đây bạn có thể truyền thông tin người dùng
                // (Bạn cũng sẽ cần sửa FormInformation để nhận Person)
                using (var formInfo = new FormInformation(_currentRenter))
                {
                    formInfo.StartPosition = FormStartPosition.CenterParent;
                    formInfo.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                // Nếu chưa sửa FormInformation, hãy dùng tạm MessageBox:
                MessageBox.Show($"Tên đăng nhập: {_currentRenter.Username}\nID: {_currentRenter.Id}\nRole: {_currentRenter.Role}", "Thông tin cá nhân (Demo)");
                // MessageBox.Show("Không thể mở thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}