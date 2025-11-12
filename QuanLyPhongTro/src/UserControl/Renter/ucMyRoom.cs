using QuanLyPhongTro.src.Test.Model;
using QuanLyPhongTro.src.Mediator; // <-- Thêm
using QuanLyPhongTro.src.Test.Services;
using ScottPlot; // v5
using System;
using System.Linq;
using System.Threading.Tasks; // <-- Thêm
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class ucMyRoom : UserControl
    {
        private Contract _contract; // <-- Xóa readonly
        private readonly BillService _billService;

        // --- SỬA: DÙNG CONSTRUCTOR RỖNG ---
        public ucMyRoom()
        {
            InitializeComponent();
            _billService = new BillService();

            // Đăng ký nhận Contract từ Mediator
            Mediator.Instance.Register<Contract>("UcMyRoom", (contract) =>
            {
                _contract = contract;
                LoadData(); // Tải dữ liệu khi nhận được Contract
                return Task.CompletedTask;
            });

            this.btnPay.Click += BtnPay_Click;
        }

        // Hàm LoadData chung
        private void LoadData()
        {
            if (_contract == null) return;

            LoadRoomInfo();
            LoadContractInfo();
            LoadLatestBill();
            LoadSpendingChart();
        }

        // (Không cần hàm Load, Mediator sẽ kích hoạt LoadData)

        private void LoadRoomInfo()
        {
            if (_contract.Room == null) return;
            lblRoomName.Text = _contract.Room.Name;
            lblRoomPrice.Text = $"Giá thuê: {_contract.Room.Price:N0} VND";
            lblRoomArea.Text = $"Diện tích: {_contract.Room.Area} m²";
            lblRoomAddress.Text = $"Địa chỉ: {_contract.Room.Address}";
        }

        private void LoadContractInfo()
        {
            lblStartDate.Text = $"Ngày bắt đầu: {_contract.StartDate:dd/MM/yyyy}";
            lblEndDate.Text = $"Ngày kết thúc: {_contract.EndDate:dd/MM/yyyy}";
            lblDeposit.Text = $"Tiền cọc: {_contract.Deposit:N0} VND";
        }

        private void LoadLatestBill()
        {
            // (Code Demo - Cần thay thế bằng logic BillService thật)
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            lblBillTitle.Text = $"Hóa đơn tháng {month}/{year}";
            lblBillTotal.Text = "Tổng: 1,850,000 VND";
            lblBillStatus.Text = "Trạng thái: Chưa thanh toán";
            btnPay.Enabled = true;
        }

        private void LoadSpendingChart()
        {
            // (Code Demo)
            spendingChart.Plot.Clear();
            double[] values = { 1.8, 1.9, 1.85, 2.0, 1.8, 1.9, 1.85, 2.0, 1.8, 1.9, 1.85, 2.0 };
            double[] positions = Enumerable.Range(0, 12).Select(i => (double)i).ToArray();
            var bars = spendingChart.Plot.Add.Bars(positions, values);

            string[] labels = { "T11", "T12", "T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10" };
            spendingChart.Plot.Axes.Bottom.SetTicks(positions, labels);
            spendingChart.Plot.Axes.SetLimits(left: -0.5, right: 11.5); // Căn giữa
            try { spendingChart.Plot.Axes.Left.Label.Text = "Chi tiêu (Triệu VND)"; } catch { }
            try { spendingChart.Plot.Title("Thống kê chi tiêu (Demo)"); } catch { }
            spendingChart.Refresh();
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mở cổng thanh toán (Momo, ZaloPay...)\nĐây là tính năng Demo.", "Thanh toán");
            lblBillStatus.Text = "Trạng thái: Đã thanh toán";
            btnPay.Enabled = false;
        }
    }
}