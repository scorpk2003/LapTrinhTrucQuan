using QuanLyPhongTro.src.Mediator;
using QuanLyPhongTro.src.Test.Model;
using QuanLyPhongTro.src.Test.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class ucMyContract : UserControl
    {
        private Contract _contract;
        private readonly ReportService _reportService;

        public ucMyContract()
        {
            InitializeComponent();
            _reportService = new ReportService();

            Mediator.Instance.Register<Contract>("UcMyContract", (contract) =>
            {
                _contract = contract;
                LoadData();
                return Task.CompletedTask;
            });

            this.btnRequestRenewal.Click += BtnRequestRenewal_Click;
            this.btnRequestTermination.Click += BtnRequestTermination_Click;
        }

        public void LoadData()
        {
            if (_contract == null) return;
            lblStartDate.Text = $"Ngày bắt đầu: {_contract.StartDate:dd/MM/yyyy}";
            lblEndDate.Text = $"Ngày kết thúc: {_contract.EndDate:dd/MM/yyyy}";
            lblDeposit.Text = $"Tiền cọc: {_contract.Deposit:N0} VND";
        }

        // Gửi yêu cầu Gia hạn (Đã sửa)
        private void BtnRequestRenewal_Click(object sender, EventArgs e)
        {
            // Mở Form hỏi số tháng
            using (FormRenewContract frm = new FormRenewContract(12, "Gửi Yêu cầu Gia hạn"))
            {
                // Nếu người thuê nhấn "Xác nhận"
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int months = frm.MonthsToAdd;

                    // Gửi yêu cầu với số tháng cụ thể
                    SendRequest("Yêu cầu Gia hạn Hợp đồng",
                        $"Tôi muốn gia hạn hợp đồng thêm {months} tháng.");
                }
            }
        }

        // Gửi yêu cầu Chấm dứt
        private void BtnRequestTermination_Click(object sender, EventArgs e)
        {
            SendRequest("Yêu cầu Chấm dứt Hợp đồng",
                "Tôi muốn chấm dứt hợp đồng vào ngày cuối tháng này.");
        }

        private void SendRequest(string title, string description)
        {
            var confirm = MessageBox.Show($"Bạn có chắc muốn gửi '{title}' đến chủ trọ?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.No) return;

            if (!_contract.IdRoom.HasValue || !_contract.IdRenter.HasValue)
            {
                MessageBox.Show("Lỗi: Hợp đồng không liên kết với phòng hoặc người thuê.");
                return;
            }

            var report = new Report
            {
                Title = title,
                Description = description,
                IdRoom = _contract.IdRoom.Value,
                IdReporter = _contract.IdRenter.Value,
                Status = "Pending"
            };

            bool success = _reportService.CreateReport(report);
            if (success)
                MessageBox.Show("Gửi yêu cầu thành công!", "Thành công");
            else
                MessageBox.Show("Gửi yêu cầu thất bại.", "Lỗi");
        }
    }
}