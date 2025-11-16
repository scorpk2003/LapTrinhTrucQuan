using QuanLyPhongTro.Services;
using QuanLyPhongTro.src.Test.Mediator;
using QuanLyPhongTro.src.Test.Models;
using System;
using System.Collections.Generic;
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

        private bool _isLoaded = false;

        public ucIncidentManagement()
        {
            InitializeComponent();
            _reportService = new ReportService();
            _contractService = new ContractService();
            _ownerId = Guid.Empty;

            Mediator.Instance.Register<Person>("UcIncidentManagement", (owner) =>
            {
                _ownerId = owner.Id;
                if (_isLoaded)
                {
                    LoadData();
                    if (cboFilterStatus.Items.Count > 0)
                        cboFilterStatus.SelectedIndex = 1;
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
            SetupDgv();
            _isLoaded = true;
            if (_ownerId != Guid.Empty)
            {
                LoadData();
                if (cboFilterStatus.Items.Count > 0)
                    cboFilterStatus.SelectedIndex = 1;
            }
            if (cboFilterStatus.Items.Count > 0 && cboFilterStatus.SelectedIndex == -1)
            {
                cboFilterStatus.SelectedIndex = 0;
            }
        }

        public void LoadData()
        {
            if (_ownerId == Guid.Empty || !_isLoaded) return;
            _allReports = _reportService.GetReportsByOwner(_ownerId);
            FilterReports();
        }

        private async void FilterReports()
        {
            if (_allReports == null || !_isLoaded || cboFilterStatus.SelectedItem == null) return;

            string filter = cboFilterStatus.SelectedItem.ToString();
            List<Report> filteredList = _allReports;

            if (filter.Contains("Đang chờ"))
                filteredList = _allReports.Where(r => r.Status == "Pending").ToList();
            else if (filter.Contains("Đang xử lý"))
                filteredList = _allReports.Where(r => r.Status == "InProgress").ToList();
            else if (filter.Contains("Đã giải quyết"))
                filteredList = _allReports.Where(r => r.Status == "Resolved").ToList();

            await Mediator.Instance.PublishList<Report>("ucReport", filteredList, async (controls) =>
            {
                foreach (var control in controls)
                {
                    this.Controls.Add(control);
                }
            });

            //dgvIncidents.Rows.Clear();
            //foreach (var report in filteredList)
            //{
            //    dgvIncidents.Rows.Add(
            //        report.Status,
            //        report.IdRoomNavigation?.Name ?? "N/A",
            //        report.IdReporterNavigation?.Username ?? "N/A",
            //        report.Title,
            //        report.Description
            //    );
            //    dgvIncidents.Rows[dgvIncidents.Rows.Count - 1].Tag = report.Id;
            //}
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

        private void BtnRenew_Click(object sender, EventArgs e)
        {
            if (dgvIncidents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một yêu cầu.");
                return;
            }

            Guid reportId = (Guid)dgvIncidents.SelectedRows[0].Tag;
            var selectedReport = _allReports.FirstOrDefault(r => r.Id == reportId);
            if (selectedReport == null) return;

            if (selectedReport.Title != "Yêu cầu Gia hạn Hợp đồng")
            {
                MessageBox.Show("Đây không phải là Yêu cầu Gia hạn Hợp đồng.");
                return;
            }

            if (!selectedReport.IdRoom.HasValue)
            {
                MessageBox.Show("Báo cáo này không đính kèm phòng.");
                return;
            }

            int requestedMonths = ParseMonthsFromDescription(selectedReport.Description);
            if (requestedMonths == 0)
                requestedMonths = 6;

            using (FormRenewContract frm = new FormRenewContract(requestedMonths, "Duyệt Gia Hạn"))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int months = frm.MonthsToAdd;
                    Guid roomId = selectedReport.IdRoom.Value;

                    bool success = _contractService.RenewContract(roomId, months);
                    if (success)
                    {
                        _reportService.UpdateReportStatus(reportId, "Resolved");
                        
                        MessageBox.Show($"Gia hạn hợp đồng cho phòng {selectedReport.IdRoomNavigation.Name} thêm {months} tháng thành công!");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Gia hạn thất bại (Không tìm thấy hợp đồng 'Active' cho phòng này).");
                    }
                }
            }
        }

        private int ParseMonthsFromDescription(string description)
        {
            try
            {
                string[] words = description.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int index = Array.FindIndex(words, w => w.ToLower() == "thêm");

                if (index != -1 && index + 1 < words.Length)
                {
                    string numberStr = words[index + 1];
                    if (int.TryParse(numberStr, out int months))
                    {
                        return months;
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine($"ParseMonths Error: {ex.Message}"); }
            return 0;
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

            var report = _allReports.FirstOrDefault(r => r.Id == reportId);
            if (report != null &&
               report.Title == "Yêu cầu Gia hạn Hợp đồng" &&
               newStatus == "Resolved")
            {
                MessageBox.Show("Bạn phải dùng nút 'Duyệt Gia Hạn' để xử lý yêu cầu này.");
                return;
            }

            bool success = _reportService.UpdateReportStatus(reportId, newStatus);
            if (success)
            {
                LoadData();
            }
            else
            {
                MessageBox.Show("Cập nhật trạng thái thất bại.");
            }
        }
    }
}