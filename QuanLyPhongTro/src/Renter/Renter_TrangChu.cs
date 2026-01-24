using QuanLyPhongTro.src.Common;
using QuanLyPhongTro.src.Login;
using QuanLyPhongTro.src.Mediator;
using QuanLyPhongTro.src.Models;
using QuanLyPhongTro.src.Services1;
using QuanLyPhongTro.src.UserSession;
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
        private readonly BookingRequestService _requestService; // Thêm service

        private List<Room> _allAvailableRooms;
        private const string PlaceholderText = "Nhập tên, địa chỉ...";
        private Panel _selectedRoomCard = null;

        public event EventHandler Logout;

        private Contract _activeContract;
        private ucMyRoom _myRoomControl;
        private ucMyBills _myBillsControl;
        private ucMyContract _myContractControl;
        private ucMyReports _myReportsControl;

        // Biến lưu nút đang được chọn
        private Button _currentSelectedButton = null;

        public Renter_TrangChu()
        {
            InitializeComponent();
            _currentRenter = UserSession.Instance._user;
            _roomService = new RoomService();
            _personService = new PersonService();
            _contractService = new ContractService();
            _requestService = new BookingRequestService(); 

            this.Load += Renter_TrangChu_Load;

            btnHome.Click += BtnHome_Click;
            btnBills.Click += BtnBills_Click;
            btnContract.Click += BtnContract_Click;
            btnUploadContract.Click += BtnUploadContract_Click;
            btnReport.Click += BtnReport_Click;
            btnProfile.Click += BtnInfo_Click;
            btnLogout.Click += BtnLogout_Click;
            btnLogoutFindRoom.Click += BtnLogout_Click; 
        }

        private void Renter_TrangChu_Load(object sender, EventArgs e)
        {
            lblRenterName.Text = $"Chào mừng, {_currentRenter.Username}";

            _activeContract = _contractService.GetActiveContractByRenter(_currentRenter.Id);
            
            if (_activeContract == null)
            {
                _activeContract = _contractService.GetPendingContractsByRenter(_currentRenter.Id).FirstOrDefault();
            }

            if (_activeContract == null)
            {
                // CHƯA CÓ HỢP ĐỒNG NÀO -> Hiển thị Giao diện TÌM PHÒNG
                panelMenu.Visible = false;
                panelMainContent.Visible = false;
                panelFindRoom.Visible = true;
                panelFindRoom.Dock = DockStyle.Fill;
                btnLogoutFindRoom.Visible = true;

                InitializeFilterLogic();
                this.ActiveControl = panelFindRoom;
            }
            else
            {
                // ĐÃ CÓ HỢP ĐỒNG (Tạm thời hoặc Đang hoạt động) -> Hiển thị Giao diện QUẢN LÝ
                panelMenu.Visible = true;
                panelFindRoom.Visible = false;
                panelMainContent.Visible = true;
                btnLogoutFindRoom.Visible = false;
                if (_activeContract.Status == "Tạm thời")
                {
                    MessageBox.Show(
                        "Bạn có hợp đồng đang chờ upload ảnh để kích hoạt!\n\n" +
                        "Vui lòng upload ảnh hợp đồng đã ký để bắt đầu sử dụng phòng.",
                        "Thông báo quan trọng",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    
                    BtnUploadContract_Click(null, null);
                }
                else
                {
                    // Hợp đồng đang hoạt động → Hiển thị màn Home bình thường
                    BtnHome_Click(null, null);
                }
            }
        }

        /// <summary>
        /// Đánh dấu nút được chọn với màu trắng và chữ đậm
        /// </summary>
        private void HighlightButton(Button selectedButton)
        {
            // Reset nút cũ về màu mặc định
            if (_currentSelectedButton != null)
            {
                _currentSelectedButton.BackColor = SystemColors.Control;
                _currentSelectedButton.ForeColor = Color.Black;
                _currentSelectedButton.Font = new Font(_currentSelectedButton.Font, FontStyle.Regular);
            }

            // Highlight nút mới
            _currentSelectedButton = selectedButton;
            _currentSelectedButton.BackColor = Color.White;
            _currentSelectedButton.ForeColor = Color.FromArgb(41, 128, 185);
            _currentSelectedButton.Font = new Font(_currentSelectedButton.Font, FontStyle.Bold);
        }

        #region Xử lý Chuyển View (Cho người đã thuê)

        private async Task ShowView(UserControl instance)
        {
            if (instance == null) return; // Chặn lỗi null

            panelMainContent.Controls.Clear();
            instance.Dock = DockStyle.Fill;
            panelMainContent.Controls.Add(instance);

            await Task.Delay(1);
        }

        private async void BtnHome_Click(object sender, EventArgs e)
        {
            HighlightButton(btnHome);
            
            await ClickGuard.RunOnceAsync("HOME", async () =>
            {
                await Mediator.Instance.PublishForm<Contract>("UcMyRoom", _activeContract, async (control) =>
                {
                    if (control is ucMyRoom myRoomInstance)
                    {
                        _myRoomControl = myRoomInstance;
                        await ShowView(_myRoomControl);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Lỗi: Control trả về null hoặc sai kiểu dữ liệu.");
                    }
                });
            }, btnHome);
        }

        private async void BtnBills_Click(object sender, EventArgs e)
        {
            HighlightButton(btnBills);
            
            await ClickGuard.RunOnceAsync("BILLS", async () =>
            {
                await Mediator.Instance.PublishForm<Contract>("UcMyBills", _activeContract, async (control) =>
                {
                    if (control is ucMyBills myBillsInstance)
                    {
                        _myBillsControl = myBillsInstance;
                        await ShowView(_myBillsControl);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Lỗi: Control trả về null hoặc sai kiểu dữ liệu.");
                    }
                });
            }, btnBills);
        }

        private async void BtnContract_Click(object sender, EventArgs e)
        {
            HighlightButton(btnContract);
            
            await ClickGuard.RunOnceAsync("CONTRACT", async () =>
            {
                await Mediator.Instance.PublishForm<Contract>("UcMyContract", _activeContract, async (control) =>
                {
                    if (control is ucMyContract myContractInstance)
                    {
                        _myContractControl = myContractInstance;
                        await ShowView(_myContractControl);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Lỗi: Control trả về null hoặc sai kiểu dữ liệu.");
                    }
                });
            }, btnContract);
        }

        private async void BtnReport_Click(object sender, EventArgs e)
        {
            HighlightButton(btnReport);
            
            await ClickGuard.RunOnceAsync("REPORT", async () =>
            {
                await Mediator.Instance.PublishForm<Contract>("UcMyReports", _activeContract, async (control) =>
                {
                    if (control is ucMyReports myReportsInstance)
                    {
                        _myReportsControl = myReportsInstance;
                        await ShowView(_myReportsControl);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Lỗi: Control trả về null hoặc sai kiểu dữ liệu.");
                    }
                });
            }, btnReport);
        }

        private async void BtnUploadContract_Click(object sender, EventArgs e)
        {
            HighlightButton(btnUploadContract);
            
            await ClickGuard.RunOnceAsync("UPLOADCONTRACT", async () =>
            {
                await Mediator.Instance.PublishForm<Contract>("UcPendingContracts", _activeContract, async (control) =>
                {
                    if (control is ucPendingContracts pendingContractsInstance)
                    {
                        await ShowView(pendingContractsInstance);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Lỗi: Control trả về null hoặc sai kiểu dữ liệu.");
                    }
                });
            }, btnUploadContract);
        }

        private async void BtnInfo_Click(object sender, EventArgs e)
        {
            HighlightButton(btnProfile);
            
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
                UserSession.Instance.Logout();
                Loginmain form = new();
                form.Show();
                this.Hide();
            }
        }

        /// <summary>
        /// Phương thức reload lại giao diện sau khi upload hợp đồng thành công
        /// </summary>
        public void ReloadAfterContractActivation()
        {
            // Reload lại contract từ database
            _activeContract = _contractService.GetActiveContractByRenter(_currentRenter.Id);
            
            if (_activeContract != null && _activeContract.Status == "Đang hoạt động")
            {
                // Chuyển về trang Home
                BtnHome_Click(null, null);
            }
            else
            {
                // Nếu vẫn chưa có hợp đồng hoạt động, reload lại form
                Renter_TrangChu_Load(null, null);
            }
        }
        #endregion

        #region Giao diện TÌM PHÒNG (Cho người chưa thuê)

        /// <summary>
        /// Khởi tạo sự kiện, giá trị cho bộ lọc và tải phòng lần đầu
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
        /// Hàm lọc và tìm kiếm chính
        /// </summary>
        private void FilterAndDisplayRooms()
        {
            if (_allAvailableRooms == null) return;
            _allAvailableRooms = _roomService.GetAllAvailableRooms();
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

            // Tìm kiếm theo tên phòng, giá, và địa chỉ ListRoom
            if (!string.IsNullOrEmpty(keyword) && keyword != PlaceholderText.ToLower())
            {
                filteredList = filteredList.Where(r =>
                    (r.Name != null && r.Name.ToLower().Contains(keyword)) ||
                    (r.Price.HasValue && r.Price.Value.ToString("N0").Contains(keyword)) ||
                    (r.ListRooms != null && r.ListRooms.Address != null && r.ListRooms.Address.ToLower().Contains(keyword))
                );
            }

            _selectedRoomCard = null;
            DisplayRoomsUI(filteredList.ToList());
        }

        /// <summary>
        /// Hàm vẽ giao diện các Card phòng
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
                    //Text = $"Địa chỉ: {room.Address}",
                    Font = new Font("Segoe UI", 12F),
                    Dock = DockStyle.Top,
                    Padding = new Padding(15, 0, 15, 8),
                    AutoSize = true,
                    ForeColor = Color.DarkGray,
                    MaximumSize = new Size(500, 0),
                    Tag = room
                };

                // Kiểm tra xem renter đã gửi yêu cầu cho phòng này chưa
                bool hasPendingRequest = _requestService.HasPendingRequestForRoom(_currentRenter.Id, room.Id);

                Button btnBook = new Button
                {
                    Tag = room,
                    Dock = DockStyle.Bottom,
                    Height = 65,
                    Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat
                };

                if (hasPendingRequest)
                {
                    btnBook.Text = "Đã gửi yêu cầu";
                    btnBook.Enabled = false;
                    btnBook.BackColor = Color.Gray;
                    btnBook.ForeColor = Color.White;
                }
                else
                {
                    btnBook.Text = "Gửi yêu cầu thuê";
                    btnBook.BackColor = Color.FromArgb(41, 128, 185);
                    btnBook.ForeColor = Color.White;
                    btnBook.Click += BtnBook_Click;
                }

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
        /// Xử lý click vào Card (Panel, Pic, Label) để XEM CHI TIẾT
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
        /// Xử lý click vào nút "Gửi Yêu Cầu"
        /// </summary>
        private void BtnBook_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Room room = (Room)btn.Tag;

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
