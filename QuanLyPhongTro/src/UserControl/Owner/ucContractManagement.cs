using QuanLyPhongTro.src.Mediator;
using QuanLyPhongTro.src.Test.Model;
using QuanLyPhongTro.src.Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class ucContractManagement : UserControl
    {
        private Guid _ownerId;
        private readonly ContractService _contractService;
        private readonly BookingRequestService _requestService;

        private List<BookingRequest> _pendingRequests;
        private List<Contract> _activeContracts;

        private bool _isLoaded = false;

        public ucContractManagement()
        {
            InitializeComponent();

            _contractService = new ContractService();
            _requestService = new BookingRequestService();
            _ownerId = Guid.Empty;

            // Đăng ký nhận Person (Owner)
            Mediator.Instance.Register<Person>("UcContractManagement", (owner) =>
            {
                _ownerId = owner.Id;

                if (_isLoaded)
                {
                    LoadData();
                }

                return Task.CompletedTask;
            });

            this.Load += UcContractManagement_Load;
            this.btnRefresh.Click += (s, e) => LoadData();
            this.btnApprove.Click += BtnApprove_Click;
            this.btnReject.Click += BtnReject_Click;
            this.btnEndContract.Click += BtnEndContract_Click;
            // (Nút btnRenewContract chưa gán sự kiện)
        }

        private void UcContractManagement_Load(object sender, EventArgs e)
        {
            // 1. Cài đặt DGV (Quan trọng: Phải chạy trước)
            SetupDataGridViews();

            // 2. Đánh dấu là đã Load xong
            _isLoaded = true;

            // 3. Kiểm tra xem Mediator đã gửi OwnerId chưa
            if (_ownerId != Guid.Empty)
            {
                LoadData();
            }
        }

        /// <summary>
        /// Hàm tải dữ liệu chính (cho cả 2 tab)
        /// </summary>
        public void LoadData()
        {
            // Bảo vệ
            if (_ownerId == Guid.Empty) return;
            if (!_isLoaded) return;

            LoadPendingRequests();
            LoadActiveContracts();
        }

        /// <summary>
        /// Cài đặt cột cho cả 2 DataGridView
        /// </summary>
        private void SetupDataGridViews()
        {
            // --- SỬA TÊN: dgvRequests ---
            dgvRequests.AutoGenerateColumns = false;
            dgvRequests.Columns.Clear();
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvRequests.Columns.Add("RenterName", "Người gửi");
            dgvRequests.Columns.Add("RoomName", "Phòng muốn thuê");
            dgvRequests.Columns.Add("StartDate", "Ngày muốn vào");
            dgvRequests.Columns.Add("Duration", "Thời hạn (tháng)");
            dgvRequests.Columns.Add("Note", "Ghi chú");

            // --- SỬA TÊN: dgvContracts ---
            dgvContracts.AutoGenerateColumns = false;
            dgvContracts.Columns.Clear();
            dgvContracts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvContracts.Columns.Add("RoomName", "Phòng");
            dgvContracts.Columns.Add("RenterName", "Người thuê");
            dgvContracts.Columns.Add("StartDate", "Ngày bắt đầu");
            dgvContracts.Columns.Add("EndDate", "Ngày kết thúc");
            dgvContracts.Columns.Add("Deposit", "Tiền cọc");

            dgvContracts.Columns["Deposit"].DefaultCellStyle.Format = "N0";
        }

        /// <summary>
        /// Tải dữ liệu cho Tab Yêu cầu
        /// </summary>
        private void LoadPendingRequests()
        {
            _pendingRequests = _requestService.GetPendingRequestsByOwner(_ownerId);

            // --- SỬA TÊN: dgvRequests ---
            dgvRequests.Rows.Clear();

            foreach (var req in _pendingRequests)
            {
                dgvRequests.Rows.Add(
                    req.Renter?.Username ?? "N/A",
                    req.Room?.Name ?? "N/A",
                    req.DesiredStartDate.ToString("dd/MM/yyyy"),
                    req.DesiredDurationMonths,
                    req.Note
                );
                dgvRequests.Rows[dgvRequests.Rows.Count - 1].Tag = req.Id;
            }

            // Cập nhật tiêu đề Tab
            tabPendingRequests.Text = $"Yêu cầu đang chờ ({_pendingRequests.Count})";
        }

        /// <summary>
        /// Tải dữ liệu cho Tab Hợp đồng
        /// </summary>
        private void LoadActiveContracts()
        {
            _activeContracts = _contractService.GetAllActiveContractsByOwner(_ownerId);

            // --- SỬA TÊN: dgvContracts ---
            dgvContracts.Rows.Clear();

            foreach (var contract in _activeContracts)
            {
                dgvContracts.Rows.Add(
                    contract.Room?.Name ?? "N/A",
                    contract.Renter?.Username ?? "N/A",
                    contract.StartDate?.ToString("dd/MM/yyyy") ?? "N/A",
                    contract.EndDate?.ToString("dd/MM/yyyy") ?? "N/A",
                    contract.Deposit
                );
                dgvContracts.Rows[dgvContracts.Rows.Count - 1].Tag = contract.Id;
            }

            // Cập nhật tiêu đề Tab
            tabActiveContracts.Text = $"Hợp đồng đang hoạt động ({_activeContracts.Count})";
        }

        /// <summary>
        /// Nút "Tạo Hợp đồng" (Duyệt)
        /// </summary>
        private void BtnApprove_Click(object sender, EventArgs e)
        {
            // --- SỬA TÊN: dgvRequests ---
            if (dgvRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một yêu cầu để duyệt.");
                return;
            }

            Guid requestId = (Guid)dgvRequests.SelectedRows[0].Tag;
            var request = _pendingRequests.FirstOrDefault(r => r.Id == requestId);

            if (request == null) return;

            // Mở Form Tạo Hợp đồng
            using (FormCreateContract frm = new FormCreateContract(request))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Tải lại cả 2 danh sách
                    LoadData();
                }
            }
        }

        /// <summary>
        /// Nút "Từ chối"
        /// </summary>
        private void BtnReject_Click(object sender, EventArgs e)
        {
            // --- SỬA TÊN: dgvRequests ---
            if (dgvRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một yêu cầu để từ chối.");
                return;
            }

            Guid requestId = (Guid)dgvRequests.SelectedRows[0].Tag;

            bool success = _requestService.UpdateRequestStatus(requestId, "Rejected");
            if (success)
            {
                MessageBox.Show("Từ chối yêu cầu thành công.");
                LoadPendingRequests(); // Chỉ cần tải lại danh sách chờ
            }
        }

        /// <summary>
        /// Nút "Thanh lý" (Kết thúc HĐ)
        /// </summary>
        private void BtnEndContract_Click(object sender, EventArgs e)
        {
            if (dgvContracts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hợp đồng để kết thúc.");
                return;
            }

            Guid contractId = (Guid)dgvContracts.SelectedRows[0].Tag;

            var confirm = MessageBox.Show("Bạn có chắc muốn kết thúc hợp đồng này? Phòng sẽ được chuyển về trạng thái 'Còn trống'.",
                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                bool success = _contractService.EndContract(contractId);
                if (success)
                {
                    MessageBox.Show("Kết thúc hợp đồng thành công.");
                    LoadActiveContracts();
                }
            }
        }
    }
}