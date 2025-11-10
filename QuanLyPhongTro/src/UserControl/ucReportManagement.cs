using QuanLyPhongTro.Model;
using QuanLyPhongTro.Services;
using ScottPlot; // v5
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class ucReportManagement : UserControl
    {
        private readonly Guid _ownerId;
        private readonly DashboardService _dashboardService;

        public ucReportManagement(Guid ownerId)
        {
            InitializeComponent();
            _ownerId = ownerId;
            _dashboardService = new DashboardService();

            this.Load += UcReportManagement_Load;
            this.btnRefresh.Click += (s, e) => LoadData();
            this.cboYear.SelectedIndexChanged += (s, e) => LoadRevenueChart();
        }

        private void UcReportManagement_Load(object sender, EventArgs e)
        {
            // Nạp dữ liệu cho ComboBox Năm
            int currentYear = DateTime.Now.Year;
            cboYear.Items.Add(currentYear - 2);
            cboYear.Items.Add(currentYear - 1);
            cboYear.Items.Add(currentYear);
            cboYear.SelectedItem = currentYear;

            SetupDgv();
        }

        /// <summary>
        /// Hàm này được Owner_TrangChu gọi
        /// </summary>
        public void LoadData()
        {
            LoadRevenueChart();
            LoadOccupancyChart();
            LoadUnpaidBills();
        }

        private void SetupDgv()
        {
            dgvUnpaidBills.AutoGenerateColumns = false;
            dgvUnpaidBills.Columns.Clear();
            dgvUnpaidBills.Columns.Add("RoomName", "Phòng");
            dgvUnpaidBills.Columns.Add("RenterName", "Người thuê");
            dgvUnpaidBills.Columns.Add("DueDate", "Hạn thanh toán");
            dgvUnpaidBills.Columns.Add("Amount", "Số tiền");
            dgvUnpaidBills.Columns.Add("Status", "Trạng thái");

            dgvUnpaidBills.Columns["Amount"].DefaultCellStyle.Format = "N0";
            dgvUnpaidBills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// 1. Vẽ Biểu đồ Doanh thu (Bar Chart)
        /// </summary>
        private void LoadRevenueChart()
        {
            if (cboYear.SelectedItem == null) return;
            int year = (int)cboYear.SelectedItem;

            var monthlyData = _dashboardService.GetMonthlyRevenue(_ownerId, year) ?? new Dictionary<string, decimal>();

            revenueChart.Plot.Clear();

            // tạo dữ liệu 12 tháng theo thứ tự
            double[] values = new double[12];
            for (int m = 1; m <= 12; m++)
            {
                if (monthlyData.TryGetValue(m.ToString(), out var val))
                    values[m - 1] = (double)val;
                else if (monthlyData.TryGetValue(m.ToString("00"), out var val2))
                    values[m - 1] = (double)val2;
                else
                    values[m - 1] = 0;
            }

            // Vị trí cột 0..11
            double[] positions = Enumerable.Range(0, 12).Select(i => (double)i).ToArray();
            var bars = revenueChart.Plot.Add.Bars(positions, values);

            string[] labels = { "T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10", "T11", "T12" };
            revenueChart.Plot.Axes.Bottom.SetTicks(positions, labels);
            try { revenueChart.Plot.Axes.Left.Label.Text = "Doanh thu (VND)"; } catch { }
            try { revenueChart.Plot.Title($"Doanh thu năm {year}"); } catch { }

            revenueChart.Refresh();
        }

        /// <summary>
        /// 2. Vẽ Biểu đồ Tỷ lệ Lấp đầy (Pie Chart)
        /// </summary>
        private void LoadOccupancyChart()
        {
            (int occupied, int total) = _dashboardService.GetOccupancyStats(_ownerId);
            int available = total - occupied;
            occupancyChart.Plot.Clear();

            if (total > 0)
            {
                double[] values = { (double)occupied, (double)available };
                var pie = occupancyChart.Plot.Add.Pie(values);
                // Không set thuộc tính không tương thích để tránh lỗi biên dịch v5
            }

            try { occupancyChart.Plot.Title($"Tỷ lệ lấp đầy (Tổng: {total} phòng)"); } catch { }
            occupancyChart.Refresh();
        }

        /// <summary>
        /// 3. Hiển thị Báo cáo nợ đọng
        /// </summary>
        private void LoadUnpaidBills()
        {
            var unpaidBills = _dashboardService.GetUnpaidBills(_ownerId) ?? new List<Bill>();
            dgvUnpaidBills.Rows.Clear();

            foreach (var bill in unpaidBills)
            {
                dgvUnpaidBills.Rows.Add(
                    bill.Room?.Name ?? "N/A",
                    bill.Person?.Username ?? "N/A",
                    bill.PaymentDate.ToString("dd/MM/yyyy"),
                    bill.TotalMoney,
                    bill.Status ?? string.Empty
                );
            }
        }
    }
}