using QuanLyPhongTro.Model;
using QuanLyPhongTro.Services;
using System;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class FormBillDetail : Form
    {
        private readonly Bill _bill;
        private readonly BillService _billService;

        public FormBillDetail(Guid billId)
        {
            InitializeComponent();
            _billService = new BillService();
            _bill = _billService.GetBillWithDetails(billId);

            if (_bill == null)
            {
                MessageBox.Show("Không tìm thấy hóa đơn!");
                this.Close();
                return;
            }

            LoadBillDetails();
            this.btnClose.Click += (s, e) => this.Close();
        }

        private void LoadBillDetails()
        {
            // Hiển thị thông tin cơ bản
            lblRoomName.Text = _bill.Room?.Name ?? "N/A";
            lblPaymentDate.Text = _bill.PaymentDate.ToString("dd/MM/yyyy");
            lblStatus.Text = _bill.Status;

            // Hiển thị chi tiết dịch vụ
            dgvBillDetails.Rows.Clear();
            dgvBillDetails.Columns.Clear();
            dgvBillDetails.AutoGenerateColumns = false;

            dgvBillDetails.Columns.Add("ServiceName", "Dịch vụ");
            dgvBillDetails.Columns.Add("Quantity", "Số lượng");
            dgvBillDetails.Columns.Add("Total", "Thành tiền");
            dgvBillDetails.Columns["Total"].DefaultCellStyle.Format = "N0";

            if (_bill.BillDetails != null)
            {
                foreach (var detail in _bill.BillDetails)
                {
                    dgvBillDetails.Rows.Add(
                        detail.Service?.Name ?? "N/A",
                        detail.Quantity,
                        detail.Total
                    );
                }
            }

            lblTotalMoney.Text = $"Tổng cộng: {_bill.TotalMoney:N0} VND";

            
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                $"Xác nhận thanh toán {_bill.TotalMoney:N0} VND?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                // Gọi PayBill (giả sử thanh toán toàn bộ bằng Cash)
                bool success = _billService.PayBill(
                    _bill.Id,
                    _bill.TotalMoney,
                    "Cash" // Hoặc cho user chọn
                );

                if (success)
                {
                    MessageBox.Show("Thanh toán thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thanh toán thất bại!");
                }
            }
        }
    }
}