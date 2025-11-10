using QuanLyPhongTro.Model;
using QuanLyPhongTro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class ucBillManagement : UserControl
    {
        private readonly Guid _ownerId;
        private readonly BillService _billService;

        public ucBillManagement(Guid ownerId)
        {
            InitializeComponent();
            _ownerId = ownerId;
            _billService = new BillService();

            this.Load += UcBillManagement_Load;

            // Gán sự kiện cho các nút filter
            this.cboMonth.SelectedIndexChanged += (s, e) => LoadBillsByMonth();
            this.cboYear.SelectedIndexChanged += (s, e) => LoadBillsByMonth();
            this.btnShowUnpaid.Click += (s, e) => LoadUnpaidBills();
            this.btnGenerateBills.Click += BtnGenerateBills_Click;
        }

        private void UcBillManagement_Load(object sender, EventArgs e)
        {
            // 1. Nạp dữ liệu cho ComboBox tháng (1-12)
            for (int i = 1; i <= 12; i++)
            {
                cboMonth.Items.Add(i);
            }

            // 2. Nạp dữ liệu cho ComboBox năm (ví dụ: 3 năm gần nhất)
            int currentYear = DateTime.Now.Year;
            cboYear.Items.Add(currentYear - 1);
            cboYear.Items.Add(currentYear);
            cboYear.Items.Add(currentYear + 1);

            // 3. Đặt giá trị mặc định là tháng/năm hiện tại
            cboMonth.SelectedItem = DateTime.Now.Month;
            cboYear.SelectedItem = currentYear;

            // 4. Tải dữ liệu (LoadData() sẽ được gọi từ Form cha)
        }

        /// <summary>
        /// (Public) Hàm này được Owner_TrangChu gọi
        /// </summary>
        public void LoadData()
        {
            LoadBillsByMonth();
        }

        /// <summary>
        /// Tải HĐ theo tháng (chức năng chính)
        /// </summary>
        private void LoadBillsByMonth()
        {
            if (cboMonth.SelectedItem == null || cboYear.SelectedItem == null)
                return;

            int month = (int)cboMonth.SelectedItem;
            int year = (int)cboYear.SelectedItem;

            List<Bill> bills = _billService.GetBillsByMonth(month, year, _ownerId);
            PopulateBills(bills);
        }

        /// <summary>
        /// Tải HĐ Nợ (chức năng nhắc nợ)
        /// </summary>
        private void LoadUnpaidBills()
        {
            List<Bill> bills = _billService.GetUnpaidBills(_ownerId);
            PopulateBills(bills);
        }

        /// <summary>
        /// Hiển thị danh sách Bill (dùng chung)
        /// </summary>
        private void PopulateBills(List<Bill> bills)
        {
            flowPanelBills.Controls.Clear();
            if (bills == null || bills.Count == 0)
            {
                // (Có thể thêm 1 Label "Không có hóa đơn")
                return;
            }

            foreach (var bill in bills)
            {
                var card = new ucBillCard(bill);

                // Lắng nghe sự kiện từ Card
                card.SendBillClicked += Card_OnSendBillClicked;
                card.ExportPDFClicked += Card_OnExportPDFClicked;

                flowPanelBills.Controls.Add(card);
            }
        }

        /// <summary>
        /// Sự kiện khi nhấn nút "Tạo HĐ tháng này"
        /// </summary>
        private void BtnGenerateBills_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show($"Bạn có chắc muốn tạo HĐ nháp cho tháng {DateTime.Now:MM/yyyy}?",
                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // (Bạn cần 1 form để nhập chỉ số điện/nước. Đây là code demo)
                bool success = _billService.GenerateMonthlyBills(_ownerId, DateTime.Now.Month, DateTime.Now.Year);
                if (success)
                {
                    MessageBox.Show("Tạo HĐ nháp thành công!");
                    LoadBillsByMonth(); // Tải lại
                }
                else
                {
                    MessageBox.Show("Tạo HĐ thất bại.");
                }
            }
        }

        // --- CÁC HÀM BẮT SỰ KIỆN TỪ CARD ---

        /// <summary>
        /// Khi user nhấn "Gửi HĐ" hoặc "Nhắc nợ" trên 1 card
        /// </summary>
        private void Card_OnSendBillClicked(object sender, Guid billId)
        {
            var card = (ucBillCard)sender;
            string currentStatus = card.Tag?.ToString() ?? "Pending"; // Lấy trạng thái từ Card (nếu cần)
            string newStatus = "Sent";
            string message = "Gửi hóa đơn thành công!";

            if (currentStatus == "Sent" || currentStatus == "Overdue")
            {
                newStatus = "Overdue"; // Trạng thái mới là "Quá hạn" (nhắc nợ)
                message = "Gửi nhắc nợ thành công!";
            }

            // Gọi Service
            bool success = _billService.UpdateBillStatus(billId, newStatus);
            if (success)
            {
                MessageBox.Show(message);
                card.UpdateStatusUI(newStatus); // Cập nhật UI của card đó
            }
        }

        /// <summary>
        /// Khi user nhấn "Xuất PDF" trên 1 card
        /// </summary>
        private void Card_OnExportPDFClicked(object sender, Guid billId)
        {
            _billService.ExportBillToPDF(billId);
        }
    }
}