using QuanLyPhongTro.Model;
using QuanLyPhongTro.Services;
using QuanLyPhongTro.src.Mediator;
using QuanLyPhongTro.src.Messages;
using System;
using System.Collections.Generic;
using System.Drawing; // Cần để dùng Color
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class Owner_TrangChu : Form
    {
        // Dữ liệu
        private List<Room> _roomList = new List<Room>(); // Danh sách phòng gốc
        private readonly Mediator _mediator = Mediator.Instance;
        private readonly RoomService _roomService;
        private readonly Person _currentOwner;

        // Event
        public event EventHandler Logout;

        // Các View (UserControls)
        private ucBillManagement _billControl;
        private ucContractManagement _contractControl;
        private ucReportManagement _reportControl;
        private ucIncidentManagement _incidentControl;

        // Hằng số cho Placeholder
        private const string PlaceholderText = "Nhập tên, địa chỉ, giá, diện tích...";

        public Owner_TrangChu(Person loggedInOwner)
        {
            InitializeComponent();

            _roomService = new RoomService();
            _currentOwner = loggedInOwner;
            lblOwnerName.Text = $"Welcome, {_currentOwner.Username}";

            // Gán sự kiện cho các nút menu
            btnHome.Click += BtnHome_Click;
            btnCreate.Click += BtnCreate_Click;
            btnBill.Click += BtnBill_Click;
            btnContract.Click += BtnContract_Click;
            btnReport.Click += BtnReport_Click;
            btnIncidents.Click += BtnIncidents_Click; // Nút mới
            btnLogout.Click += BtnLogout_Click;

            // Gán sự kiện "Instant Search"
            this.txtSearch.TextChanged += TxtSearch_TextChanged;
            this.btnSearch.Visible = false; // Ẩn nút tìm kiếm cũ

            // Gán sự kiện cho Placeholder
            this.txtSearch.Enter += TxtSearch_Enter;
            this.txtSearch.Leave += TxtSearch_Leave;
            SetPlaceholder();

            // Mediator
            _mediator.Register<RoomCreatedMessage>(this.Name, OnRoomCreated);
            this.FormClosed += (s, e) => _mediator.Unregister(this.Name);

            lblNoResults.Visible = false;
            ShowRoomView(); // Hiển thị View phòng
            LoadRooms();
        }

        /// <summary>
        /// Tải lại danh sách phòng khi có tin nhắn (từ FormCreateRoom)
        /// </summary>
        private Task OnRoomCreated(RoomCreatedMessage message)
        {
            if (message.NewRoom.IdOwner == _currentOwner.Id)
            {
                if (this.InvokeRequired) { this.Invoke(new Action(LoadRooms)); }
                else { LoadRooms(); }
            }
            return Task.CompletedTask;
        }

        #region Xử lý Sự kiện Click Menu (Chuyển View)

        /// <summary>
        /// Hiển thị View (Panel) Quản lí Phòng
        /// </summary>
        private void ShowRoomView()
        {
            // Ẩn các control khác
            if (_billControl != null) _billControl.Visible = false;
            if (_contractControl != null) _contractControl.Visible = false;
            if (_reportControl != null) _reportControl.Visible = false;
            if (_incidentControl != null) _incidentControl.Visible = false;

            // Hiển thị panel phòng
            panelRoomManagement.Visible = true;
            panelRoomManagement.BringToFront();
        }

        /// <summary>
        // Hiển thị View (UserControl) Quản lí Hóa đơn
        /// </summary>
        private void ShowBillManagementView()
        {
            // Ẩn các control khác
            panelRoomManagement.Visible = false;
            if (_contractControl != null) _contractControl.Visible = false;
            if (_reportControl != null) _reportControl.Visible = false;
            if (_incidentControl != null) _incidentControl.Visible = false;

            if (_billControl == null)
            {
                _billControl = new ucBillManagement(_currentOwner.Id);
                _billControl.Dock = DockStyle.Fill;
                this.Controls.Add(_billControl);
            }

            _billControl.BringToFront();
            _billControl.Visible = true;
            _billControl.LoadData();
        }

        /// <summary>
        /// Hiển thị View (UserControl) Quản lí Hợp đồng
        /// </summary>
        private void ShowContractManagementView()
        {
            // Ẩn các control khác
            panelRoomManagement.Visible = false;
            if (_billControl != null) _billControl.Visible = false;
            if (_reportControl != null) _reportControl.Visible = false;
            if (_incidentControl != null) _incidentControl.Visible = false;

            if (_contractControl == null)
            {
                _contractControl = new ucContractManagement(_currentOwner.Id);
                _contractControl.Dock = DockStyle.Fill;
                this.Controls.Add(_contractControl);
            }

            _contractControl.BringToFront();
            _contractControl.Visible = true;
            _contractControl.LoadData();
        }

        /// <summary>
        /// Hiển thị View (UserControl) Báo cáo Thống kê
        /// </summary>
        private void ShowReportView()
        {
            // Ẩn các control khác
            panelRoomManagement.Visible = false;
            if (_billControl != null) _billControl.Visible = false;
            if (_contractControl != null) _contractControl.Visible = false;
            if (_incidentControl != null) _incidentControl.Visible = false;

            if (_reportControl == null)
            {
                _reportControl = new ucReportManagement(_currentOwner.Id);
                _reportControl.Dock = DockStyle.Fill;
                this.Controls.Add(_reportControl);
            }

            _reportControl.BringToFront();
            _reportControl.Visible = true;
            _reportControl.LoadData();
        }

        /// <summary>
        /// Hiển thị View (UserControl) Quản lí Sự cố
        /// </summary>
        private void ShowIncidentView()
        {
            // Ẩn các control khác
            panelRoomManagement.Visible = false;
            if (_billControl != null) _billControl.Visible = false;
            if (_contractControl != null) _contractControl.Visible = false;
            if (_reportControl != null) _reportControl.Visible = false;

            if (_incidentControl == null)
            {
                _incidentControl = new ucIncidentManagement(_currentOwner.Id);
                _incidentControl.Dock = DockStyle.Fill;
                this.Controls.Add(_incidentControl);
            }

            _incidentControl.BringToFront();
            _incidentControl.Visible = true;
            _incidentControl.LoadData();
        }

        // --- Các hàm gọi ---

        private void BtnHome_Click(object sender, EventArgs e) { ShowRoomView(); }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            ShowRoomView(); // Hiển thị view phòng trước khi mở
            FormCreateRoom frm = new FormCreateRoom(_currentOwner.Id);
            frm.ShowDialog();
        }

        private void BtnBill_Click(object sender, EventArgs e) { ShowBillManagementView(); }
        private void BtnContract_Click(object sender, EventArgs e) { ShowContractManagementView(); }
        private void BtnReport_Click(object sender, EventArgs e) { ShowReportView(); }
        private void BtnIncidents_Click(object sender, EventArgs e) { ShowIncidentView(); } // Nút mới

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

        #region Xử lý Phòng (Tải, Hiển thị, Click)

        /// <summary>
        /// Tải danh sách phòng gốc từ CSDL
        /// </summary>
        private void LoadRooms()
        {
            _roomList = _roomService.GetAllRoomsByOwner(_currentOwner.Id);
            FilterAndDisplayRooms();
        }

        /// <summary>
        /// Tạo 1 Button cho phòng (VỚI KÍCH THƯỚC LỚN)
        /// </summary>
        private void AddRoomButtonUI(Room room)
        {
            Button btn = new Button
            {
                Size = new Size(450, 494),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                TextAlign = ContentAlignment.TopLeft,
                Padding = new Padding(15),
                Tag = room,
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
        /// Mở FormInfoRoom khi click vào phòng
        /// </summary>
        private void BtnRoom_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
            Room roomClicked = (Room)btnClicked.Tag;

            using (FormInfoRoom frm = new FormInfoRoom(roomClicked, _currentOwner, isRenter: false))
            {
                frm.ShowDialog();
                if (frm.DataChanged)
                {
                    LoadRooms();
                }
            }
        }

        #endregion

        #region Xử lý Tìm kiếm (Placeholder + Instant Search)

        /// <summary>
        /// Đặt văn bản giữ chỗ và đổi màu
        /// </summary>
        private void SetPlaceholder()
        {
            txtSearch.Text = PlaceholderText;
            txtSearch.ForeColor = Color.Gray;
        }

        /// <summary>
        /// Khi click vào TextBox: Xóa placeholder
        /// </summary>
        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == PlaceholderText)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Khi click ra ngoài TextBox: Đặt lại placeholder nếu rỗng
        /// </summary>
        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                SetPlaceholder();
            }
        }

        /// <summary>
        /// Hàm này được gọi mỗi khi người dùng gõ chữ
        /// </summary>
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterAndDisplayRooms();
        }

        /// <summary>
        /// Hàm tìm kiếm và hiển thị kết quả (Đã sửa lỗi Giá & Diện tích)
        /// </summary>
        private void FilterAndDisplayRooms()
        {
            string keyword = txtSearch.Text.Trim();
            if (keyword == PlaceholderText)
            {
                keyword = "";
            }
            keyword = keyword.ToLower();

            List<Room> filteredList;

            if (string.IsNullOrEmpty(keyword))
            {
                filteredList = _roomList; // Không tìm gì -> hiển thị tất cả
            }
            else
            {
                // Tìm theo Tên, Địa chỉ, Trạng thái, Giá, hoặc Diện tích
                filteredList = _roomList.Where(r =>
                    (r.Name != null && r.Name.ToLower().Contains(keyword)) ||
                    (r.Address != null && r.Address.ToLower().Contains(keyword)) ||
                    (r.Status != null && r.Status.ToLower().Contains(keyword)) ||

                    (r.Price.HasValue &&
                        (r.Price.Value.ToString().Contains(keyword) ||
                         r.Price.Value.ToString("n0").Contains(keyword))
                    ) ||

                    (r.Area.HasValue &&
                         r.Area.Value.ToString().Contains(keyword))
                ).ToList();
            }

            // Dọn dẹp và hiển thị
            flowPanelRooms.Controls.Clear();
            foreach (var room in filteredList)
            {
                AddRoomButtonUI(room);
            }

            // Xử lý Label "Không tìm thấy"
            if (filteredList.Count == 0 && !string.IsNullOrEmpty(keyword))
            {
                lblNoResults.Visible = true;
                flowPanelRooms.Visible = false;
            }
            else
            {
                lblNoResults.Visible = false;
                flowPanelRooms.Visible = true;
            }
        }

        #endregion
    }
}