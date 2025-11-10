using QuanLyPhongTro.Model;
using QuanLyPhongTro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class ucIncidentManagement : UserControl
    {
        private readonly Guid _ownerId;
        private readonly ReportService _reportService;
        private List<Report> _allReports; // Lưu danh sách gốc

        public ucIncidentManagement(Guid ownerId)
        {
            InitializeComponent();
            _ownerId = ownerId;
            _reportService = new ReportService();

            // Ensure a non-null selection early to avoid SelectedItem == null
            cboFilterStatus.SelectedIndex = 0;

            this.Load += UcIncidentManagement_Load;
            this.btnRefresh.Click += (s, e) => LoadData();

            // Gán sự kiện cho các nút
            this.cboFilterStatus.SelectedIndexChanged += (s, e) => FilterReports();
            this.btnInProgress.Click += BtnInProgress_Click;
            this.btnResolve.Click += BtnResolve_Click;
        }

        private void UcIncidentManagement_Load(object sender, EventArgs e)
        {
            SetupDgv();
            LoadData();
        }

        private void SetupDgv()
        {
            dgvIncidents.AutoGenerateColumns = false;
            dgvIncidents.Columns.Clear();
            dgvIncidents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIncidents.RowHeadersVisible = false;

            dgvIncidents.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Status", HeaderText = "Trạng thái", FillWeight = 15 });
            dgvIncidents.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "RoomName", HeaderText = "Phòng", FillWeight = 15 });
            dgvIncidents.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Reporter", HeaderText = "Người gửi", FillWeight = 15 });
            dgvIncidents.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Title", HeaderText = "Tiêu đề", FillWeight = 20 });
            dgvIncidents.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Description", HeaderText = "Mô tả", FillWeight = 35 });
        }

        /// <summary>
        /// Tải dữ liệu gốc từ CSDL
        /// </summary>
        public void LoadData()
        {
            _allReports = _reportService.GetReportsByOwner(_ownerId) ?? new List<Report>();
            FilterReports(); // Hiển thị
        }

        /// <summary>
        /// Lọc và hiển thị danh sách
        /// </summary>
        private void FilterReports()
        {
            if (_allReports == null) return; // Safety, though we coalesce to list
            if (cboFilterStatus?.SelectedItem == null) return; // Prevent NRE when UI not ready

            string filter = cboFilterStatus.SelectedItem.ToString();
            List<Report> filteredList = _allReports;

            if (filter.Contains("Đang chờ"))
                filteredList = _allReports.Where(r => r.Status == "Pending").ToList();
            else if (filter.Contains("Đang xử lý"))
                filteredList = _allReports.Where(r => r.Status == "InProgress").ToList();
            else if (filter.Contains("Đã giải quyết"))
                filteredList = _allReports.Where(r => r.Status == "Resolved").ToList();

            // Hiển thị
            dgvIncidents.Rows.Clear();
            foreach (var report in filteredList)
            {
                dgvIncidents.Rows.Add(
                    report.Status,
                    report.Room?.Name ?? "N/A",
                    report.Reporter?.Username ?? "N/A",
                    report.Title,
                    report.Description
                );
                dgvIncidents.Rows[dgvIncidents.Rows.Count - 1].Tag = report.Id;
            }
        }

        private void BtnInProgress_Click(object sender, EventArgs e)
        {
            UpdateSelectedReportStatus("InProgress");
        }

        private void BtnResolve_Click(object sender, EventArgs e)
        {
            UpdateSelectedReportStatus("Resolved");
        }

        private void UpdateSelectedReportStatus(string newStatus)
        {
            if (dgvIncidents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một báo cáo để cập nhật.");
                return;
            }

            Guid reportId = (Guid)dgvIncidents.SelectedRows[0].Tag;
            bool success = _reportService.UpdateReportStatus(reportId, newStatus);
            if (success)
            {
                LoadData(); // Tải lại
            }
            else
            {
                MessageBox.Show("Cập nhật trạng thái thất bại.");
            }
        }
    }
}