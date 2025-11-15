using QuanLyPhongTro.Model;
using QuanLyPhongTro.src.Mediator;
using QuanLyPhongTro.Services;
using ScottPlot; // v5
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace QuanLyPhongTro
{
    public partial class ucMyRoom : UserControl
    {
        private Contract _contract;
        private readonly BillService _billService;

        // (Biến để lưu hóa đơn cần thanh toán)
        private Bill _latestBill;

        public ucMyRoom()
        {
            InitializeComponent();
            _billService = new BillService();

            Mediator.Instance.Register<Contract>("UcMyRoom", (contract) =>
            {
                _contract = contract;
                // Kiểm tra xem control đã load xong chưa
                if (this.IsHandleCreated)
                {
                    LoadData();
                }
                return Task.CompletedTask;
            });

            // Gán sự kiện Load (để LoadData nếu Mediator chạy trước)
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

        // Hàm LoadData chung
        private void LoadData()
        {
            if (_contract == null) return;

            // Kiểm tra an toàn (sửa lỗi Guid?)
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
            _latestBill = _billService.GetLatestUnpaidBill(_contract.IdRenter.Value);

            if (_latestBill == null)
            {
                // Không có hóa đơn nào
                lblBillTitle.Text = "Không có hóa đơn";
                lblBillTotal.Text = "Tổng: 0 VND";
                lblBillStatus.Text = "Trạng thái: Đã thanh toán";
                btnPay.Enabled = false;
                btnPay.Tag = null; // Xóa tag
            }
            else
            {
                // Có hóa đơn
                lblBillTitle.Text = $"Hóa đơn tháng {_latestBill.PaymentDate:MM/yyyy}";
                lblBillTotal.Text = $"Tổng: {_latestBill.TotalMoney:N0} VND";
                lblBillStatus.Text = $"Trạng thái: {_latestBill.Status}";
                btnPay.Enabled = true;
                btnPay.Tag = _latestBill.Id; // Lưu ID hóa đơn vào Tag
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

                // Tăng lên tháng tiếp theo
                monthIterator = monthIterator.AddMonths(1);
            }

            // 3. Vẽ biểu đồ
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
            // Kiểm tra xem có hóa đơn trong Tag không
            if (btnPay.Tag == null || !(btnPay.Tag is Guid))
            {
                MessageBox.Show("Không tìm thấy hóa đơn để thanh toán.");
                return;
            }

            Guid billId = (Guid)btnPay.Tag;

            // TODO: Mở cổng thanh toán (Momo, ZaloPay...)

            var confirm = MessageBox.Show("Bạn có muốn thanh toán hóa đơn này không? (Demo)", "Xác nhận thanh toán", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No) return;

            bool success = _billService.UpdateBillStatus(billId, "Paid");

            if (success)
            {
                MessageBox.Show("Thanh toán thành công!");
                LoadLatestBill();
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại.");
            }
        }
    }
}