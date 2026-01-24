using QuanLyPhongTro.Services;
using QuanLyPhongTro.src.Test.Mediator;
using QuanLyPhongTro.src.Test.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class ucIncidentManagement : UserControl
    {
        private Guid _ownerId;
        private readonly ReportService _reportService;
        private readonly ContractService _contractService;
        private List<Report> _allReports;
        private Report _selectedReport;

        // Quản lý Item đang được chọn trong FlowLayoutPanel
        private ucIncidentItem _currentSelectedItem = null;

        private bool _isLoaded = false;

        public ucIncidentManagement()
        {
            InitializeComponent();
            this.Name = "UcIncidentManagement";

            _reportService = new ReportService();
            _contractService = new ContractService();
            _ownerId = Guid.Empty;

            Mediator.Instance.Register<Person>("UcIncidentManagement", (owner) =>
            {
                _ownerId = owner.Id;
                if (_isLoaded)
                {
                    LoadData();
                }
                return Task.CompletedTask;
            });

            this.Load += UcIncidentManagement_Load;
            this.btnRefresh.Click += (s, e) => LoadData();
            this.cboFilterStatus.SelectedIndexChanged += (s, e) => FilterReports();

            this.btnInProgress.Click += BtnInProgress_Click;
            this.btnResolve.Click += BtnResolve_Click;
            this.btnRenew.Click += BtnRenew_Click;
        }

        private void UcIncidentManagement_Load(object sender, EventArgs e)
        {
            if (cboFilterStatus.Items.Count == 0)
            {
                cboFilterStatus.Items.AddRange(new object[] { "Tất cả", "Đang chờ", "Đang xử lý", "Đã giải quyết" });
                cboFilterStatus.SelectedIndex = 0;
            }

            _isLoaded = true;

            if (_ownerId != Guid.Empty)
            {
                LoadData();
            }

            ClearDetailPanel();
        }

        public void LoadData()
        {
            if (_ownerId == Guid.Empty || !_isLoaded) return;

            _allReports = _reportService.GetReportsByOwner(_ownerId);
            FilterReports();
        }

        private void FilterReports()
        {
            if (_allReports == null || !_isLoaded) return;

            string filter = cboFilterStatus.SelectedItem?.ToString() ?? "Tất cả";
            List<Report> filteredList = _allReports;

            if (filter == "Đang chờ")
                filteredList = _allReports.Where(r => r.Status == "Pending").ToList();
            else if (filter == "Đang xử lý")
                filteredList = _allReports.Where(r => r.Status == "InProgress").ToList();
            else if (filter == "Đã giải quyết")
                filteredList = _allReports.Where(r => r.Status == "Resolved").ToList();

            DisplayReportsList(filteredList);
        }

        private void DisplayReportsList(List<Report> reports)
        {
            flpReports.Controls.Clear();
            flpReports.SuspendLayout();

            if (reports == null || reports.Count == 0)
            {
                ClearDetailPanel();
                flpReports.ResumeLayout();
                return;
            }

            foreach (var report in reports)
            {
                ucIncidentItem item = new ucIncidentItem(report);
                item.Click += (s, e) => {
                    SelectIncidentItem(item);
                };

                flpReports.Controls.Add(item);
            }

            flpReports.ResumeLayout();
        }

        private void SelectIncidentItem(ucIncidentItem item)
        {
            // Bỏ chọn thẻ cũ
            if (_currentSelectedItem != null)
            {
                _currentSelectedItem.SetSelected(false);
            }

            // Highlight thẻ mới
            _currentSelectedItem = item;
            _currentSelectedItem.SetSelected(true);

            // Gán dữ liệu cho phần chi tiết bên phải
            _selectedReport = item.ReportData;
            DisplayReportDetail(_selectedReport);
        }

        private void DisplayReportDetail(Report report)
        {
            if (report == null)
            {
                ClearDetailPanel();
                return;
            }

            lblTitle.Text = $"Tiêu đề: {report.Title ?? "N/A"}";

            string statusText = report.Status == "Pending" ? "Đang chờ" :
                               report.Status == "InProgress" ? "Đang xử lý" : "Đã giải quyết";

            Color statusColor = report.Status == "Pending" ? Color.OrangeRed :
                               report.Status == "InProgress" ? Color.Orange : Color.FromArgb(39, 174, 96);

            lblStatus.Text = $"Trạng thái: {statusText}";
            lblStatus.ForeColor = statusColor;

            lblReporter.Text = $"Người gửi: {report.IdReporterNavigation?.Username ?? "N/A"}";
            lblRoom.Text = $"Phòng: {report.IdRoomNavigation?.Name ?? "N/A"}";
            lblDate.Text = $"Ngày gửi: {(report.DateCreated.HasValue ? report.DateCreated.Value.ToString("dd/MM/yyyy HH:mm") : "N/A")}";
            txtDescription.Text = report.Description ?? string.Empty;

            // Xử lý logic nút bấm
            bool isRenewRequest = report.Title == "Yêu cầu Gia hạn Hợp đồng";
            btnRenew.Visible = isRenewRequest && report.Status != "Resolved";
            btnInProgress.Enabled = report.Status == "Pending";
            btnResolve.Enabled = report.Status == "InProgress" || (report.Status == "Pending" && !isRenewRequest);
        }

        private void ClearDetailPanel()
        {
            lblTitle.Text = "Tiêu đề: Chọn một thông báo để xem chi tiết";
            lblStatus.Text = "Trạng thái: ";
            lblReporter.Text = "Người gửi: ";
            lblRoom.Text = "Phòng: ";
            lblDate.Text = "Ngày gửi: ";
            txtDescription.Text = string.Empty;

            btnInProgress.Enabled = false;
            btnResolve.Enabled = false;
            btnRenew.Visible = false;
        }

        private void UpdateSelectedReportStatus(string newStatus)
        {
            if (_selectedReport == null)
            {
                MessageBox.Show("Vui lòng chọn một báo cáo để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = _reportService.UpdateReportStatus(_selectedReport.Id, newStatus);
            if (success)
            {
                // Cập nhật trạng thái trong object hiện tại
                _selectedReport.Status = newStatus;

                // Cập nhật trong danh sách _allReports
                var reportInList = _allReports?.FirstOrDefault(r => r.Id == _selectedReport.Id);
                if (reportInList != null)
                {
                    reportInList.Status = newStatus;
                }

                // Cập nhật UI của item đang chọn
                if (_currentSelectedItem != null)
                {
                    _currentSelectedItem.UpdateStatus(newStatus);
                }

                // Refresh lại panel chi tiết để cập nhật nút và màu sắc
                DisplayReportDetail(_selectedReport);

                // Kiểm tra xem item có còn trong filter hiện tại không
                string currentFilter = cboFilterStatus.SelectedItem?.ToString() ?? "Tất cả";
                bool shouldReloadList = false;

                if (currentFilter == "Đang chờ" && newStatus != "Pending")
                    shouldReloadList = true;
                else if (currentFilter == "Đang xử lý" && newStatus != "InProgress")
                    shouldReloadList = true;
                else if (currentFilter == "Đã giải quyết" && newStatus != "Resolved")
                    shouldReloadList = true;

                // Nếu item không còn phù hợp với filter, reload danh sách
                if (shouldReloadList)
                {
                    FilterReports();
                }

                MessageBox.Show("Cập nhật trạng thái thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật trạng thái thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnInProgress_Click(object sender, EventArgs e) => UpdateSelectedReportStatus("InProgress");
        
        private void BtnResolve_Click(object sender, EventArgs e)
        {
            if (_selectedReport?.Title == "Yêu cầu Gia hạn Hợp đồng")
            {
                MessageBox.Show("Vui lòng dùng nút 'Duyệt Gia Hạn'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UpdateSelectedReportStatus("Resolved");
        }

        private void BtnRenew_Click(object sender, EventArgs e)
        {
            if (_selectedReport == null || !_selectedReport.IdRoom.HasValue) return;

            int requestedMonths = ParseMonthsFromDescription(_selectedReport.Description);
            if (requestedMonths == 0) requestedMonths = 6;

            using (FormRenewContract frm = new FormRenewContract(requestedMonths, "Duyệt Gia Hạn"))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    bool success = _contractService.RenewContract(_selectedReport.IdRoom.Value, frm.MonthsToAdd);
                    if (success)
                    {
                        UpdateSelectedReportStatus("Resolved");
                        MessageBox.Show("Gia hạn hợp đồng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Gia hạn hợp đồng thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private int ParseMonthsFromDescription(string description)
        {
            if (string.IsNullOrEmpty(description)) return 0;
            try
            {
                string[] words = description.Split(' ');
                int index = Array.FindIndex(words, w => w.ToLower() == "thêm");
                if (index != -1 && index + 1 < words.Length)
                    if (int.TryParse(words[index + 1], out int m)) return m;
            }
            catch { }
            return 0;
        }
    }
}