using QuanLyPhongTro.src.Models;
using QuanLyPhongTro.src.Services1;
using QuanLyPhongTro.src.Mediator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace QuanLyPhongTro
{
    public partial class ucPendingContracts : UserControl
    {
        private Guid _renterId;
        private readonly ContractService _contractService;
        private List<Contract> _pendingContracts;

        public ucPendingContracts()
        {
            InitializeComponent();
            this.Name = "UcPendingContracts";
            _contractService = new ContractService();

            SetupDataGridView();

            Mediator.Instance.Register<Contract>("UcPendingContracts", (contract) =>
            {
                _renterId = contract.IdRenter ?? Guid.Empty;
                LoadPendingContracts();
                return Task.CompletedTask;
            });

            this.btnRefresh.Click += (s, e) => LoadPendingContracts();
        }

        private void SetupDataGridView()
        {
            dgvPendingContracts.AutoGenerateColumns = false;
            dgvPendingContracts.Columns.Clear();
            dgvPendingContracts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvPendingContracts.Columns.Add("RoomName", "Phòng");
            dgvPendingContracts.Columns.Add("StartDate", "Ngày bắt đầu");
            dgvPendingContracts.Columns.Add("EndDate", "Ngày kết thúc");
            dgvPendingContracts.Columns.Add("Deposit", "Tiền cọc");

            dgvPendingContracts.Columns["Deposit"].DefaultCellStyle.Format = "N0";

            DataGridViewButtonColumn btnUpload = new DataGridViewButtonColumn
            {
                Name = "Upload",
                HeaderText = "Hành động",
                Text = "Upload ảnh",
                UseColumnTextForButtonValue = true,
                FillWeight = 80
            };
            dgvPendingContracts.Columns.Add(btnUpload);

            dgvPendingContracts.CellClick -= DgvPendingContracts_CellClick;
            dgvPendingContracts.CellClick += DgvPendingContracts_CellClick;

            dgvPendingContracts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvPendingContracts.ColumnHeadersHeight = 60;

            dgvPendingContracts.EnableHeadersVisualStyles = false;

            dgvPendingContracts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // Màu nền nhẹ cho chuyên nghiệp
            dgvPendingContracts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvPendingContracts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvPendingContracts.RowTemplate.Height = 60;
            dgvPendingContracts.DefaultCellStyle.Padding = new Padding(5);
            dgvPendingContracts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPendingContracts.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
            dgvPendingContracts.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvPendingContracts.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
        }

        private void LoadPendingContracts()
        {
            if (_renterId == Guid.Empty) return;

            _pendingContracts = _contractService.GetPendingContractsByRenter(_renterId);
            dgvPendingContracts.Rows.Clear();

            if (_pendingContracts == null || _pendingContracts.Count == 0)
            {
                lblInfo.Text = "Không có hợp đồng nào cần upload ảnh.";
                lblInfo.ForeColor = Color.Gray;
                return;
            }

            lblInfo.Text = $"⚠️ Bạn có {_pendingContracts.Count} hợp đồng chờ upload ảnh để kích hoạt.";
            lblInfo.ForeColor = Color.OrangeRed;

            foreach (var contract in _pendingContracts)
            {
                int row = dgvPendingContracts.Rows.Add(
                    contract.IdRoomNavigation?.Name ?? "N/A",
                    contract.StartDate.HasValue ? contract.StartDate.Value.ToString("dd/MM/yyyy") : "N/A",
                    contract.EndDate.HasValue ? contract.EndDate.Value.ToString("dd/MM/yyyy") : "N/A",
                    contract.Deposit ?? 0
                );

                dgvPendingContracts.Rows[row].Tag = contract;
            }
        }

        private void DgvPendingContracts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvPendingContracts.Columns[e.ColumnIndex].Name == "Upload")
            {
                var contract = (Contract)dgvPendingContracts.Rows[e.RowIndex].Tag;
                if (contract == null) return;

                using (var formUpload = new FormUploadContractImage(contract))
                {
                    if (formUpload.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show(
                            "Hợp đồng đã được kích hoạt thành công!\n\n" +
                            "Bạn có thể bắt đầu sử dụng các tính năng quản lý phòng trọ.",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        var mainForm = this.FindForm();
                        if (mainForm is Renter_TrangChu renterForm)
                        {
                            renterForm.ReloadAfterContractActivation();
                        }
                    }
                }
            }
        }
    }
}
