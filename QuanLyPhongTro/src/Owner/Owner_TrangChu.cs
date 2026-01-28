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
    public partial class Owner_TrangChu : Form
    {
        private readonly Person _currentOwner;
        private readonly RoomService _roomService;
        private readonly ContractService _contractService;
        private List<Room> _allRooms;

        private ucBillManagement _billControl;
        private ucContractManagement _contractControl;
        private ucReportManagement _reportControl;
        private ucIncidentManagement _incidentControl;

        private bool _isLoadingHome = false;
        private CancellationTokenSource? _navigationCts;

        public event EventHandler Logout;

        private const string PlaceholderText = "Nhập tên, địa chỉ hoặc giá để tìm kiếm";

        // Biến lưu nút đang được chọn
        private Button _currentSelectedButton = null;

        public Owner_TrangChu()
        {
            InitializeComponent();
            _roomService = new RoomService();
            _contractService = new ContractService();

            this.Load += Owner_TrangChu_Load;
            this.FormClosed += (s, e) => Application.Exit();

            btnHome.Click += BtnHome_Click;
            btnCreate.Click += BtnCreate_Click;
            btnManageListRoom.Click += BtnManageListRoom_Click;
            btnBill.Click += BtnBill_Click;
            btnContract.Click += BtnContract_Click;
            btnReport.Click += BtnReport_Click;
            btnIncidents.Click += BtnIncidents_Click;
            btnLogout.Click += BtnLogout_Click;

            txtSearch.TextChanged += (s, e) => FilterAndDisplayRooms();

            this.txtSearch.Enter += TxtSearch_Enter;
            this.txtSearch.Leave += TxtSearch_Leave;
            SetPlaceholder();

            nudPriceFrom.ValueChanged += (s, e) => FilterAndDisplayRooms();
            nudPriceTo.ValueChanged += (s, e) => FilterAndDisplayRooms();
            nudAreaFrom.ValueChanged += (s, e) => FilterAndDisplayRooms();
            nudAreaTo.ValueChanged += (s, e) => FilterAndDisplayRooms();
            cboFilterStatus.SelectedIndexChanged += (s, e) => FilterAndDisplayRooms();

            btnResetPrice.Click += BtnResetPrice_Click;
            btnResetArea.Click += BtnResetArea_Click;
            btnResetStatus.Click += BtnResetStatus_Click;
        }

        private void Owner_TrangChu_Load(object sender, EventArgs e)
        {
            lblOwnerName.Text = $"Chào mừng, {UserSession.Instance._user?.Username}";

            nudPriceFrom.Maximum = 999999999;
            nudPriceTo.Maximum = 999999999;
            nudAreaFrom.Maximum = 9999;
            nudAreaTo.Maximum = 9999;

            cboFilterStatus.Items.Add("Tất cả");
            cboFilterStatus.Items.Add("Trống");
            cboFilterStatus.Items.Add("Đã thuê");
            cboFilterStatus.SelectedIndex = 0;

            BtnHome_Click(sender, e);
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

        private CancellationToken CreateNewNavigationToken()
        {
            _navigationCts?.Cancel();
            _navigationCts?.Dispose();

            _navigationCts = new CancellationTokenSource();
            return _navigationCts.Token;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _navigationCts?.Cancel();

            foreach (Control c in this.Controls)
            {
                if (c is UserControl uc)
                {
                    uc.Dispose();
                }
            }

            base.OnFormClosing(e);
        }



        #region Xử lý Menu Click và Mediator

        private async void BtnHome_Click(object sender, EventArgs e)
        {
            HighlightButton(btnHome);
            
            var token = CreateNewNavigationToken();

            try
            {
                await ClickGuard.RunOnceAsync("HOME", async () =>
                {
                    token.ThrowIfCancellationRequested();

                    panelRoomManagement.Visible = true;
                    panelRoomManagement.BringToFront();

                    _billControl?.Hide();
                    _contractControl?.Hide();
                    _reportControl?.Hide();
                    _incidentControl?.Hide();

                    var rooms = await Task.Run(() =>
                    {
                        token.ThrowIfCancellationRequested();
                        return _roomService.GetAllRoomsByOwner(
                            UserSession.Instance._user!.Id);
                    }, token);

                    token.ThrowIfCancellationRequested();

                    _allRooms = rooms;
                    InitializeFilters();
                    FilterAndDisplayRooms();
                }, btnHome);
            }
            catch (OperationCanceledException)
            {
            }
        }


        private void BtnCreate_Click(object sender, EventArgs e)
        {
            using (FormCreateRoom frm = new FormCreateRoom(UserSession.Instance._user!.Id))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Tự động quay về giao diện Home để hiển thị phòng mới
                    BtnHome_Click(sender, e);
                }
            }
        }

        private void BtnManageListRoom_Click(object sender, EventArgs e)
        {
            using (FormManageListRoom frm = new FormManageListRoom(UserSession.Instance._user!.Id))
            {
                frm.ShowDialog();
                // Tự động quay về giao diện Home để cập nhật danh sách phòng
                BtnHome_Click(sender, e);
            }
        }

        private async Task ShowView(Control control, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            if (control == null) return;

            panelRoomManagement.Visible = false;

            foreach (Control c in this.Controls)
            {
                if (c is UserControl && c != control && c != panelRoomManagement)
                {
                    c.Visible = false;
                }
            }

            token.ThrowIfCancellationRequested();

            if (!this.Controls.Contains(control))
            {
                control.Dock = DockStyle.Fill;
                this.Controls.Add(control);
            }

            control.Visible = true;
            control.BringToFront();

            await Task.CompletedTask;
        }


        private async void BtnBill_Click(object sender, EventArgs e)
        {
            HighlightButton(btnBill);
            
            var token = CreateNewNavigationToken();

            try
            {
                await ClickGuard.RunOnceAsync("BILL", async () =>
                {
                    token.ThrowIfCancellationRequested();

                    await Mediator.Instance.PublishForm<Person>(
                        "UcBillManagement",
                        UserSession.Instance._user!,
                        async (control) =>
                        {
                            token.ThrowIfCancellationRequested();

                            if (control is ucBillManagement billControl)
                            {
                                _billControl = billControl;
                                await ShowView(billControl, token);
                            }
                        });
                }, btnBill);
            }
            catch (OperationCanceledException)
            {
            }
        }


        private async void BtnContract_Click(object sender, EventArgs e)
        {
            HighlightButton(btnContract);
            
            var token = CreateNewNavigationToken();

            try
            {
                await ClickGuard.RunOnceAsync("CONTRACT", async () =>
                {
                    token.ThrowIfCancellationRequested();

                    await Mediator.Instance.PublishForm<Person>(
                        "UcContractManagement",
                        UserSession.Instance._user!,
                        async (control) =>
                        {
                            token.ThrowIfCancellationRequested();

                            if (control is ucContractManagement contractControl)
                            {
                                _contractControl = contractControl;
                                await ShowView(contractControl, token);
                            }
                        });
                }, btnContract);
            }
            catch (OperationCanceledException)
            {
            }
        }
        private async void BtnReport_Click(object sender, EventArgs e)
        {
            HighlightButton(btnReport);
            
            var token = CreateNewNavigationToken();

            try
            {
                await ClickGuard.RunOnceAsync("REPORT", async () =>
                {
                    token.ThrowIfCancellationRequested();

                    await Mediator.Instance.PublishForm<Person>(
                        "UcReportManagement",
                        UserSession.Instance._user!,
                        async (control) =>
                        {
                            token.ThrowIfCancellationRequested();

                            if (control is ucReportManagement reportControl)
                            {
                                _reportControl = reportControl;
                                await ShowView(reportControl, token);
                            }
                        });
                }, btnReport);
            }
            catch (OperationCanceledException)
            {
            }
        }
        private async void BtnIncidents_Click(object sender, EventArgs e)
        {
            HighlightButton(btnIncidents);
            
            var token = CreateNewNavigationToken();

            try
            {
                await ClickGuard.RunOnceAsync("INCIDENTS", async () =>
                {
                    token.ThrowIfCancellationRequested();

                    await Mediator.Instance.PublishForm<Person>(
                        "UcIncidentManagement",
                        UserSession.Instance._user!,
                        async (control) =>
                        {
                            token.ThrowIfCancellationRequested();

                            if (control is ucIncidentManagement incidentControl)
                            {
                                _incidentControl = incidentControl;
                                await ShowView(incidentControl, token);
                            }
                        });
                }, btnIncidents);
            }
            catch (OperationCanceledException)
            {
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
                this.Hide();
                form.Show();
            }
        }


        #endregion

        #region Xử lý Phòng (Tải, Vẽ và Lọc/Tìm kiếm)

        private void LoadRooms()
        {
            _allRooms = _roomService.GetAllRoomsByOwner(UserSession.Instance._user!.Id);
            // (Nạp lại bộ lọc Max/Min dựa trên dữ liệu mới)
            InitializeFilters();
            FilterAndDisplayRooms();
        }

        /// <summary>
        /// (Hàm mới) Khởi tạo giá trị Max cho bộ lọc
        /// </summary>
        private void InitializeFilters()
        {
            if (_allRooms == null || !_allRooms.Any()) return;

            decimal maxPrice = (_allRooms.Max(r => r.Price) > 0) ? _allRooms.Max(r => r.Price ?? 0) : 10000000;
            decimal maxArea = (_allRooms.Max(r => r.Area) > 0) ? (_allRooms.Max(r => r.Area ?? 0)) : 100;

            nudPriceFrom.Maximum = maxPrice;
            nudPriceTo.Maximum = maxPrice;
            nudAreaFrom.Maximum = maxArea;
            nudAreaTo.Maximum = maxArea;

            // Đặt lại giá trị (nếu đang là 0)
            if (nudPriceTo.Value == 0) nudPriceTo.Value = maxPrice;
            if (nudAreaTo.Value == 0) nudAreaTo.Value = maxArea;
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
        private void BtnResetStatus_Click(object sender, EventArgs e)
        {
            cboFilterStatus.SelectedIndex = 0; // Set về "Tất cả"
        }

        // Helper: lấy địa chỉ ListRoom theo Owner hiện tại
        private string GetOwnerAddress()
        {
            var user = UserSession.Instance._user;
            if (user == null) return string.Empty;
            try
            {
                return _roomService.GetListRoomAddressByOwner(user.Id) ?? string.Empty;
            }
            catch { return string.Empty; }
        }

        private async void FilterAndDisplayRooms()
        {
            if (_allRooms == null) return;

            IEnumerable<Room> filteredList = _allRooms;
            decimal priceFrom = nudPriceFrom.Value;
            decimal priceTo = nudPriceTo.Value;
            decimal areaFrom = nudAreaFrom.Value;
            decimal areaTo = nudAreaTo.Value;
            string status = cboFilterStatus.SelectedItem?.ToString() ?? "Tất cả";
            string keyword = txtSearch.Text.ToLower().Trim();

            // 2. Áp dụng BỘ LỌC
            if (status != "Tất cả") 
            {
                filteredList = filteredList.Where(r => r.Status == status);
            }
            if (priceTo > 0 && priceTo >= priceFrom)
            {
                filteredList = filteredList.Where(r => r.Price.HasValue && r.Price.Value >= priceFrom && r.Price.Value <= priceTo);
            }
            if (areaTo > 0 && areaTo >= areaFrom)
            {
                filteredList = filteredList.Where(r => r.Area.HasValue && r.Area.Value >= areaFrom && r.Area.Value <= areaTo);
                
            }

            // 3. Áp dụng TÌM KIẾM - Tìm theo địa chỉ ListRoom
            if (!string.IsNullOrEmpty(keyword) && keyword != PlaceholderText.ToLower())
            {
                filteredList = filteredList.Where(r =>
                    (r.Name != null && r.Name.ToLower().Contains(keyword)) ||
                    (r.Price.HasValue && r.Price.Value.ToString("N0").Contains(keyword)) ||
                    (r.ListRooms != null && r.ListRooms.Address != null && r.ListRooms.Address.ToLower().Contains(keyword))
                );
            }

            DisplayRooms(filteredList.ToList());
        }

        /// <summary>
        /// Vẽ các Card phòng lên giao diện
        /// </summary>
        private void DisplayRooms(List<Room> rooms)
        {
            flowPanelRooms.Controls.Clear();

            if (rooms.Count == 0)
            {
                lblNoResults.Visible = true;
                return;
            }
            lblNoResults.Visible = false;

            foreach (var room in rooms)
            {
                AddRoomButtonUI(room);
            }
        }

        private void AddRoomButtonUI(Room room)
        {
            // Lấy địa chỉ của ListRoom chứa phòng này
            var address = room.ListRooms?.Address ?? "N/A";

            Panel card = new Panel
            {
                Size = new Size(450, 534),
                BackColor = room.Status.Contains("Trống") ? Color.White : Color.FromArgb(192, 255, 192),
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblTitle = new Label
            {
                Text = $"{room.Name}\n",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = room.Status.Contains("Trống") ? Color.Black : Color.DarkGreen,
                AutoSize = false,
                Size = new Size(430, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(10, 10)
            };
            card.Controls.Add(lblTitle);

            Button btn = new Button
            {
                Size = new Size(430, 460),
                Location = new Point(10, 70),
                Padding = new Padding(10),
                Tag = room,
                Font = new Font("Segoe UI", 12F),
                TextAlign = ContentAlignment.TopLeft,
                BackColor = card.BackColor,
                ForeColor = room.Status.Contains("Trống") ? Color.Black : Color.DarkGreen,
                UseCompatibleTextRendering = true,
                Text =
                    $"Giá: {room.Price:N0} VND\n" +
                    $"Diện tích: {(room.Area.HasValue ? room.Area.Value.ToString("0.0") : "N/A")} m²\n" + // ✅ Format đúng với 1 chữ số thập phân
                    $"Địa chỉ: {address}\n\n" +
                    $"Trạng thái: {room.Status}"
            };

            btn.Click += BtnRoom_Click;
            card.Controls.Add(btn);

            flowPanelRooms.Controls.Add(card);
        }


        private void BtnRoom_Click(object sender, EventArgs e)
        {
            Control clickedControl = (Control)sender;
            Room roomClicked = (Room)clickedControl.Tag;

            if (roomClicked == null) return;

            using (FormInfoRoom frm = new FormInfoRoom(roomClicked, _currentOwner, false))
            {
                frm.ShowDialog();
                if (frm.DataChanged)
                {
                    LoadRooms();
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Room room = (sender as Button).Tag as Room;
            if (room == null) return;

            using (FormEditRoom frm = new FormEditRoom(room))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadRooms();
                }
            }
        }

        #endregion

        #region Xử lý Tìm kiếm (Placeholder)
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