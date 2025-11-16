using QuanLyPhongTro.Services;
using QuanLyPhongTro.src.Test.Mediator; 
using QuanLyPhongTro.src.Test.Models;
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
            // (Nút btnRenewContract chưa gán sự kiện)
        }

        private void UcContractManagement_Load(object sender, EventArgs e)
        {
            SetupDataGridViews();
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

        private async void LoadPendingRequests()
        {
            _pendingRequests = _requestService.GetPendingRequestsByOwner(_ownerId);

            await Mediator.Instance.PublishList<BookingRequest>("ucBooking", _pendingRequests, async (controls) =>
            {
                foreach (var control in controls)
                    this.Controls.Add(control);
            });
            //dgvRequests.Rows.Clear();
            //foreach (var req in _pendingRequests)
            //{
            //    dgvRequests.Rows.Add(
            //        req.Renter?.Username ?? "N/A",
            //        req.Room?.Name ?? "N/A",
            //        req.DesiredStartDate.ToString("dd/MM/yyyy"),
            //        req.DesiredDurationMonths,
            //        req.Note
            //    );
            //    dgvRequests.Rows[dgvRequests.Rows.Count - 1].Tag = req; 
            //}
            //tabPendingRequests.Text = $"Yêu cầu đang chờ ({_pendingRequests.Count})";
        }

        private async Task LoadActiveContracts()
        {
            _activeContracts = _contractService.GetAllActiveContractsByOwner(_ownerId);

            await Mediator.Instance.PublishList<Contract>("ucContract", _activeContracts, async (controls) =>
            {
                foreach (var control in controls)
                    this.Controls.Add(control);
            });

            //dgvContracts.Rows.Clear();
            //foreach (var contract in _activeContracts)
            //{
            //    dgvContracts.Rows.Add(
            //        contract.IdRoomNavigation?.Name ?? "N/A",
            //        contract.IdRenterNavigation?.Username ?? "N/A",
            //        contract.StartDate.HasValue ? contract.StartDate.Value.ToString("dd/MM/yyyy") : "N/A",
            //        contract.EndDate.HasValue ? contract.EndDate.Value.ToString("dd/MM/yyyy") : "N/A",
                    
            //        contract.Deposit
            //    );
            //    dgvContracts.Rows[dgvContracts.Rows.Count - 1].Tag = contract.Id;
            //}
            //tabActiveContracts.Text = $"Hợp đồng đang hoạt động ({_activeContracts.Count})";
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