using QuanLyPhongTro.Model;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class ucBillCard : UserControl
    {
        private readonly Bill _bill;

        // Tạo Event để "báo" cho UserControl cha
        public event EventHandler<Guid> SendBillClicked;
        public event EventHandler<Guid> ExportPDFClicked;

        public ucBillCard(Bill bill)
        {
            InitializeComponent();
            _bill = bill;

            this.Load += UcBillCard_Load;
            this.btnSendBill.Click += (s, e) => SendBillClicked?.Invoke(this, _bill.Id);
            this.btnExportPDF.Click += (s, e) => ExportPDFClicked?.Invoke(this, _bill.Id);
        }

        private void UcBillCard_Load(object sender, EventArgs e)
        {
            if (_bill == null) return;

            // 1. Tải thông tin cơ bản
            lblRoomName.Text = _bill.Room?.Name ?? "N/A";
            lblRenterName.Text = _bill.Person?.Username ?? "N/A";
            lblTotal.Text = $"TỔNG: {_bill.TotalMoney:N0} VND";

            // 2. Tải chi tiết (Điện, Nước, Khác)
            var electric = _bill.BillDetails.FirstOrDefault(d => d.Service?.Name == "Dien");
            var water = _bill.BillDetails.FirstOrDefault(d => d.Service?.Name == "Nuoc");
            var others = _bill.BillDetails.Where(d => d.Service?.Name != "Dien" && d.Service?.Name != "Nuoc");

            lblElectricity.Text = $"Tiền điện: {electric?.Total ?? 0:N0} VND";
            lblWater.Text = $"Tiền nước: {water?.Total ?? 0:N0} VND";

            lstOtherCosts.Items.Clear();
            foreach (var item in others)
            {
                string note = string.IsNullOrEmpty(item.Note) ? "" : $" ({item.Note})";
                lstOtherCosts.Items.Add($"{item.Service?.Name ?? "Phí khác"}: {item.Total:N0}{note}");
            }

            // 3. Cập nhật nút và màu sắc dựa trên Trạng thái
            UpdateStatusUI(_bill.Status);
        }

        /// <summary>
        /// Cập nhật UI (public để control cha có thể gọi)
        /// </summary>
        public void UpdateStatusUI(string status)
        {
            lblStatus.Text = $"Trạng thái: {status}";
            _bill.Status = status; // Cập nhật trạng thái local

            switch (status)
            {
                case "Paid": // Đã thanh toán
                    panelMain.BackColor = Color.FromArgb(236, 255, 236); // Xanh lá nhạt
                    lblStatus.ForeColor = Color.DarkGreen;
                    btnSendBill.Text = "Đã thanh toán";
                    btnSendBill.Enabled = false;
                    break;
                case "Sent": // Đã gửi (chưa trả)
                    panelMain.BackColor = Color.FromArgb(255, 255, 230); // Vàng nhạt
                    lblStatus.ForeColor = Color.OrangeRed;
                    btnSendBill.Text = "Nhắc nợ";
                    btnSendBill.Enabled = true;
                    break;
                case "Overdue": // Quá hạn
                    panelMain.BackColor = Color.FromArgb(255, 230, 230); // Đỏ nhạt
                    lblStatus.ForeColor = Color.Red;
                    btnSendBill.Text = "Nhắc nợ (Gấp)";
                    btnSendBill.Enabled = true;
                    break;
                case "Pending": // Chờ gửi
                default:
                    panelMain.BackColor = Color.White;
                    lblStatus.ForeColor = Color.Gray;
                    btnSendBill.Text = "Gửi Hóa đơn";
                    btnSendBill.Enabled = true;
                    break;
            }
        }
    }
}