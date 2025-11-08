using QuanLyPhongTro.Model;
using QuanLyPhongTro.Services;
using QuanLyPhongTro.src.Mediator;
using QuanLyPhongTro.src.Messages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class Owner_TrangChu : Form
    {
        private List<Room> _roomList = new List<Room>(); // Danh sách phòng (để lọc/tìm kiếm)
        private readonly Mediator _mediator = Mediator.Instance;
        private readonly RoomService _roomService;

        private readonly Person _currentOwner;

        // Sự kiện để báo cho AuthForm biết
        public event EventHandler Logout;

        public Owner_TrangChu(Person loggedInOwner)
        {
            InitializeComponent();

            _roomService = new RoomService();
            _currentOwner = loggedInOwner;

            lblOwnerName.Text = $"Welcome, {_currentOwner.Username}";

            // Gán sự kiện cho các nút menu
            btnCreate.Click += BtnCreate_Click;
            btnBill.Click += BtnBill_Click;
            btnContract.Click += BtnContract_Click;
            btnReport.Click += BtnReport_Click;
            btnLogout.Click += BtnLogout_Click;

            // Gán sự kiện cho tìm kiếm
            btnSearch.Click += BtnSearch_Click;
            txtSearch.KeyDown += TxtSearch_KeyDown;

            // Đăng ký nghe tin nhắn "Tạo phòng mới"
            _mediator.Register<RoomCreatedMessage>(this.Name, OnRoomCreated);
            this.FormClosed += (s, e) => _mediator.Unregister(this.Name);

            // Tải dữ liệu ban đầu
            SetupMainUI();
            LoadRooms();
        }

        /// <summary>
        /// Tải lại danh sách phòng khi có tin nhắn (từ FormCreateRoom)
        /// </summary>
        private Task OnRoomCreated(RoomCreatedMessage message)
        {
            if (message.NewRoom.IdOwner == _currentOwner.Id)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(LoadRooms));
                }
                else
                {
                    LoadRooms();
                }
            }
            return Task.CompletedTask;
        }

        #region Xử lý Sự kiện Click Menu

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            FormCreateRoom frm = new FormCreateRoom(_currentOwner.Id);
            frm.ShowDialog();
        }

        private void BtnBill_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mở UserControl/Form Quản lí Hóa đơn");
        }
        private void BtnContract_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mở UserControl/Form Quản lí Hợp đồng");
        }
        private void BtnReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mở UserControl/Form Báo cáo Thống kê");
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?",
                                                  "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Báo cho AuthForm
                Logout?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }

        #endregion

        #region Xử lý Phòng (Tải, Hiển thị, Click)

        private void SetupMainUI()
        {
            flowPanelRooms.AutoScroll = true;
            flowPanelRooms.WrapContents = true;
            flowPanelRooms.Padding = new Padding(20);
            flowPanelRooms.BackColor = Color.WhiteSmoke;
        }

        private void LoadRooms()
        {
            _roomList = _roomService.GetAllRoomsByOwner(_currentOwner.Id);
            DisplayRooms(_roomList); // Hiển thị danh sách đầy đủ
        }

        private void DisplayRooms(List<Room> rooms)
        {
            flowPanelRooms.Controls.Clear();
            foreach (var room in rooms)
            {
                AddRoomButtonUI(room);
            }
        }

        /// <summary>
        /// Tạo 1 Button cho phòng (VỚI KÍCH THƯỚC LỚN)
        /// </summary>
        private void AddRoomButtonUI(Room room)
        {
            if (!_roomList.Contains(room))
            {
                _roomList.Add(room);
            }

            Button btn = new Button
            {
                // --- TRẢ VỀ KÍCH THƯỚC CŨ ---
                Size = new Size(450, 494),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                TextAlign = ContentAlignment.TopLeft,
                Padding = new Padding(15),
                Tag = room,

                // --- TRẢ VỀ TEXT ĐẦY ĐỦ ---
                Text = $"Phòng: {room.Name}\n" +
                       $"Giá: {room.Price:N0} VND\n" +
                       $"Diện tích: {room.Area} m²\n" +
                       $"Địa chỉ: {room.Address}\n\n" +
                       $"Trạng thái: {room.Status}"
            };

            if (room.Status.Contains("Đã thuê"))
            {
                btn.BackColor = Color.FromArgb(255, 192, 192);
                btn.ForeColor = Color.DarkRed;
            }
            else
            {
                btn.BackColor = Color.FromArgb(192, 255, 192);
                btn.ForeColor = Color.DarkGreen;
            }

            btn.Click += BtnRoom_Click;
            flowPanelRooms.Controls.Add(btn);
        }

        /// <summary>
        /// (SỰ KIỆN CHÍNH) Mở FormInfoRoom khi click vào phòng
        /// </summary>
        private void BtnRoom_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
            Room roomClicked = (Room)btnClicked.Tag;

            // Mở FormInfoRoom (Form chi tiết)
            using (FormInfoRoom frm = new FormInfoRoom(roomClicked, _currentOwner))
            {
                frm.ShowDialog();

                if (frm.DataChanged)
                {
                    LoadRooms();
                }
            }
        }

        #endregion

        #region Xử lý Tìm kiếm

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSearch_Click(sender, e);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                DisplayRooms(_roomList);
                return;
            }

            // Lọc danh sách phòng (_roomList) dựa trên từ khóa
            var filteredList = _roomList.Where(r =>
                (r.Name != null && r.Name.ToLower().Contains(keyword)) ||
                (r.Address != null && r.Address.ToLower().Contains(keyword)) ||
                (r.Status != null && r.Status.ToLower().Contains(keyword))
            ).ToList();

            // Hiển thị danh sách đã lọc
            DisplayRooms(filteredList);
        }

        #endregion
    }
}