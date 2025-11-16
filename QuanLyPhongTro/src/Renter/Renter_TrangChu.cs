using QuanLyPhongTro.src.Test.Models;
using QuanLyPhongTro.Services;
using QuanLyPhongTro.src.Test.Mediator;
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

        private List<Room> _allAvailableRooms;
        private const string PlaceholderText = "Nhập tên, địa chỉ...";
        private Panel _selectedRoomCard = null;

        public event EventHandler Logout;

        private Contract _activeContract;
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

                InitializeFilterLogic();
                this.ActiveControl = panelFindRoom;
            }
            else
            {
                // ĐÃ CÓ PHÒNG -> Hiển thị Giao diện QUẢN LÝ
                panelMenu.Visible = true;
                panelFindRoom.Visible = false;
                panelMainContent.Visible = true;

                BtnHome_Click(null, null);
            }
        }

        #region X? lý Chuy?n View (Cho ngu?i dã thuê)

        private async Task ShowView<T>(Control control, T uc) where T : Control
        {
            if (_myRoomControl != null && uc != _myRoomControl) _myRoomControl.Visible = false;
            if (_myBillsControl != null && uc != _myBillsControl) _myBillsControl.Visible = false;
            if (_myContractControl != null && uc != _myContractControl) _myContractControl.Visible = false;
            if (_myReportsControl != null && uc != _myReportsControl) _myReportsControl.Visible = false;
            if (control == null) return;
            if (!panelMainContent.Controls.Contains(control))
            {
                control.Dock = DockStyle.Fill;
                panelMainContent.Controls.Add(control);
            }
            control.BringToFront();
            control.Visible = true;
        }

        private async void BtnHome_Click(object sender, EventArgs e)
        {
            await Mediator.Instance.PublishForm<Contract>("UcMyRoom", _activeContract, async (control) =>
            {
                _myRoomControl = (ucMyRoom)control;
                await ShowView(control, _myRoomControl);
            });
        }
        private async void BtnBills_Click(object sender, EventArgs e)
        {
            await Mediator.Instance.PublishForm<Contract>("UcMyBills", _activeContract, async (control) =>
            {
                _myBillsControl = (ucMyBills)control;
                await ShowView(control, _myBillsControl);
            });
        }
        private async void BtnContract_Click(object sender, EventArgs e)
        {
            await Mediator.Instance.PublishForm<Contract>("UcMyContract", _activeContract, async (control) =>
            {
                _myContractControl = (ucMyContract)control;
                await ShowView(control, _myContractControl);
            });
        }
        private async void BtnReport_Click(object sender, EventArgs e)
        {
            await Mediator.Instance.PublishForm<Contract>("UcMyReports", _activeContract, async (control) =>
            {
                _myReportsControl = (ucMyReports)control;
                await ShowView(control, _myReportsControl);
            });
        }
        private async void BtnInfo_Click(object sender, EventArgs e)
        {
            using (var formInfo = new FormInformation(_currentRenter))
            {
                formInfo.StartPosition = FormStartPosition.CenterParent;
                formInfo.ShowDialog(this);
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?",
                                                  "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                AuthForm authForm = new AuthForm();
                authForm.ShowDialog(this);
                this.Close();
            }
        }
        #endregion

        #region Giao di?n TÌM PHÒNG (Cho ngu?i chua thuê)

        /// <summary>
        /// Kh?i t?o s? ki?n, giá tr? cho b? l?c và t?i phòng l?n d?u
        /// </summary>
        private void InitializeFilterLogic()
        {
            _allAvailableRooms = _roomService.GetAllAvailableRooms();

            decimal maxPrice = (_allAvailableRooms.Any() && _allAvailableRooms.Max(r => r.Price) > 0) ? _allAvailableRooms.Max(r => r.Price ?? 0) : 10000000;
            decimal maxArea = (_allAvailableRooms.Any() && _allAvailableRooms.Max(r => r.Area) > 0) ? (_allAvailableRooms.Max(r => r.Area ?? 0)) : 100;

            nudPriceFrom.Maximum = maxPrice;
            nudPriceTo.Maximum = maxPrice;
            nudAreaFrom.Maximum = maxArea;
            nudAreaTo.Maximum = maxArea;

            nudPriceTo.Value = maxPrice;
            nudAreaTo.Value = maxArea;

            txtSearch.TextChanged += (s, e) => FilterAndDisplayRooms();
            nudPriceFrom.ValueChanged += (s, e) => FilterAndDisplayRooms();
            nudPriceTo.ValueChanged += (s, e) => FilterAndDisplayRooms();
            nudAreaFrom.ValueChanged += (s, e) => FilterAndDisplayRooms();
            nudAreaTo.ValueChanged += (s, e) => FilterAndDisplayRooms();

            btnResetPrice.Click += BtnResetPrice_Click;
            btnResetArea.Click += BtnResetArea_Click;

            txtSearch.Enter += TxtSearch_Enter;
            txtSearch.Leave += TxtSearch_Leave;
            SetPlaceholder();

            FilterAndDisplayRooms();
        }

        private void BtnResetPrice_Click(object sender, EventArgs e)
        {
            nudPriceFrom.Value = 0;
            nudPriceTo.Value = nudPriceTo.Maximum;
        }

        private void BtnResetArea_Click(object sender, EventArgs e)
        {
            nudAreaFrom.Value = 0;
            nudAreaTo.Value = nudAreaTo.Maximum;
        }

        /// <summary>
        /// Hàm l?c và tìm ki?m chính
        /// </summary>
        private void FilterAndDisplayRooms()
        {
            if (_allAvailableRooms == null) return;

            IEnumerable<Room> filteredList = _allAvailableRooms;

            decimal priceFrom = nudPriceFrom.Value;
            decimal priceTo = nudPriceTo.Value;
            decimal areaFrom = nudAreaFrom.Value;
            decimal areaTo = nudAreaTo.Value;
            string keyword = txtSearch.Text.ToLower().Trim();

            if (priceTo > 0 && priceTo >= priceFrom)
            {
                filteredList = filteredList.Where(r =>
                    r.Price.HasValue &&
                    r.Price.Value >= priceFrom &&
                    r.Price.Value <= priceTo);
            }
            if (areaTo > 0 && areaTo >= areaFrom)
            {
                filteredList = filteredList.Where(r =>
                    r.Area.HasValue &&
                    r.Area.Value >= areaFrom && 
                    r.Area.Value <= areaTo);    
            }

            if (!string.IsNullOrEmpty(keyword) && keyword != PlaceholderText.ToLower())
            {
                filteredList = filteredList.Where(r =>
                    (r.Name != null && r.Name.ToLower().Contains(keyword)) ||
                    (r.Address != null && r.Address.ToLower().Contains(keyword))
                );
            }

            _selectedRoomCard = null;
            DisplayRoomsUI(filteredList.ToList());
        }

        /// <summary>
        /// Hàm v? giao di?n các Card phòng
        /// </summary>
        private void DisplayRoomsUI(List<Room> rooms)
        {
            flowPanelRooms.Controls.Clear();

            if (rooms.Count == 0)
            {
                lblNoResults.Visible = true;
                flowPanelRooms.Controls.Add(lblNoResults);
                return;
            }

            lblNoResults.Visible = false;

            foreach (var room in rooms)
            {
                Panel roomPanel = new Panel
                {
                    Width = 530,
                    Height = 750,
                    Margin = new Padding(20),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.White,
                    Tag = room
                };

                PictureBox pic = new PictureBox
                {
                    Dock = DockStyle.Top,
                    Height = 300,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = room
                };

                string imgPath = room.RoomImages?.FirstOrDefault()?.ImageUrl;
                if (!string.IsNullOrEmpty(imgPath))
                {
                    if (File.Exists(imgPath))
                    {
                        try { pic.Image = Image.FromFile(imgPath); } catch { }
                    }
                }

                Label lblName = new Label
                {
                    Text = room.Name,
                    Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                    Dock = DockStyle.Top,
                    Padding = new Padding(15, 8, 15, 8),
                    AutoSize = true,
                    Tag = room
                };

                Label lblPrice = new Label
                {
                    Text = $"{room.Price:N0} VND / tháng",
                    Font = new Font("Segoe UI", 12F),
                    Dock = DockStyle.Top,
                    Padding = new Padding(15, 0, 15, 8),
                    AutoSize = true,
                    ForeColor = Color.DarkRed,
                    Tag = room
                };

                Label lblArea = new Label
                {
                    Text = $"Diện tích: {room.Area:N2} m²",
                    Font = new Font("Segoe UI", 12F),
                    Dock = DockStyle.Top,
                    Padding = new Padding(15, 0, 15, 8),
                    AutoSize = true,
                    ForeColor = Color.DarkGray,
                    Tag = room
                };

                Label lblAddress = new Label
                {
                    Text = $"Ðịa chỉ: {room.Address}",
                    Font = new Font("Segoe UI", 12F),
                    Dock = DockStyle.Top,
                    Padding = new Padding(15, 0, 15, 8),
                    AutoSize = true,
                    ForeColor = Color.DarkGray,
                    MaximumSize = new Size(500, 0),
                    Tag = room
                };

                Button btnBook = new Button
                {
                    Text = "Gửi yêu cầu thuê",
                    Tag = room,
                    Dock = DockStyle.Bottom,
                    Height = 65,
                    Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(41, 128, 185),
                    ForeColor = Color.White
                };
                btnBook.Click += BtnBook_Click;

                roomPanel.Controls.Add(lblAddress);
                roomPanel.Controls.Add(lblArea);
                roomPanel.Controls.Add(lblPrice);
                roomPanel.Controls.Add(lblName);
                roomPanel.Controls.Add(pic);
                roomPanel.Controls.Add(btnBook);

                roomPanel.Click += BtnView_Click;
                pic.Click += BtnView_Click;
                lblName.Click += BtnView_Click;
                lblPrice.Click += BtnView_Click;
                lblArea.Click += BtnView_Click;
                lblAddress.Click += BtnView_Click;

                flowPanelRooms.Controls.Add(roomPanel);
            }
        }

        /// <summary>
        /// X? lý click vào Card (Panel, Pic, Label) d? XEM CHI TI?T
        /// </summary>
        private void BtnView_Click(object sender, EventArgs e)
        {
            Control clickedControl = sender as Control;
            Panel currentCard = null;
            if (clickedControl is Panel)
                currentCard = (Panel)clickedControl;
            else if (clickedControl != null)
                currentCard = clickedControl.Parent as Panel;
            if (currentCard == null) return;
            Room room = (Room)currentCard.Tag;
            if (room == null) return;
            if (_selectedRoomCard != null && _selectedRoomCard != currentCard)
            {
                _selectedRoomCard.BackColor = Color.White;
            }
            currentCard.BackColor = Color.AliceBlue;
            _selectedRoomCard = currentCard;
            using (FormInfoRoom frm = new FormInfoRoom(room, _currentRenter, true))
            {
                frm.ShowDialog(this);
            }
        }

        /// <summary>
        /// X? lý click vào nút "G?i Yêu C?u"
        /// </summary>
        private void BtnBook_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Room room = (Room)btn.Tag;

            if (btn.Text == "Ðã gửi yêu cầu") return;

            using (FormRequestContract frm = new FormRequestContract(_currentRenter, room))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    btn.Enabled = false;
                    btn.Text = "Ðã gửi yêu cầu";
                    btn.BackColor = Color.Gray;
                }
            }
        }

        private void SetPlaceholder()
        {
            txtSearch.Text = PlaceholderText;
            txtSearch.ForeColor = Color.Gray;
        }
        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == PlaceholderText)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }
        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                SetPlaceholder();
            }
        }

        #endregion
    }
}
