using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class Owner_TrangChu : Form
    {
        private List<InfoRoom> roomList = new List<InfoRoom>();

        public Owner_TrangChu()
        {
            InitializeComponent();
            btnCreate.Click += BtnCreate_Click;
            SetupMainUI();
        }

        private void SetupMainUI()
        {
            // Cấu hình lại FlowLayoutPanel nếu muốn
            flowPanelRooms.AutoScroll = true;
            flowPanelRooms.WrapContents = true;
            flowPanelRooms.Padding = new Padding(20);
            flowPanelRooms.BackColor = Color.WhiteSmoke;
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            // Giả định FormCreateRoom đã được khai báo ở đâu đó
            // Ví dụ:
            FormCreateRoom frm = new FormCreateRoom();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                InfoRoom newRoom = frm.GetRoom();
                roomList.Add(newRoom);
                AddRoomButton(newRoom);
            }

            // Tạm thời tạo phòng demo để kiểm tra kích thước
            //InfoRoom newRoom = new InfoRoom
            //{
            //    Name = $"Phòng {roomList.Count + 1}",
            //    Area = 25,
            //    Price = 3000000m,
            //    Status = (roomList.Count % 2 == 0) ? "Đã thuê" : "Còn trống"
            //};
            //roomList.Add(newRoom);
            //AddRoomButton(newRoom);
        }

        private void AddRoomButton(InfoRoom room)
        {
            // SỬA ĐỔI: Thay đổi kích thước nút theo yêu cầu (450, 494)
            Button btn = new Button
            {
                Size = new Size(450, 494), // Kích thước mới
                BackColor = Color.FromArgb(240, 248, 255),
                Font = new Font("Segoe UI", 14, FontStyle.Bold), // Tăng kích thước font cho phù hợp
                TextAlign = ContentAlignment.MiddleCenter,
                Tag = room,
                Text = $"Phòng: {room.Name}\n\nDiện tích: {room.Area} m²\n\nGiá: {room.Price:N0} VND\n\nTrạng thái: {room.Status}"
            };

            // Thay đổi màu nền tùy theo trạng thái
            if (room.Status.Contains("Đã thuê"))
            {
                btn.BackColor = Color.FromArgb(255, 192, 192); // Màu đỏ nhạt
                btn.ForeColor = Color.DarkRed;
            }
            else
            {
                btn.BackColor = Color.FromArgb(192, 255, 192); // Màu xanh nhạt
                btn.ForeColor = Color.DarkGreen;
            }

            btn.Click += BtnRoom_Click;
            flowPanelRooms.Controls.Add(btn);
        }

        private void BtnRoom_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            InfoRoom room = (InfoRoom)btn.Tag;

            MessageBox.Show($"Phòng: {room.Name}\n" +
                            $"Diện tích: {room.Area} m²\n" +
                            $"Giá thuê: {room.Price:N0} VND\n" +
                            $"Trạng thái: {room.Status}",
                            "Chi tiết phòng",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
    }
}
