using QuanLyPhongTro.src.Services1;
using QuanLyPhongTro.src.Mediator; 
using QuanLyPhongTro.src.Models;
using ScottPlot; // v5
using System;
using System.Collections.Generic;
using System.Drawing; // <-- Thêm
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class ucMyRoom : UserControl
    {
        private Contract _contract;
        private readonly BillService _billService;
        private Bill _latestBill;

        public ucMyRoom()
        {
            InitializeComponent();
            _billService = new BillService();

            Mediator.Instance.Register<Contract>("UcMyRoom", (contract) =>
            {
                _contract = contract;
                if (this.IsHandleCreated)
                {
                    LoadData();
                }
                return Task.CompletedTask;
            });

            this.Load += UcMyRoom_Load;
            this.btnPay.Click += BtnPay_Click;
        }

        private void UcMyRoom_Load(object sender, EventArgs e)
        {
            if (_contract != null)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            if (_contract == null) return;
            if (!_contract.IdRenter.HasValue || !_contract.IdRoom.HasValue)
            {
                MessageBox.Show("Lỗi: Hợp đồng không hợp lệ.");
                return;
            }

            LoadRoomInfo();
            LoadContractInfo();
            LoadLatestBill();
            LoadSpendingChart();
        }

        private void LoadRoomInfo()
        {
            if (_contract.IdRoomNavigation == null) return;
            lblRoomName.Text = _contract.IdRoomNavigation.Name;
            lblRoomPrice.Text = $"Giá thuê: {_contract.IdRoomNavigation.Price:N0} VND";
            lblRoomArea.Text = $"Diện tích: {_contract.IdRoomNavigation.Area:N2} m²"; 
            //lblRoomAddress.Text = $"Địa chỉ: {_contract.IdRoomNavigation.Address}"; 
             
        }

        private void LoadContractInfo()
        { 
            lblStartDate.Text = $"Ngày bắt đầu: {_contract.StartDate.Value.ToString("dd/MM/yyyy") ?? "N/A"}";
            lblEndDate.Text = $"Ngày kết thúc: {_contract.EndDate.Value.ToString("dd/MM/yyyy") ?? "N/A"}";
            lblDeposit.Text = $"Tiền cọc: {_contract.Deposit:N0} VND";
             
        }

        private void LoadLatestBill()
        {
            _latestBill = _billService.GetLatestUnpaidBill(_contract.IdRenter.Value);

            if (_latestBill == null)
            {
                lblBillTitle.Text = "Không có hóa đơn";
                lblBillTotal.Text = "Tổng: 0 VND";
                lblBillStatus.Text = "Trạng thái: Đã thanh toán";
                lblBillStatus.ForeColor = System.Drawing.Color.DarkGreen;
                btnPay.Enabled = false;
                btnPay.Tag = null;
            }
            else
            {
                lblBillTitle.Text = $"Hóa đơn tháng {_latestBill.PaymentDate.Value.ToString("MM/yyyy")}";
                lblBillTotal.Text = $"Tổng: {_latestBill.TotalMoney:N0} VND";

                if (_latestBill.Payment == null)
                {
                    lblBillStatus.Text = "Trạng thái: Chưa thanh toán";
                    lblBillStatus.ForeColor = System.Drawing.Color.OrangeRed;
                    btnPay.Text = "Thanh toán ngay";
                    btnPay.Enabled = true;
                }
                else if (_latestBill.Payment.Amount < _latestBill.TotalMoney)
                {
                    lblBillStatus.Text = $"Trạng thái: Đã trả {_latestBill.Payment.Amount:N0} VND";
                    lblBillStatus.ForeColor = System.Drawing.Color.Blue;
                    btnPay.Text = "Thanh toán phần còn lại";
                    btnPay.Enabled = true;
                }
                else
                {
                    lblBillStatus.Text = "Trạng thái: Đã thanh toán";
                    lblBillStatus.ForeColor = System.Drawing.Color.DarkGreen;
                    btnPay.Enabled = false;
                }

                btnPay.Tag = _latestBill.Id;
            }
        }

        private void LoadSpendingChart()
        {
            spendingChart.Plot.Clear();
            var spendingData = _billService.GetMonthlySpending(_contract.IdRenter.Value);

            double[] values = new double[12];
            string[] labels = new string[12];
            DateTime monthIterator = DateTime.Now.AddMonths(-11);

            for (int i = 0; i < 12; i++)
            {
                string key = $"{monthIterator.Month}/{monthIterator.Year}";
                labels[i] = $"{monthIterator:MM/yy}";

                if (spendingData.TryGetValue(key, out decimal total))
                {
                    values[i] = (double)(total / 1000000);
                }
                else
                {
                    values[i] = 0;
                }
                monthIterator = monthIterator.AddMonths(1);
            }

            double[] positions = Enumerable.Range(0, 12).Select(i => (double)i).ToArray();
            var bars = spendingChart.Plot.Add.Bars(positions, values);
            bars.Color = ScottPlot.Color.FromHex("#3498db");

            spendingChart.Plot.Axes.Bottom.SetTicks(positions, labels);
            spendingChart.Plot.Axes.SetLimits(left: -0.5, right: 11.5);
            try { spendingChart.Plot.Axes.Left.Label.Text = "Chi tiêu (Triệu VND)"; } catch { }
            try { spendingChart.Plot.Title("Thống kê chi tiêu (12 tháng qua)"); } catch { }
            spendingChart.Refresh();
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            if (btnPay.Tag == null || !(btnPay.Tag is Guid))
            {
                MessageBox.Show("Không tìm thấy hóa đơn để thanh toán.");
                return;
            }
            if (_latestBill == null) return; 

            Guid billId = (Guid)btnPay.Tag;

            decimal amountPaid = _latestBill.Payment?.Amount ?? 0;
            decimal totalDue = _latestBill.TotalMoney ?? 0;
            decimal amountToPay = totalDue - amountPaid;

            var confirm = MessageBox.Show($"Bạn có muốn thanh toán số tiền {amountToPay:N0} VND không?", "Xác nhận thanh toán", MessageBoxButtons.YesNo); // Sửa Encoding
            if (confirm == DialogResult.No) return;

            bool success = _billService.PayBill(billId, amountToPay, "Chuyển khoản");

            if (success)
            {
                MessageBox.Show("Thanh toán thành công!");
                LoadLatestBill(); 
                LoadSpendingChart(); 
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại.");
            }
        }
    }
}