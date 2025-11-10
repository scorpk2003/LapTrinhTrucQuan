using QuanLyPhongTro.Model;
using QuanLyPhongTro.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class ucContractManagement : UserControl
    {
        private readonly Guid _ownerId;
        private readonly ContractService _contractService;
        private readonly BookingRequestService _requestService;

        private List<BookingRequest> _pendingRequests;
        private List<Contract> _activeContracts;

        public ucContractManagement(Guid ownerId)
        {
            InitializeComponent();
            _ownerId = ownerId;
            _contractService = new ContractService();
            _requestService = new BookingRequestService();

            this.Load += UcContractManagement_Load;
            this.btnRefresh.Click += (s, e) => LoadData();
            this.btnApprove.Click += BtnApprove_Click;
            this.btnReject.Click += BtnReject_Click;
            this.btnEndContract.Click += BtnEndContract_Click;
        }

        private void UcContractManagement_Load(object sender, EventArgs e)
        {
            SetupDataGridViews(); 
            LoadData();
        }

        public void LoadData()
        {
            LoadPendingRequests();
            LoadActiveContracts();
        }

        private void SetupDataGridViews()
        {
            dgvRequests.AutoGenerateColumns = false;
            dgvRequests.Columns.Clear();

            // Đặt chế độ tự động lấp đầy
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequests.RowHeadersVisible = false;

            // Thêm cột (với FillWeight để chia tỷ lệ)
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RoomName",
                HeaderText = "Phòng",
                FillWeight = 20 // 20% chiều rộng
            });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RenterName",
                HeaderText = "Người thuê",
                FillWeight = 20
            });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StartDate",
                HeaderText = "Ngày muốn thuê",
                FillWeight = 15
            });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Duration",
                HeaderText = "Thời hạn",
                FillWeight = 10
            });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Note",
                HeaderText = "Ghi chú",
                FillWeight = 35 // 35% (lớn nhất)
            });

            // === Cấu hình bảng Hợp đồng (dgvContracts) ===
            dgvContracts.AutoGenerateColumns = false;
            dgvContracts.Columns.Clear();

            // Đặt chế độ tự động lấp đầy
            dgvContracts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvContracts.RowHeadersVisible = false;

            dgvContracts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RoomName",
                HeaderText = "Phòng",
                FillWeight = 20
            });
            dgvContracts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RenterName",
                HeaderText = "Người thuê",
                FillWeight = 20
            });
            dgvContracts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StartDate",
                HeaderText = "Ngày bắt đầu",
                FillWeight = 15
            });
            dgvContracts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EndDate",
                HeaderText = "Ngày kết thúc",
                FillWeight = 15
            });
            dgvContracts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Deposit",
                HeaderText = "Tiền cọc",
                FillWeight = 30,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } // Định dạng tiền
            });
        }
        // --- HẾT PHẦN SỬA ---

        private void LoadPendingRequests()
        {
            _pendingRequests = _requestService.GetPendingRequestsByOwner(_ownerId);
            dgvRequests.Rows.Clear();

            foreach (var req in _pendingRequests)
            {
                dgvRequests.Rows.Add(
                    req.Room.Name,
                    req.Renter.Username,
                    req.DesiredStartDate.ToString("dd/MM/yyyy"),
                    $"{req.DesiredDurationMonths} tháng",
                    req.Note
                );
                dgvRequests.Rows[dgvRequests.Rows.Count - 1].Tag = req.Id;
            }
            tabPendingRequests.Text = $"Yêu cầu đang chờ ({_pendingRequests.Count})";
        }

        private void LoadActiveContracts()
        {
            _activeContracts = _contractService.GetAllActiveContractsByOwner(_ownerId);
            dgvContracts.Rows.Clear();

            foreach (var contract in _activeContracts)
            {
                dgvContracts.Rows.Add(
                    contract.Room.Name,
                    contract.Renter.Username,
                    contract.StartDate?.ToString("dd/MM/yyyy"),
                    contract.EndDate?.ToString("dd/MM/yyyy"),
                    $"{contract.Deposit:N0}" // Bỏ " VND" để dùng định dạng N0
                );
                dgvContracts.Rows[dgvContracts.Rows.Count - 1].Tag = contract.Id;
            }
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (dgvRequests.SelectedRows.Count == 0) return;

            Guid requestId = (Guid)dgvRequests.SelectedRows[0].Tag;
            var request = _pendingRequests.Find(r => r.Id == requestId);

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
            if (dgvRequests.SelectedRows.Count == 0) return;

            Guid requestId = (Guid)dgvRequests.SelectedRows[0].Tag;

            var confirm = MessageBox.Show("Bạn có chắc muốn từ chối yêu cầu này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                bool success = _requestService.UpdateRequestStatus(requestId, "Rejected");
                if (success)
                {
                    LoadData();
                }
            }
        }

        private void BtnEndContract_Click(object sender, EventArgs e)
        {
            if (dgvContracts.SelectedRows.Count == 0) return;

            Guid contractId = (Guid)dgvContracts.SelectedRows[0].Tag;

            var confirm = MessageBox.Show("Bạn có chắc muốn thanh lý hợp đồng này?\nPhòng sẽ được chuyển về trạng thái 'Còn trống'.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                bool success = _contractService.EndContract(contractId);
                if (success)
                {
                    LoadData();
                }
            }
        }
    }
}