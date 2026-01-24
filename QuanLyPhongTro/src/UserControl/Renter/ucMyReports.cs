using QuanLyPhongTro.src.Services1;
using QuanLyPhongTro.src.Mediator;
using QuanLyPhongTro.src.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class ucMyReports : UserControl
    {
        private Contract _contract;
        private readonly ReportService _reportService;

        private List<Report> _allReports;
        private Report _selectedReport;

        private ucReportItem _currentSelectedItem = null;
        private bool _isLoaded = false;

        public ucMyReports()
        {
            InitializeComponent();
            this.Name = "UcMyReports";

            _reportService = new ReportService();

            Mediator.Instance.Register<Contract>("UcMyReports", (contract) =>
            {
                _contract = contract;
                if (_isLoaded) LoadData();
                return Task.CompletedTask;
            });

            this.Load += UcMyReports_Load;
            this.btnRefresh.Click += (s, e) => LoadData();
            this.btnCreateReport.Click += BtnCreateReport_Click;
            this.cboFilterStatus.SelectedIndexChanged += (s, e) => FilterReports();

            // Giữ item full width khi resize
            this.flpReports.SizeChanged += (s, e) => ResizeReportItemsWidth();
        }

        private void UcMyReports_Load(object sender, EventArgs e)
        {
            if (cboFilterStatus.Items.Count == 0)
            {
                cboFilterStatus.Items.AddRange(new object[] { "Tất cả", "Đang chờ", "Đang xử lý", "Đã giải quyết" });
            }
            cboFilterStatus.SelectedIndex = 0;

            _isLoaded = true;

            if (_contract != null && _contract.IdRenter.HasValue)
            {
                LoadData();
            }

            ClearDetailPanel();
        }

        public void LoadData()
        {
            if (_contract == null || !_contract.IdRenter.HasValue || !_isLoaded) return;

            _allReports = _reportService.GetReportsByRenter(_contract.IdRenter.Value);
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

            filteredList = filteredList.OrderByDescending(r => r.DateCreated).ToList();

            DisplayReportsList(filteredList);
        }

        private void DisplayReportsList(List<Report> reports)
        {
            flpReports.Controls.Clear();
            flpReports.SuspendLayout();

            _currentSelectedItem = null;
            _selectedReport = null;

            if (reports == null || reports.Count == 0)
            {
                ClearDetailPanel();
                flpReports.ResumeLayout();
                return;
            }

            foreach (var report in reports)
            {
                var item = new ucReportItem(report);

                item.Click += (s, e) => SelectReportItem(item);
                flpReports.Controls.Add(item);
            }

            flpReports.ResumeLayout();
            ResizeReportItemsWidth();

            // Auto select first item
            if (flpReports.Controls.Count > 0 && flpReports.Controls[0] is ucReportItem firstItem)
            {
                SelectReportItem(firstItem);
            }
        }

        private void ResizeReportItemsWidth()
        {
            // Trừ padding trái/phải + scrollbar margin nhỏ
            int w = Math.Max(0, flpReports.ClientSize.Width - flpReports.Padding.Left - flpReports.Padding.Right - 10);

            foreach (Control c in flpReports.Controls)
            {
                c.Width = w;
            }
        }

        private void SelectReportItem(ucReportItem item)
        {
            if (_currentSelectedItem != null)
            {
                _currentSelectedItem.SetSelected(false);
            }

            _currentSelectedItem = item;
            _currentSelectedItem.SetSelected(true);

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

            lblTitleDetail.Text = $"Tiêu đề: {report.Title ?? "N/A"}";

            string statusText = report.Status == "Pending" ? "Đang chờ"
                             : report.Status == "InProgress" ? "Đang xử lý"
                             : "Đã giải quyết";

            Color statusColor = report.Status == "Pending" ? Color.OrangeRed
                               : report.Status == "InProgress" ? Color.Orange
                               : Color.FromArgb(39, 174, 96);

            lblStatus.Text = $"Trạng thái: {statusText}";
            lblStatus.ForeColor = statusColor;

            lblRoom.Text = $"Từ: {report.IdRoomNavigation?.Name ?? "N/A"}";
            lblDate.Text = $"Ngày gửi: {(report.DateCreated.HasValue ? report.DateCreated.Value.ToString("dd/MM/yyyy HH:mm") : "N/A")}";
            txtDescription.Text = report.Description ?? string.Empty;
        }

        private void ClearDetailPanel()
        {
            lblTitleDetail.Text = "Tiêu đề: Chọn một thông báo để xem chi tiết";
            lblStatus.Text = "Trạng thái: ";
            lblStatus.ForeColor = Color.Black;
            lblRoom.Text = "Từ: ";
            lblDate.Text = "Ngày gửi: ";
            txtDescription.Text = string.Empty;
        }

        private void BtnCreateReport_Click(object sender, EventArgs e)
        {
            using (var frm = new FormCreateRenterReport(_contract))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
    }
}
