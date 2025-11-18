using QuanLyPhongTro.src.Services1;
using QuanLyPhongTro.src.Mediator;
using QuanLyPhongTro.src.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyPhongTro.src.UserSession;
using QuanLyPhongTro.src.Login;

namespace QuanLyPhongTro
{
    public partial class Owner_TrangChu : Form
    {
        private readonly Person _currentOwner;
        private readonly RoomService _roomService;
        private readonly ContractService _contractService;
        private List<Room> _allRooms;

        //private ucBillManagement _billControl;
        private ucContractManagement _contractControl;
        //private ucReportManagement _reportControl;
        private ucIncidentManagement _incidentControl;

        public event EventHandler Logout;

        private const string PlaceholderText = "Nhập tên, địa chỉ...";

        public Owner_TrangChu()
        {
            InitializeComponent();
            _roomService = new RoomService();

            this.Load += Owner_TrangChu_Load;

            btnHome.Click += BtnHome_Click;//
            btnCreate.Click += BtnCreate_Click;//
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
            lblOwnerName.Text = $"Chào mừng, {UserSession.Instance._user?.Username}"; // <-- SỬA LỖI 2

            nudPriceFrom.Maximum = 999999999;
            nudPriceTo.Maximum = 999999999;
            nudAreaFrom.Maximum = 9999;
            nudAreaTo.Maximum = 9999;

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

            //if (_billControl != null) _billControl.Visible = false;
            if (_contractControl != null) _contractControl.Visible = false;
            //if (_reportControl != null) _reportControl.Visible = false;
            if (_incidentControl != null) _incidentControl.Visible = false;

            LoadRooms();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            using (FormCreateRoom frm = new FormCreateRoom(UserSession.Instance._user!.Id))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadRooms();
                }
            }
        }

        private async void BtnBill_Click(object sender, EventArgs e)
        {
            List<Room> rooms = _roomService.GetAllRoomsByOwner(_currentOwner.Id);
            List<Bill> bills = rooms.Where(r => r.Bills != null)
                                    .SelectMany(r => r.Bills)
                                    .ToList();
            await Mediator.Instance.PublishList<Bill>("ucBill", bills, async (controls) =>
            {
                foreach (var control in controls)
                    flowPanelRooms.Controls.Add(control);
                await Task.CompletedTask;
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
                this.Close();
            }
            Loginmain form = new();
            form.Show();
        }

        private async Task ShowView<T>(Control control, T uc) where T : Control
        {
            panelRoomManagement.Visible = false;
            //if (_billControl != null && uc != _billControl) _billControl.Visible = false;
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
            await Task.CompletedTask;
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

        private async void FilterAndDisplayRooms()
        {
            if (_allRooms == null) return;

            IEnumerable<Room> filteredList = _allRooms;

            decimal priceFrom = nudPriceFrom.Value;
            decimal priceTo = nudPriceTo.Value;
            decimal areaFrom = nudAreaFrom.Value;
            decimal areaTo = nudAreaTo.Value;
            string status = cboFilterStatus.SelectedItem?.ToString() ?? "Tất cả"; // Lấy "Trống"
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
            await DisplayRooms(filteredList.ToList());
        }

        private async Task DisplayRooms(List<Room> rooms)
        {
            flowPanelRooms.Controls.Clear();
            if (rooms.Count == 0)
            {
                lblNoResults.Visible = true;
                return;
            }
            lblNoResults.Visible = false;
            await Mediator.Instance.PublishList<Room>("ucRoom", rooms, async (roomList) =>
            {
                foreach (var room in roomList)
                {
                    flowPanelRooms.Controls.Add(room);
                }
                await Task.CompletedTask;
            });

        
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