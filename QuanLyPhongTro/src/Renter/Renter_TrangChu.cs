using QuanLyPhongTro.src.Mediator;
using QuanLyPhongTro.src.Test.Model;
using QuanLyPhongTro.src.Test.Services;
using ScottPlot.Statistics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class Renter_TrangChu : Form
    {
        private readonly Person _currentRenter;
        private readonly RoomService _roomService;
        private readonly PersonService _personService;
        private readonly ContractService _contractService;

        public event EventHandler Logout;

        private Contract _activeContract; // Lưu hợp đồng

        private ucMyRoom _myRoomControl;
        private ucMyBills _myBillsControl;
        private ucMyContract _myContractControl;
        private ucMyReports _myReportsControl;

        public Renter_TrangChu(Person loggedInRenter)
        {
            InitializeComponent();
            _currentRenter = loggedInRenter;
            _roomService = new RoomService();
            _personService = new PersonService();
            _contractService = new ContractService();

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
            lblRenterName.Text = $"Chào mừng, {_currentRenter.Username}";

            _activeContract = _contractService.GetActiveContractByRenter(_currentRenter.Id);

            if (_activeContract == null)
            {
                // CHƯA CÓ PHÒNG -> Hiển thị Giao diện TÌM PHÒNG
                panelMenu.Visible = false;
                panelMainContent.Visible = false;
                panelFindRoom.Visible = true;
                panelFindRoom.Dock = DockStyle.Fill;
                LoadAvailableRooms();
            }
            else
            {
                // ĐÃ CÓ PHÒNG -> Hiển thị Giao diện QUẢN LÝ
                panelMenu.Visible = true;
                panelFindRoom.Visible = false;
                panelMainContent.Visible = true;

                Mediator.Instance.RegisterFactory("UcMyRoom", () => new ucMyRoom());

                BtnHome_Click(null, null);
            }
        }


        #region Giao diện TÌM PHÒNG (Cho người chưa thuê)

        private void LoadAvailableRooms()
        {
            flowPanelRooms.Controls.Clear();
            List<Room> rooms = _roomService.GetAllAvailableRooms();

            if (rooms.Count == 0)
            {
                Label lblEmpty = new Label();
                lblEmpty.Text = "Rất tiếc, hiện tại không có phòng nào còn trống.";
                lblEmpty.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
                lblEmpty.AutoSize = true;
                flowPanelRooms.Controls.Add(lblEmpty);
                return;
            }

            foreach (var room in rooms)
            {
                // 1. Tạo Panel (Card)
                Panel roomPanel = new Panel
                {
                    // --- SỬA KÍCH THƯỚC ---
                    Width = 525,  // Tăng 50%
                    Height = 630, // Tăng 50%
                    // --- HẾT SỬA ---
                    Margin = new Padding(15),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.White
                };

                // 2. Ảnh
                PictureBox pic = new PictureBox
                {
                    Dock = DockStyle.Top,
                    Height = 300, // <-- Tăng chiều cao ảnh
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                string imgPath = room.RoomImages?.FirstOrDefault()?.ImageUrl;
                if (!string.IsNullOrEmpty(imgPath) && File.Exists(imgPath))
                {
                    try { pic.Image = Image.FromFile(imgPath); } catch { }
                }

                // 3. Tên phòng
                Label lblName = new Label
                {
                    Text = room.Name,
                    Font = new Font("Segoe UI", 14F, FontStyle.Bold), // <-- Tăng Font
                    Dock = DockStyle.Top,
                    Padding = new Padding(15, 8, 15, 8), // <-- Tăng Padding
                    AutoSize = true
                };

                // 4. Giá
                Label lblPrice = new Label
                {
                    Text = $"{room.Price:N0} VND / tháng",
                    Font = new Font("Segoe UI", 12F), // <-- Tăng Font
                    Dock = DockStyle.Top,
                    Padding = new Padding(15, 0, 15, 8), // <-- Tăng Padding
                    AutoSize = true,
                    ForeColor = Color.DarkRed
                };

                // 5. Nút Xem chi tiết
                Button btnView = new Button
                {
                    Text = "Xem chi tiết",
                    Tag = room,
                    Dock = DockStyle.Bottom,
                    Height = 60, // <-- Tăng chiều cao
                    Font = new Font("Segoe UI", 12F), // <-- Tăng Font
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.LightGray
                };
                btnView.Click += BtnView_Click;

                // 6. Nút Đặt phòng
                Button btnBook = new Button
                {
                    Text = "Gửi yêu cầu thuê",
                    Tag = room,
                    Dock = DockStyle.Bottom,
                    Height = 65, // <-- Tăng chiều cao
                    Font = new Font("Segoe UI", 13F, FontStyle.Bold), // <-- Tăng Font
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(41, 128, 185), // Blue
                    ForeColor = Color.White
                };
                btnBook.Click += BtnBook_Click;

                // Thêm control vào Panel
                roomPanel.Controls.Add(lblPrice);
                roomPanel.Controls.Add(lblName);
                roomPanel.Controls.Add(pic);
                roomPanel.Controls.Add(btnView);
                roomPanel.Controls.Add(btnBook);

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

            // (Kiểm tra xem đã gửi yêu cầu chưa)
            if (btn.Text == "Đã gửi yêu cầu") return;

            using (FormRequestContract frm = new FormRequestContract(_currentRenter, room))
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


        #region Xử lý Chuyển View (Cho người đã thuê)
        private async Task ShowView<T>(Control control, T uc) where T : Control
        {
            // Ẩn các control khác
            if (_myRoomControl != null && uc != _myRoomControl) _myRoomControl.Visible = false;
            if (_myBillsControl != null && uc != _myBillsControl) _myBillsControl.Visible = false;
            if (_myContractControl != null && uc != _myContractControl) _myContractControl.Visible = false;
            if (_myReportsControl != null && uc != _myReportsControl) _myReportsControl.Visible = false;

            if (control == null) return;

            // Thêm control vào Panel nếu nó chưa có
            if (!panelMainContent.Controls.Contains(control))
            {
                control.Dock = DockStyle.Fill;
                panelMainContent.Controls.Add(control);
            }

            control.BringToFront();
            control.Visible = true;
        }

        private void ShowMyRoomView()
        {
            // Ẩn các control khác (nếu có)
            // if (_myBillsControl != null) _myBillsControl.Visible = false;

            if (_myRoomControl == null)
            {
                _myRoomControl = new ucMyRoom();
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

        #region Sự kiện Menu (Cho người đã thuê)

        private void BtnHome_Click(object sender, EventArgs e)
        {
            Mediator.Instance.PublishForm<Contract>("UcMyRoom", _activeContract, async (control) =>
            {
                _myRoomControl = (ucMyRoom)control;
                await ShowView(control, _myRoomControl);
            });
        }

        private void BtnBills_Click(object sender, EventArgs e)
        {
            Mediator.Instance.PublishForm<Contract>("UcMyBills", _activeContract, async (control) =>
            {
                _myBillsControl = (ucMyBills)control;
                await ShowView(control, _myBillsControl);
            });
        }

        private void BtnContract_Click(object sender, EventArgs e)
        {
            Mediator.Instance.PublishForm<Contract>("UcMyContract", _activeContract, async (control) =>
            {
                _myContractControl = (ucMyContract)control;
                await ShowView(control, _myContractControl);
            });
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            using (var formInfo = new FormInformation(_currentRenter))
            {
                formInfo.StartPosition = FormStartPosition.CenterParent;
                formInfo.ShowDialog(this);
            }
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            Mediator.Instance.PublishForm<Contract>("UcMyReports", _activeContract, async (control) =>
            {
                _myReportsControl = (ucMyReports)control;
                await ShowView(control, _myReportsControl);
            });
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