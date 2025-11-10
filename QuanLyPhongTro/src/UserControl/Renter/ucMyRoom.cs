using QuanLyPhongTro.src.Model;
using QuanLyPhongTro.src.Services;
using ScottPlot; // v5
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class ucMyRoom : UserControl
    {
        private readonly Contract _contract;
        private readonly BillService _billService;

        public ucMyRoom(Contract activeContract)
        {
            InitializeComponent();
            _contract = activeContract;
            _billService = new BillService();

            this.Load += UcMyRoom_Load;
            this.btnPay.Click += BtnPay_Click;
        }

        private void UcMyRoom_Load(object sender, EventArgs e)
        {
            LoadRoomInfo();
            LoadContractInfo();
            LoadLatestBill();
            LoadSpendingChart();
        }

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
            // (Bạn cần tạo hàm GetLatestBillByRenter trong BillService)
            // Giả lập: Lấy hóa đơn tháng này
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            // (Giả sử bạn có hàm này)
            // Bill latestBill = _billService.GetBillByRenter(_contract.IdRenter, month, year);

            // --- Code Demo (thay thế sau) ---
            lblBillTitle.Text = $"Hóa đơn tháng {month}/{year}";
            lblBillTotal.Text = "Tổng: 1,850,000 VND";
            lblBillStatus.Text = "Trạng thái: Chưa thanh toán";
            btnPay.Enabled = true;
            // --- Hết Code Demo ---
        }

        private void LoadSpendingChart()
        {
            // (Mục #10: Biểu đồ chi tiêu)
            // (Bạn cần hàm Service để lấy chi tiêu 12 tháng qua)

            // --- Code Demo (thay thế sau) ---
            spendingChart.Plot.Clear();
            double[] values = { 1.8, 1.9, 1.85, 2.0, 1.8, 1.9, 1.85, 2.0, 1.8, 1.9, 1.85, 2.0 };
            double[] positions = Enumerable.Range(0, 12).Select(i => (double)i).ToArray();
            var bars = spendingChart.Plot.Add.Bars(positions, values);

            string[] labels = { "T11", "T12", "T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10" };
            spendingChart.Plot.Axes.Bottom.SetTicks(positions, labels);
            try { spendingChart.Plot.Axes.Left.Label.Text = "Chi tiêu (Triệu VND)"; } catch { }
            try { spendingChart.Plot.Title("Thống kê chi tiêu (Demo)"); } catch { }
            spendingChart.Refresh();
            // --- Hết Code Demo ---
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            // (Mục #2: Thanh toán Online)
            MessageBox.Show("Mở cổng thanh toán (Momo, ZaloPay...)\nĐây là tính năng Demo.", "Thanh toán");
            // (Sau khi thanh toán thành công)
            lblBillStatus.Text = "Trạng thái: Đã thanh toán";
            btnPay.Enabled = false;
        }
    }
}