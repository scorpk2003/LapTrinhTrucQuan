using QuanLyPhongTro.Model;
using QuanLyPhongTro.Services;
using QuanLyPhongTro.src.Mediator;
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

            // Đăng ký nhận Hợp đồng
            Mediator.Instance.Register<Contract>("UcMyReports", (contract) =>
            {
                _contract = contract;
                LoadData();
                return Task.CompletedTask;
            });

            this.Load += UcMyReports_Load;
            this.btnCreateReport.Click += BtnCreateReport_Click;
        }

        private void UcMyReports_Load(object sender, EventArgs e)
        {
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
            // Sửa lỗi Guid?: Kiểm tra .HasValue
            if (_contract == null || !_contract.IdRenter.HasValue) return;

            // Dùng .Value để lấy Guid thật
            var reports = _reportService.GetReportsByRenter(_contract.IdRenter.Value);

            dgvReports.Rows.Clear();

            foreach (var report in reports)
            {
                dgvReports.Rows.Add(
                    report.DateCreated.ToString("dd/MM/yyyy"),
                    report.Title,
                    report.Description,
                    report.Status
                );
            }
        }

        private void BtnCreateReport_Click(object sender, EventArgs e)
        {
            // Mở Form tạo mới
            using (FormCreateRenterReport frm = new FormCreateRenterReport(_contract))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Tải lại danh sách
                    LoadData();
                }
            }
        }
    }
}