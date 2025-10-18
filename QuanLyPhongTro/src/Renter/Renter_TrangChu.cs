using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class Renter_TrangChu : Form
    {
        public Renter_TrangChu()
        {
            InitializeComponent();
            Load += Renter_TrangChu_Load;

            // Gán sự kiện click cho các nút
            btnFindRoom.Click += BtnFindRoom_Click;
            btnInfo.Click += BtnInfo_Click;
            btnReport.Click += BtnReport_Click;
            btnLogout.Click += BtnLogout_Click;
        }

        private void Renter_TrangChu_Load(object sender, EventArgs e)
        {
            // Có thể load danh sách phòng từ database ở đây
            // Dưới đây là ví dụ hiển thị 3 phòng mẫu
            LoadRoomsDemo();
        }

        private void LoadRoomsDemo()
        {
            flowPanelRooms.Controls.Clear();

            for (int i = 1; i <= 3; i++)
            {
                // === PANEL PHÒNG ===
                Panel roomPanel = new Panel();
                roomPanel.BorderStyle = BorderStyle.FixedSingle;
                roomPanel.Width = 350;
                roomPanel.Height = 450;
                roomPanel.Margin = new Padding(20);
                roomPanel.BackColor = Color.White;

                // === ẢNH PHÒNG ===
                PictureBox picRoom = new PictureBox();
                picRoom.Dock = DockStyle.Top;
                picRoom.Height = 180;
                picRoom.SizeMode = PictureBoxSizeMode.StretchImage;
                picRoom.BackColor = Color.LightGray;
                roomPanel.Controls.Add(picRoom);

                // === LABEL TÊN PHÒNG ===
                Label lblRoomName = new Label();
                lblRoomName.Text = "Phòng " + i;
                lblRoomName.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
                lblRoomName.Dock = DockStyle.Top;
                lblRoomName.TextAlign = ContentAlignment.MiddleCenter;
                lblRoomName.Height = 55;
                roomPanel.Controls.Add(lblRoomName);

                // === LABEL TRẠNG THÁI ===
                Label lblStatus = new Label();
                lblStatus.Text = "Tình trạng: Còn trống";
                lblStatus.Font = new Font("Segoe UI", 10.5F);
                lblStatus.ForeColor = Color.ForestGreen;
                lblStatus.Dock = DockStyle.Top;
                lblStatus.TextAlign = ContentAlignment.MiddleCenter;
                lblStatus.Height = 50;
                roomPanel.Controls.Add(lblStatus);

                // === PANEL CHỨA NÚT ===
                FlowLayoutPanel buttonPanel = new FlowLayoutPanel();
                buttonPanel.Dock = DockStyle.Bottom;
                buttonPanel.FlowDirection = FlowDirection.TopDown; // ✅ Chuyển thành dọc (2 hàng)
                buttonPanel.Height = 130;                          // ✅ Tăng chiều cao để chứa 2 nút
                buttonPanel.Padding = new Padding(10);
                buttonPanel.WrapContents = false;
                buttonPanel.AutoScroll = false;
                roomPanel.Controls.Add(buttonPanel);

                // --- Nút xem chi tiết ---
                Button btnView = new Button();
                btnView.Text = "Xem chi tiết";
                btnView.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                btnView.Size = new Size(220, 50);
                btnView.Tag = i;
                btnView.BackColor = Color.FromArgb(52, 152, 219);
                btnView.ForeColor = Color.White;
                btnView.FlatStyle = FlatStyle.Flat;
                btnView.FlatAppearance.BorderSize = 0;
                btnView.Click += BtnView_Click;
                buttonPanel.Controls.Add(btnView);

                // --- Nút đặt phòng ---
                Button btnBook = new Button();
                btnBook.Text = "Đặt phòng";
                btnBook.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                btnBook.Size = new Size(220, 50);
                btnBook.Tag = i;
                btnBook.BackColor = Color.FromArgb(46, 204, 113);
                btnBook.ForeColor = Color.White;
                btnBook.FlatStyle = FlatStyle.Flat;
                btnBook.FlatAppearance.BorderSize = 0;
                btnBook.Click += BtnBook_Click;
                buttonPanel.Controls.Add(btnBook);

                // === Thêm vào flow chính ===
                flowPanelRooms.Controls.Add(roomPanel);
            }
        }






        // Xem chi tiết phòng
        private void BtnView_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int roomId = (int)btn.Tag;
            MessageBox.Show($"Thông tin chi tiết của phòng {roomId} sẽ hiển thị tại đây.",
                            "Chi tiết phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Chức năng đặt phòng
        private void BtnBook_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int roomId = (int)btn.Tag;

            DialogResult result = MessageBox.Show($"Bạn có chắc muốn đặt phòng {roomId}?",
                                                  "Xác nhận đặt phòng",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Giả lập cập nhật trạng thái phòng
                btn.Enabled = false;
                btn.Text = "Đã đặt";
                btn.BackColor = Color.Gray;
                MessageBox.Show($"Phòng {roomId} đã được đặt thành công!",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void BtnFindRoom_Click(object sender, EventArgs e)
        {
            // Khi bấm “Find Room” thì mở form tìm kiếm
            Form formFind = new Form();
            formFind.Text = "Tìm Phòng Trọ";
            formFind.Size = new Size(600, 400);
            formFind.StartPosition = FormStartPosition.CenterParent;

            Label lbl = new Label();
            lbl.Text = "Form tìm kiếm phòng trọ (demo)";
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Font = new Font("Segoe UI", 14F, FontStyle.Italic);

            formFind.Controls.Add(lbl);
            formFind.ShowDialog();
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng báo cáo sự cố hoặc phản hồi cho chủ trọ.",
                            "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?",
                                                  "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnInfo_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (var formInfo = new FormInformation())
                {
                    formInfo.StartPosition = FormStartPosition.CenterParent;
                    formInfo.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
