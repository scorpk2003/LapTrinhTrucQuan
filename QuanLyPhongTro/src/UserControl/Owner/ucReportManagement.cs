// ucReportManagement.cs
using QuanLyPhongTro.src.Models;
using QuanLyPhongTro.src.Services1;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyPhongTro.src.Mediator;

using WinColor = System.Drawing.Color;
using SPColor = ScottPlot.Color;

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

            InitYearList();
            SetupDgv();

            // Mediator nhận Owner từ TrangChu
            Mediator.Instance.Register<Person>("UcReportManagement", (owner) =>
            {
                _ownerId = owner.Id;

                if (cboYear.Items.Count > 0)
                    cboYear.SelectedItem = DateTime.Now.Year;

                LoadData();
                return Task.CompletedTask;
            });

            this.Load += UcReportManagement_Load;
            this.btnRefresh.Click += (s, e) => LoadData();
            this.cboYear.SelectedIndexChanged += (s, e) => LoadRevenueChart();
        }

        private void InitYearList()
        {
            int y = DateTime.Now.Year;
            if (cboYear.Items.Count == 0)
            {
                cboYear.Items.Add(y - 2);
                cboYear.Items.Add(y - 1);
                cboYear.Items.Add(y);
                cboYear.SelectedItem = y;
            }
        }

        private void UcReportManagement_Load(object sender, EventArgs e)
        {
            if (cboYear.SelectedItem == null)
                cboYear.SelectedItem = DateTime.Now.Year;

            if (_ownerId != Guid.Empty)
                LoadData();
        }

        public void LoadData()
        {
            if (_ownerId == Guid.Empty) return;

            LoadRevenueChart();
            LoadOccupancyChart();
            LoadUnpaidBills();
        }

        private void LoadRevenueChart()
        {
            if (cboYear.SelectedItem == null) return;
            if (_ownerId == Guid.Empty) return;

            int year = (int)cboYear.SelectedItem;

            var monthlyData = _dashboardService.GetMonthlyRevenue(_ownerId, year) ?? new Dictionary<string, decimal>();

            revenueChart.Plot.Clear();

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

            double[] positions = Enumerable.Range(0, 12).Select(i => (double)i).ToArray();
            var bars = revenueChart.Plot.Add.Bars(positions, values);
            bars.Color = SPColor.FromHex("#3498db");

            string[] labels = { "T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10", "T11", "T12" };
            revenueChart.Plot.Axes.Bottom.SetTicks(positions, labels);
            revenueChart.Plot.Axes.Bottom.TickLabelStyle.FontSize = 12;
            revenueChart.Plot.Axes.Left.TickLabelStyle.FontSize = 12;

            revenueChart.Plot.Axes.SetLimits(left: -0.5, right: 11.5);

            try
            {
                revenueChart.Plot.Axes.Left.Label.Text = "Doanh thu (VND)";
                revenueChart.Plot.Axes.Left.Label.FontSize = 13;
                revenueChart.Plot.Axes.Left.Label.Bold = true;
            }
            catch { }

            try
            {
                revenueChart.Plot.Title($"Doanh thu năm {year}");
            }
            catch { }

            revenueChart.Refresh();
        }

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

                var rentedColor = SPColor.FromHex("#27ae60");
                var availableColor = SPColor.FromHex("#95a5a6");

                pie.Slices[0].Fill.Color = rentedColor;
                pie.Slices[1].Fill.Color = availableColor;

                pie.Slices[0].LegendText = $"Đã thuê: {occupied} ({((double)occupied / total):P1})";
                pie.Slices[1].LegendText = $"Còn trống: {available} ({((double)available / total):P1})";

                occupancyChart.Plot.Legend.IsVisible = true;
                occupancyChart.Plot.Legend.Alignment = Alignment.MiddleRight;
                occupancyChart.Plot.Legend.FontSize = 11;
            }

            try
            {
                occupancyChart.Plot.Title($"Tỉ lệ lấp đầy (Tổng: {total} phòng)");
            }
            catch { }

            occupancyChart.Refresh();
        }

        private void LoadUnpaidBills()
        {
            if (_ownerId == Guid.Empty) return;

            if (dgvUnpaidBills.Columns.Count == 0)
                SetupDgv();

            var unpaidBills = _dashboardService.GetUnpaidBills(_ownerId) ?? new List<Bill>();

            dgvUnpaidBills.Rows.Clear();

            decimal totalDebt = 0;
            foreach (var bill in unpaidBills)
            {
                decimal money = bill.TotalMoney ?? 0;
                totalDebt += money;

                dgvUnpaidBills.Rows.Add(
                    bill.IdRoomNavigation?.Name ?? "N/A",
                    bill.IdPersonNavigation?.Username ?? "N/A",
                    bill.PaymentDate.HasValue ? bill.PaymentDate.Value.ToString("dd/MM/yyyy") : "N/A",
                    money,
                    bill.Status ?? string.Empty
                );
            }

            // Summary UI
            lblUnpaidCount.Text = $"Số hóa đơn nợ: {unpaidBills.Count}";
            lblUnpaidTotal.Text = $"Tổng nợ: {totalDebt:N0} VND";
        }

        private void SetupDgv()
        {
            dgvUnpaidBills.SuspendLayout();

            dgvUnpaidBills.AutoGenerateColumns = false;
            dgvUnpaidBills.Columns.Clear();

            // Core behavior
            dgvUnpaidBills.ReadOnly = true;
            dgvUnpaidBills.MultiSelect = false;
            dgvUnpaidBills.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUnpaidBills.RowHeadersVisible = false;
            dgvUnpaidBills.AllowUserToAddRows = false;
            dgvUnpaidBills.AllowUserToDeleteRows = false;
            dgvUnpaidBills.AllowUserToResizeRows = false;
            dgvUnpaidBills.AllowUserToOrderColumns = true;
            dgvUnpaidBills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Visual polish (WinForms Color)
            dgvUnpaidBills.BackgroundColor = WinColor.White;
            dgvUnpaidBills.BorderStyle = BorderStyle.None;
            dgvUnpaidBills.GridColor = WinColor.FromArgb(230, 235, 240);
            dgvUnpaidBills.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUnpaidBills.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvUnpaidBills.EnableHeadersVisualStyles = false;

            dgvUnpaidBills.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            dgvUnpaidBills.DefaultCellStyle.ForeColor = WinColor.FromArgb(33, 37, 41);
            dgvUnpaidBills.DefaultCellStyle.BackColor = WinColor.White;
            dgvUnpaidBills.DefaultCellStyle.SelectionBackColor = WinColor.FromArgb(225, 240, 255);
            dgvUnpaidBills.DefaultCellStyle.SelectionForeColor = WinColor.FromArgb(33, 37, 41);
            dgvUnpaidBills.DefaultCellStyle.Padding = new Padding(6, 4, 6, 4);

            dgvUnpaidBills.AlternatingRowsDefaultCellStyle.BackColor = WinColor.FromArgb(250, 252, 254);

            dgvUnpaidBills.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dgvUnpaidBills.ColumnHeadersDefaultCellStyle.BackColor = WinColor.FromArgb(52, 152, 219);
            dgvUnpaidBills.ColumnHeadersDefaultCellStyle.ForeColor = WinColor.White;
            dgvUnpaidBills.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvUnpaidBills.ColumnHeadersHeight = 52;
            dgvUnpaidBills.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvUnpaidBills.RowTemplate.Height = 46;

            // Columns
            var colRoom = new DataGridViewTextBoxColumn
            {
                Name = "RoomName",
                HeaderText = "Phòng",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 12
            };

            var colRenter = new DataGridViewTextBoxColumn
            {
                Name = "RenterName",
                HeaderText = "Người thuê",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 22
            };

            var colDueDate = new DataGridViewTextBoxColumn
            {
                Name = "DueDate",
                HeaderText = "Hạn thanh toán",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 16
            };

            var colAmount = new DataGridViewTextBoxColumn
            {
                Name = "Amount",
                HeaderText = "Số tiền (VND)",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 22,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0",
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold)
                }
            };

            var colStatus = new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Trạng thái",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 14,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };

            dgvUnpaidBills.Columns.AddRange(new DataGridViewColumn[]
            {
                colRoom, colRenter, colDueDate, colAmount, colStatus
            });

            foreach (DataGridViewColumn c in dgvUnpaidBills.Columns)
                c.SortMode = DataGridViewColumnSortMode.Automatic;

            // Semantic coloring
            dgvUnpaidBills.CellFormatting -= DgvUnpaidBills_CellFormatting;
            dgvUnpaidBills.CellFormatting += DgvUnpaidBills_CellFormatting;

            // Reduce flicker
            EnableDoubleBuffering(dgvUnpaidBills);

            dgvUnpaidBills.ResumeLayout();
        }

        private void DgvUnpaidBills_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvUnpaidBills.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString().Trim().ToLowerInvariant();
                var cell = dgvUnpaidBills.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // reset (đảm bảo không “dính” style của row khác)
                cell.Style.BackColor = WinColor.White;
                cell.Style.ForeColor = WinColor.FromArgb(33, 37, 41);
                cell.Style.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);

                if (status.Contains("chưa") || status.Contains("unpaid") || status.Contains("nợ"))
                {
                    cell.Style.BackColor = WinColor.FromArgb(255, 235, 238);
                    cell.Style.ForeColor = WinColor.FromArgb(198, 40, 40);
                }
                else if (status.Contains("đang") || status.Contains("pending"))
                {
                    cell.Style.BackColor = WinColor.FromArgb(255, 248, 225);
                    cell.Style.ForeColor = WinColor.FromArgb(245, 124, 0);
                }
                else if (status.Contains("đã") || status.Contains("paid"))
                {
                    cell.Style.BackColor = WinColor.FromArgb(232, 245, 233);
                    cell.Style.ForeColor = WinColor.FromArgb(46, 125, 50);
                }
            }
        }

        private static void EnableDoubleBuffering(DataGridView dgv)
        {
            try
            {
                typeof(DataGridView).InvokeMember(
                    "DoubleBuffered",
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                    null,
                    dgv,
                    new object[] { true }
                );
            }
            catch
            {
                // ignore if reflection blocked
            }
        }
    }
}
