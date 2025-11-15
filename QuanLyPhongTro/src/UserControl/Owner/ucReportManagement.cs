using QuanLyPhongTro.src.Mediator;
using QuanLyPhongTro.Model;
using QuanLyPhongTro.Services; 
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class ucReportManagement : UserControl
    {
        private Guid _ownerId;
        private readonly DashboardService _dashboardService;

        public ucReportManagement()
        {
            InitializeComponent();
            _dashboardService = new DashboardService();
            _ownerId = Guid.Empty;

            Mediator.Instance.Register<Person>("UcReportManagement", (owner) =>
            {
                _ownerId = owner.Id;

                if (cboYear.Items.Count > 0)
                {
                    cboYear.SelectedItem = DateTime.Now.Year;
                }
                LoadData(); 

                return Task.CompletedTask;
            });

            this.Load += UcReportManagement_Load;
            this.btnRefresh.Click += (s, e) => LoadData();
            this.cboYear.SelectedIndexChanged += (s, e) => LoadRevenueChart();
        }

        private void UcReportManagement_Load(object sender, EventArgs e)
        {
            int currentYear = DateTime.Now.Year;
            cboYear.Items.Add(currentYear - 2);
            cboYear.Items.Add(currentYear - 1);
            cboYear.Items.Add(currentYear);

            if (cboYear.SelectedItem == null)
            {
                cboYear.SelectedItem = currentYear;
            }

            SetupDgv();
        }

        /// <summary>
        /// Hàm này được Owner_TrangChu gọi (qua Mediator)
        /// </summary>
        public void LoadData()
        {
            if (_ownerId == Guid.Empty) return;

            LoadOccupancyChart();
            LoadUnpaidBills();
        }

        /// <summary>
        /// 1. Vẽ Biểu đồ Doanh thu (ĐÃ SỬA LỖI CĂN GIỮA)
        /// </summary>
        private void LoadRevenueChart()
        {
            if (cboYear.SelectedItem == null) return;
            if (_ownerId == Guid.Empty) return;

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

            revenueChart.Plot.Axes.SetLimits(left: -0.5, right: 11.5);

            try { revenueChart.Plot.Axes.Left.Label.Text = "Doanh thu (VND)"; } catch { }
            try { revenueChart.Plot.Title($"Doanh thu năm {year}"); } catch { }

            revenueChart.Refresh();
        }

        /// <summary>
        /// 2. Vẽ Biểu đồ Tỷ lệ Lấp đầy (ĐÃ MỞ LẠI NHÃN)
        /// </summary>
        private void LoadOccupancyChart()
        {
            if (_ownerId == Guid.Empty) return;

            (int occupied, int total) = _dashboardService.GetOccupancyStats(_ownerId);
            int available = total - occupied;
            occupancyChart.Plot.Clear();

            if (total > 0)
            {
                double[] values = { (double)occupied, (double)available };
                var pie = occupancyChart.Plot.Add.Pie(values);

                var rentedColor = ScottPlot.Color.FromHex("#28a745");
                var availableColor = ScottPlot.Color.FromHex("#6c757d");

                pie.Slices[0].Fill.Color = rentedColor;
                pie.Slices[1].Fill.Color = availableColor;

                // Gán nhãn cho Chú giải
                //pie.Slices[0].LegendLabel = $"Đã thuê: {occupied} ({((double)occupied / total):P1})";
                //pie.Slices[1].LegendLabel = $"Còn trống: {available} ({((double)available / total):P1})";

                //// Ẩn nhãn trên miếng bánh (đã có chú giải)
                //pie.ShowSliceLabels = false;
                // --- HẾT ---

                occupancyChart.Plot.Legend.IsVisible = true;
                occupancyChart.Plot.Legend.Alignment = Alignment.MiddleRight;
            }

            try { occupancyChart.Plot.Title($"Tỷ lệ lấp đầy (Tổng: {total} phòng)"); } catch { }
            occupancyChart.Refresh();
        }

        /// <summary>
        /// 3. Hiển thị Báo cáo nợ đọng
        /// </summary>
        private void LoadUnpaidBills()
        {
            if (_ownerId == Guid.Empty) return; // Bảo vệ

            var unpaidBills = _dashboardService.GetUnpaidBill(_ownerId) ?? new List<Bill>();
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
    }
}