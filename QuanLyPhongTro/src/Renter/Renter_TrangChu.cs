using QuanLyPhongTro.src.Model;
using QuanLyPhongTro.src.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class Renter_TrangChu : Form
    {
        private readonly Person _currentRenter;
        private readonly RoomService _roomService;
        private readonly PersonService _personService;
        private readonly ContractService _contractService; // <-- THÊM MỚI

        public event EventHandler Logout;

        // --- CÁC BIẾN MỚI ---
        private Contract _activeContract; // Lưu hợp đồng

        // Các UserControl
        private ucMyRoom _myRoomControl;
        // private ucMyBills _myBillsControl; (Sẽ làm sau)
        // private ucMyReports _myReportsControl; (Sẽ làm sau)

        public Renter_TrangChu(Person loggedInRenter)
        {
            InitializeComponent();
            _currentRenter = loggedInRenter;
            _roomService = new RoomService();
            _personService = new PersonService();
            _contractService = new ContractService(); // <-- KHỞI TẠO

            this.Load += Renter_TrangChu_Load;

            // Gán sự kiện click
            btnHome.Click += BtnHome_Click;
            btnBills.Click += BtnBills_Click;
            btnContract.Click += BtnContract_Click;
            btnReport.Click += BtnReport_Click;
            btnProfile.Click += BtnInfo_Click;
            btnLogout.Click += BtnLogout_Click;
        }

        private void Renter_TrangChu_Load(object sender, EventArgs e)
        {
            lblRenterName.Text = $"Welcome, {_currentRenter.Username}";

            // --- LOGIC CỐT LÕI ---
            _activeContract = _contractService.GetActiveContractByRenter(_currentRenter.Id);

            if (_activeContract == null)
            {
                // CHƯA CÓ PHÒNG -> Hiển thị Giao diện TÌM PHÒNG
                panelMenu.Visible = false; // Ẩn menu chính
                panelMainContent.Visible = false; // Ẩn dashboard

                panelFindRoom.Visible = true; // Hiện panel tìm
                panelFindRoom.Dock = DockStyle.Fill; // Lấp đầy
                LoadAvailableRooms();
            }
            else
            {
                // ĐÃ CÓ PHÒNG -> Hiển thị Giao diện QUẢN LÝ
                panelMenu.Visible = true; // Hiện menu chính
                panelFindRoom.Visible = false; // Ẩn panel tìm
                panelMainContent.Visible = true; // Hiện dashboard

                ShowMyRoomView(); // Hiển thị Trang chủ (ucMyRoom)
            }
        }

        #region Xử lý Chuyển View (Cho người đã thuê)

        private void ShowMyRoomView()
        {
            // Ẩn các control khác (nếu có)
            // if (_myBillsControl != null) _myBillsControl.Visible = false;

            if (_myRoomControl == null)
            {
                _myRoomControl = new ucMyRoom(_activeContract); // Truyền HĐ vào
                _myRoomControl.Dock = DockStyle.Fill;
                panelMainContent.Controls.Add(_myRoomControl);
            }
            _myRoomControl.BringToFront();
            _myRoomControl.Visible = true;
        }

        private void ShowMyBillsView()
        {
            // (Sẽ code sau)
            if (_myRoomControl != null) _myRoomControl.Visible = false;
            MessageBox.Show("Mở UserControl Hóa đơn (Mục #2)");
        }

        private void ShowMyContractView()
        {
            // (Sẽ code sau)
            if (_myRoomControl != null) _myRoomControl.Visible = false;
            MessageBox.Show("Mở UserControl Hợp đồng (Mục #3)");
        }

        private void ShowMyReportsView()
        {
            // (Sẽ code sau)
            if (_myRoomControl != null) _myRoomControl.Visible = false;
            MessageBox.Show("Mở UserControl Gửi Sự cố (Mục #4)");
        }

        #endregion

        #region Giao diện TÌM PHÒNG (Cho người chưa thuê)

        private void LoadAvailableRooms()
        {
            // Dọn dẹp
            flowPanelRooms.Controls.Clear();
            List<Room> rooms = _roomService.GetAllAvailableRooms();

            foreach (var room in rooms)
            {
                // (Code tạo Card phòng như cũ)
                Panel roomPanel = new Panel { /* ... */ };
                // ... (PictureBox, Labels...)

                Button btnView = new Button();
                btnView.Text = "Xem chi tiết";
                btnView.Tag = room;
                btnView.Click += BtnView_Click;
                // ...

                Button btnBook = new Button();
                btnBook.Text = "Gửi yêu cầu thuê";
                btnBook.Tag = room;
                btnBook.Click += BtnBook_Click;
                // ...

                flowPanelRooms.Controls.Add(roomPanel);
            }
        }

        // Xem chi tiết phòng
        private void BtnView_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Room room = (Room)btn.Tag;
            using (FormInfoRoom frm = new FormInfoRoom(room, _currentRenter, true))
            {
                frm.ShowDialog(this);
            }
        }

        // Chức năng đặt phòng
        private void BtnBook_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Room room = (Room)btn.Tag;

            using (FormRequestContract frm = new FormRequestContract(_currentRenter.Id, room))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    btn.Enabled = false;
                    btn.Text = "Đã gửi yêu cầu";
                    btn.BackColor = Color.Gray;
                }
            }
        }

        #endregion

        #region Sự kiện Menu (Cho người đã thuê)

        private void BtnHome_Click(object sender, EventArgs e)
        {
            ShowMyRoomView();
        }

        private void BtnBills_Click(object sender, EventArgs e)
        {
            ShowMyBillsView();
        }

        private void BtnContract_Click(object sender, EventArgs e)
        {
            ShowMyContractView();
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            // (Mục #8)
            using (var formInfo = new FormInformation(_currentRenter))
            {
                formInfo.StartPosition = FormStartPosition.CenterParent;
                formInfo.ShowDialog(this);
            }
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            // (Mục #4)
            ShowMyReportsView();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?",
                                                  "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Logout?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }

        #endregion
    }
}