using QuanLyPhongTro.Services;
using QuanLyPhongTro.src.Test.Mediator;
using QuanLyPhongTro.src.Test.Models;
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
        private List<Room> _allRooms;

        private ucBillManagement _billControl;
        private ucContractManagement _contractControl;
        //private ucReportManagement _reportControl;
        private ucIncidentManagement _incidentControl;

        public event EventHandler Logout;

        // --- SỬA LỖI 2 (Encoding) ---
        private const string PlaceholderText = "Nhập tên, địa chỉ...";

        public Owner_TrangChu(Person loggedInOwner)
        {
            InitializeComponent();
            _currentOwner = loggedInOwner;
            _roomService = new RoomService();

            this.Load += Owner_TrangChu_Load;

            btnHome.Click += BtnHome_Click;
            btnCreate.Click += BtnCreate_Click;
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
            lblOwnerName.Text = $"Chào mừng, {_currentOwner.Username}"; // <-- SỬA LỖI 2

            nudPriceFrom.Maximum = 999999999;
            nudPriceTo.Maximum = 999999999;
            nudAreaFrom.Maximum = 9999;
            nudAreaTo.Maximum = 9999;

            // --- SỬA LỖI 2 (Encoding) ---
            cboFilterStatus.Items.Add("Tất cả");
            cboFilterStatus.Items.Add("Trống");
            cboFilterStatus.Items.Add("Đã thuê");
            cboFilterStatus.SelectedIndex = 0;
            // --- HẾT SỬA ---

            BtnHome_Click(sender, e);
        }

        #region Xử lý Menu Click và Mediator

        private void BtnHome_Click(object sender, EventArgs e)
        {
            panelRoomManagement.Visible = true;
            panelRoomManagement.BringToFront();

            if (_billControl != null) _billControl.Visible = false;
            if (_contractControl != null) _contractControl.Visible = false;
            //if (_reportControl != null) _reportControl.Visible = false;
            if (_incidentControl != null) _incidentControl.Visible = false;

            LoadRooms();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            using (FormCreateRoom frm = new FormCreateRoom(_currentOwner.Id))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadRooms();
                }
            }
        }

        private async void BtnBill_Click(object sender, EventArgs e)
        {
            await Mediator.Instance.PublishForm<Person>("UcBillManagement", _currentOwner, async (control) =>
            {
                _billControl = (ucBillManagement)control;
                await ShowView(control, _billControl);
            });
        }
        private async void BtnContract_Click(object sender, EventArgs e)
        {
            await Mediator.Instance.PublishForm<Person>("UcContractManagement", _currentOwner, async (control) =>
            {
                _contractControl = (ucContractManagement)control;
                await ShowView(control, _contractControl);
            });
        }
        private async void BtnReport_Click(object sender, EventArgs e)
        {
            
        }
        private async void BtnIncidents_Click(object sender, EventArgs e)
        {
            await Mediator.Instance.PublishForm<Person>("UcIncidentManagement", _currentOwner, async (control) =>
            {
                _incidentControl = (ucIncidentManagement)control;
                await ShowView(control, _incidentControl);
            });
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

        private async Task ShowView<T>(Control control, T uc) where T : Control
        {
            panelRoomManagement.Visible = false;
            if (_billControl != null && uc != _billControl) _billControl.Visible = false;
            if (_contractControl != null && uc != _contractControl) _contractControl.Visible = false;
            //if (_reportControl != null && uc != _reportControl) _reportControl.Visible = false;
            if (_incidentControl != null && uc != _incidentControl) _incidentControl.Visible = false;
            if (control == null) return;
            if (!this.Controls.Contains(control))
            {
                control.Dock = DockStyle.Fill;
                this.Controls.Add(control);
            }
            control.BringToFront();
            control.Visible = true;
        }

        #endregion

        #region Xử lý Phòng (Tải, Vẽ và Lọc/Tìm kiếm)

        private void LoadRooms()
        {
            _allRooms = _roomService.GetAllRoomsByOwner(_currentOwner.Id);
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

        private void FilterAndDisplayRooms()
        {
            if (_allRooms == null) return;

            IEnumerable<Room> filteredList = _allRooms;

            decimal priceFrom = nudPriceFrom.Value;
            decimal priceTo = nudPriceTo.Value;
            decimal areaFrom = nudAreaFrom.Value;
            decimal areaTo = nudAreaTo.Value;
            string status = cboFilterStatus.SelectedItem?.ToString() ?? "Tất cả"; // Sửa (Lấy "Trống")
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

            // 3. Áp dụng TÌM KIẾM
            if (!string.IsNullOrEmpty(keyword) && keyword != PlaceholderText.ToLower())
            {
                filteredList = filteredList.Where(r =>
                    (r.Name != null && r.Name.ToLower().Contains(keyword)) ||
                    (r.Address != null && r.Address.ToLower().Contains(keyword)) ||
                    (r.Price.HasValue && r.Price.Value.ToString("N0").Contains(keyword))
                );
            }

            // 4. Hiển thị kết quả
            DisplayRooms(filteredList.ToList());
        }

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
            Panel card = new Panel
            {
                Size = new Size(450, 600),
                BackColor = room.Status.Contains("Trống") ? Color.White : Color.FromArgb(192, 255, 192),
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblTitle = new Label
            {
                Text = $"P{room.Name}",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = room.Status.Contains("Trống") ? Color.Black : Color.DarkGreen,
                AutoSize = false,
                Size = new Size(430, 50),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(10, 10)
            };
            card.Controls.Add(lblTitle);

            // Button phần nội dung, tự xuống dòng như code cũ
            Button btn = new Button
            {
                Size = new Size(430, 460),
                Location = new Point(10, 70),
                Padding = new Padding(10),
                Tag = room,
                Font = new Font("Segoe UI", 11F),
                TextAlign = ContentAlignment.TopLeft,
                BackColor = card.BackColor,
                ForeColor = room.Status.Contains("Trống") ? Color.Black : Color.DarkGreen,
                UseCompatibleTextRendering = true,
                Text =
                    $"Giá: {room.Price:N0} VND\n" +
                    $"Diện tích: {room.Area} m²\n" +
                    $"Địa chỉ: {room.Address}\n\n" +
                    $"Trạng thái: {room.Status}"
            };

            btn.Click += BtnRoom_Click;
            card.Controls.Add(btn);

            flowPanelRooms.Controls.Add(card);
        }



        private void BtnRoom_Click(object sender, EventArgs e)
        {
            Control clickedControl = (Control)sender;
            Panel card = (clickedControl is Panel) ? (Panel)clickedControl : (Panel)clickedControl.Parent;
            Room roomClicked = (Room)card.Tag;

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

        // (BtnView_Click không còn được dùng, vì logic đã gộp vào BtnRoom_Click)

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