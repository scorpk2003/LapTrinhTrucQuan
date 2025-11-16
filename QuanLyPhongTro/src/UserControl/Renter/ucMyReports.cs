using QuanLyPhongTro.Services;
using QuanLyPhongTro.src.Test.Mediator;
using QuanLyPhongTro.src.Test.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class ucMyReports : UserControl
    {
        private readonly ReportService _reportService;
        private Contract _contract;

        public ucMyReports()
        {
            InitializeComponent();
            _reportService = new ReportService();

            // Ensure columns exist even if mediator publishes early
            if (dgvReports.Columns.Count == 0)
                SetupDgv();

            Mediator.Instance.Register<Contract>("UcMyReports", (contract) =>
            {
                _contract = contract;
                if (dgvReports.Columns.Count == 0)
                    SetupDgv();
                LoadData();
                return Task.CompletedTask;
            });

            this.Load += UcMyReports_Load;
            this.btnCreateReport.Click += BtnCreateReport_Click;
        }

        private void UcMyReports_Load(object sender, EventArgs e)
        {
            if (dgvReports.Columns.Count == 0)
                SetupDgv();
        }

        private void SetupDgv()
        {
            dgvReports.AutoGenerateColumns = false;
            dgvReports.Columns.Clear();
            dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvReports.Columns.Add("Date", "Ngày gửi");
            dgvReports.Columns.Add("Title", "Tiêu đề");
            dgvReports.Columns.Add("Description", "Mô tả");
            dgvReports.Columns.Add("Status", "Trạng thái");
        }

        public void LoadData()
        {
            if (_contract == null || !_contract.IdRenter.HasValue) return;

            if (dgvReports.Columns.Count == 0)
                SetupDgv();

            var reports = _reportService.GetReportsByRenter(_contract.IdRenter.Value);
            dgvReports.Rows.Clear();

            foreach (var report in reports)
            {
                dgvReports.Rows.Add(
                    report.DateCreated.HasValue ? report.DateCreated.Value.ToString("dd/MM/yyyy") : "N/A",
                    
                    report.Title,
                    report.Description,
                    report.Status
                );
            }
        }

        private void BtnCreateReport_Click(object sender, EventArgs e)
        {
            using (FormCreateRenterReport frm = new FormCreateRenterReport(_contract))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
    }
}