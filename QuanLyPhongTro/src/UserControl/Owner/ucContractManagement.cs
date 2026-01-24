using QuanLyPhongTro.src.Services1;
using QuanLyPhongTro.src.Mediator; 
using QuanLyPhongTro.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.IdentityModel.Tokens;

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

            SetupDataGridViews();

            Mediator.Instance.Register<Person>("UcContractManagement", (owner) =>
            {
                _ownerId = owner.Id;
                if (_isLoaded) LoadData();
                return Task.CompletedTask;
            });

            this.Load += UcContractManagement_Load;
            this.btnRefresh.Click += (s, e) => LoadData();
            this.btnApprove.Click += BtnApprove_Click;
            this.btnReject.Click += BtnReject_Click;
            this.btnEndContract.Click += BtnEndContract_Click;
        }

        private void UcContractManagement_Load(object sender, EventArgs e)
        {
            _isLoaded = true;
            if (_ownerId != Guid.Empty)
            {
                LoadData();
            }
        }

        public void LoadData()
        {
            if (_ownerId == Guid.Empty || !_isLoaded) return;
            LoadPendingRequests();
            LoadActiveContracts();
        }

        private void SetupDataGridViews()
        {
            dgvRequests.AutoGenerateColumns = false;
            dgvRequests.Columns.Clear();
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvRequests.Columns.Add("RenterName", "Người gửi");
            dgvRequests.Columns.Add("RoomName", "Phòng muốn thuê");
            dgvRequests.Columns.Add("StartDate", "Ngày muốn vào");
            dgvRequests.Columns.Add("Duration", "Thời hạn (tháng)");
            dgvRequests.Columns.Add("Note", "Ghi chú");

            dgvRequests.RowTemplate.Height = 60;
            dgvRequests.DefaultCellStyle.Padding = new Padding(5);
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.DefaultCellStyle.Font = new Font("Segoe UI", 11F);

            dgvRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvRequests.ColumnHeadersHeight = 60;
            dgvRequests.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            dgvRequests.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRequests.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvRequests.EnableHeadersVisualStyles = false;
            dgvRequests.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;


            dgvContracts.AutoGenerateColumns = false;
            dgvContracts.Columns.Clear();
            dgvContracts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvContracts.Columns.Add("RoomName", "Phòng");
            dgvContracts.Columns.Add("RenterName", "Người thuê");
            dgvContracts.Columns.Add("StartDate", "Ngày bắt đầu");
            dgvContracts.Columns.Add("EndDate", "Ngày kết thúc");
            dgvContracts.Columns.Add("Deposit", "Tiền cọc");

            dgvContracts.Columns["Deposit"].DefaultCellStyle.Format = "N0";

            dgvContracts.RowTemplate.Height = 60;
            dgvContracts.DefaultCellStyle.Padding = new Padding(5);
            dgvContracts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvContracts.DefaultCellStyle.Font = new Font("Segoe UI", 11F);

            dgvContracts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvContracts.ColumnHeadersHeight = 60;
            dgvContracts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            dgvContracts.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvContracts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvContracts.EnableHeadersVisualStyles = false;
            dgvContracts.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
        }

        private void LoadPendingRequests()
        {
            _pendingRequests = _requestService.GetPendingRequestsByOwner(_ownerId);
            dgvRequests.Rows.Clear();

            if (_pendingRequests == null || _pendingRequests.Count == 0)
            {
                tabPendingRequests.Text = "Yêu cầu đang chờ (0)";
                return;
            }

            foreach (var req in _pendingRequests)
            {
                int row = dgvRequests.Rows.Add(
                    req.Renter?.Username ?? "N/A",
                    req.Room?.Name ?? "N/A",
                    req.DesiredStartDate.ToString("dd/MM/yyyy"),
                    req.DesiredDurationMonths,
                    req.Note ?? string.Empty
                );
                dgvRequests.Rows[row].Tag = req;
            }
            dgvRequests.AutoResizeRows();
            tabPendingRequests.Text = $"Yêu cầu đang chờ ({_pendingRequests.Count})";
        }

        private async Task LoadActiveContracts()
        {
            _activeContracts = _contractService.GetAllActiveContractsByOwner(_ownerId);
            dgvContracts.Rows.Clear();

            if (_activeContracts == null || _activeContracts.Count == 0)
            {
                tabActiveContracts.Text = "Hợp đồng đang hoạt động (0)";
                return;
            }

            foreach (var c in _activeContracts)
            {
                int row = dgvContracts.Rows.Add(
                    c.IdRoomNavigation?.Name ?? "N/A",
                    c.IdRenterNavigation?.Username ?? "N/A",
                    c.StartDate.HasValue ? c.StartDate.Value.ToString("dd/MM/yyyy") : "N/A",
                    c.EndDate.HasValue ? c.EndDate.Value.ToString("dd/MM/yyyy") : "N/A",
                    c.Deposit ?? 0
                );
                dgvContracts.Rows[row].Tag = c.Id;
            }
            dgvContracts.AutoResizeRows();
            tabActiveContracts.Text = $"Hợp đồng đang hoạt động ({_activeContracts.Count})";
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một yêu cầu để duyệt."); 
                return;
            }

            BookingRequest request = (BookingRequest)dgvRequests.SelectedRows[0].Tag;
            if (request == null) return;

            using (FormCreateContract frm = new FormCreateContract(request))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void BtnReject_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một yêu cầu để từ chối.");
                return;
            }

            BookingRequest request = (BookingRequest)dgvRequests.SelectedRows[0].Tag;

            bool success = _requestService.UpdateRequestStatus(request.Id, "Rejected");
            if (success)
            {
                MessageBox.Show("Từ chối yêu cầu thành công.");
                LoadPendingRequests();
            }
        }

        private void BtnEndContract_Click(object sender, EventArgs e)
        {
            if (dgvContracts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hợp đồng để kết thúc.");
                return;
            }
            Guid contractId = (Guid)dgvContracts.SelectedRows[0].Tag;

            var confirm = MessageBox.Show("Bạn có chắc muốn kết thúc hợp đồng này? Phòng sẽ được chuyển về trạng thái 'Trống'.",
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