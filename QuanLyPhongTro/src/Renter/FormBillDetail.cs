using QuanLyPhongTro.src.Test.Models;
using QuanLyPhongTro.Services;
using System;
using System.Drawing;
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

             //this.btnPay.Click += BtnPay_Click;
        }

        private void LoadBillDetails()
        {
            lblRoomName.Text = _bill.IdRoomNavigation?.Name ?? "N/A";

            lblPaymentDate.Text = _bill.PaymentDate.HasValue ? _bill.PaymentDate.Value.ToString("dd/MM/yyyy") : "Chưa chốt";

            if (_bill.Payment == null)
            {
                lblStatus.Text = "Chưa thanh toán";
                lblStatus.ForeColor = Color.OrangeRed;
            }
            else if (_bill.Payment.Amount < _bill.TotalMoney)
            {
                lblStatus.Text = $"Đã thanh toán một phần ({_bill.Payment.Amount:N0} VND)";
                lblStatus.ForeColor = Color.Blue;
            }
            else
            {
                lblStatus.Text = "Đã thanh toán";
                lblStatus.ForeColor = Color.DarkGreen;
            }
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
                        detail.IdServiceNavigation?.Name ?? "N/A",
                        detail.Quantity,
                        detail.Total
                    );
                }
            }

            lblTotalMoney.Text = $"Tổng cộng: {(_bill.TotalMoney ?? 0):N0} VND";
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                $"Xác nhận thanh toán {(_bill.TotalMoney ?? 0):N0} VND?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                // Gọi PayBill
                bool success = _billService.PayBill(
                    _bill.Id,
                    _bill.TotalMoney ?? 0, // SỬA LỖI 5
                    "Cash"
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