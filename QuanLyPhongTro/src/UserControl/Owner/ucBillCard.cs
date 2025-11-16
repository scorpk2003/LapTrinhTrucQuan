using QuanLyPhongTro.src.Test.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class ucBillCard : UserControl
    {
        private readonly Bill _bill;


        public event EventHandler<Guid> ExportPDFClicked;
        public event EventHandler<Guid> EditDetailsClicked; 

        public ucBillCard(Bill bill)
        {
            InitializeComponent();
            _bill = bill;

            this.Load += UcBillCard_Load;

            this.btnSendBill.Click += (s, e) => EditDetailsClicked?.Invoke(this, _bill.Id);
            this.btnExportPDF.Click += (s, e) => ExportPDFClicked?.Invoke(this, _bill.Id);
            
        }

        private void UcBillCard_Load(object sender, EventArgs e)
        {
            if (_bill == null) return;

            // 1. Tải thông tin cơ bản
            lblRoomName.Text = _bill.IdRoomNavigation?.Name ?? "N/A";
            lblRenterName.Text = _bill.IdPersonNavigation?.Username ?? "N/A";
            lblTotal.Text = $"TỔNG: {(_bill.TotalMoney ?? 0):N0} VND";

            // 2. Tải chi tiết (Điện, Nước, Khác)
            var electric = _bill.BillDetails.FirstOrDefault(d => d.IdServiceNavigation?.Name == "Dien");
            var water = _bill.BillDetails.FirstOrDefault(d => d.IdServiceNavigation?.Name == "Nuoc");
            var others = _bill.BillDetails.Where(d => 
                d.IdServiceNavigation != null && 
                d.IdServiceNavigation.Name != "Dien" && 
                d.IdServiceNavigation.Name != "Nuoc");

            lblElectricity.Text = $"Tiền điện: {electric?.Total ?? 0:N0} VND";
            lblWater.Text = $"Tiền nước: {water?.Total ?? 0:N0} VND";

            lstOtherCosts.Items.Clear();
            foreach (var item in others)
            {
                lstOtherCosts.Items.Add($"{item.IdServiceNavigation?.Name ?? "Phí khác"}: {item.Total:N0} VND");
            }

            // 3. Cập nhật nút và màu sắc
            UpdateStatusUI();
        }

        /// <summary>
        /// Cập nhật UI (public để control cha có thể gọi)
        /// </summary>
        public void UpdateStatusUI() 
        {
            panelMain.BackColor = Color.FromArgb(255, 255, 230);
            lblStatus.ForeColor = Color.OrangeRed;
            lblStatus.Text = "Trạng thái: Chưa thanh toán";
            btnSendBill.Text = "Sửa Chi tiết";
            btnSendBill.Enabled = true;

            if (_bill.Payment != null)
            {
                if (_bill.Payment.Amount >= _bill.TotalMoney)
                {
                    panelMain.BackColor = Color.FromArgb(236, 255, 236);
                    lblStatus.ForeColor = Color.DarkGreen;
                    lblStatus.Text = "Trạng thái: Đã thanh toán";
                    btnSendBill.Enabled = false; 
                }
                else
                {
                    panelMain.BackColor = Color.FromArgb(230, 245, 255);
                    lblStatus.ForeColor = Color.Blue;
                    lblStatus.Text = $"Trạng thái: Đã trả {(_bill.Payment.Amount ?? 0):N0}";
                    btnSendBill.Enabled = true; 
                }
            }
        }
    }
}