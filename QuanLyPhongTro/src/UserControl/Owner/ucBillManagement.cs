using QuanLyPhongTro.src.Services1;
using QuanLyPhongTro.src.Mediator;
using QuanLyPhongTro.src.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class ucBillManagement : UserControl
    {
        private Guid _ownerId;
        private readonly BillService _billService;

        public ucBillManagement()
        {
            InitializeComponent();
            _billService = new BillService();
            _ownerId = Guid.Empty;

            Mediator.Instance.Register<Person>("UcBillManagement", (owner) =>
            {
                _ownerId = owner.Id;

                // Set giá trị mặc định khi nhận được OwnerId
                cboMonth.SelectedItem = DateTime.Now.Month;
                cboYear.SelectedItem = DateTime.Now.Year;

                return Task.CompletedTask;
            });

            // (Bạn chưa gán sự kiện cho btnConfirmPayment trong Designer?)
            this.btnConfirmPayment.Click += BtnConfirmPayment_Click;

            this.Load += UcBillManagement_Load;

            this.cboMonth.SelectedIndexChanged += async (s, e) => await LoadBillsByMonth();
            this.cboYear.SelectedIndexChanged += async (s, e) => await LoadBillsByMonth();
            this.btnShowUnpaid.Click += (s, e) => LoadUnpaidBills();
            this.btnGenerateBills.Click += BtnGenerateBills_Click;
        }

        private void UcBillManagement_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 12; i++)
            {
                cboMonth.Items.Add(i);
            }
            int currentYear = DateTime.Now.Year;
            cboYear.Items.Add(currentYear - 1);
            cboYear.Items.Add(currentYear);
            cboYear.Items.Add(currentYear + 1);
        }

        // (Hàm LoadData() không được gọi, đã xóa)

        private async Task LoadBillsByMonth()
        {
            if (cboMonth.SelectedItem == null || cboYear.SelectedItem == null)
                return;
            if (_ownerId == Guid.Empty)
                return;

            int month = (int)cboMonth.SelectedItem;
            int year = (int)cboYear.SelectedItem;

            // --- SỬA LỖI 3 (Logic Model) ---
            List<Bill> bills = _billService.GetBillsByMonth(month, year, _ownerId); // Sửa tên hàm
            PopulateBills(bills);
            // --- HẾT SỬA ---

            await Task.CompletedTask;
        }

        private void LoadUnpaidBills()
        {
            if (_ownerId == Guid.Empty) return;

            // --- SỬA LỖI 3 (Logic Model) ---
            List<Bill> bills = _billService.GetUnpaidBills(_ownerId); // Sửa tên hàm
            PopulateBills(bills);
            // --- HẾT SỬA ---
        }

        private void PopulateBills(List<Bill> bills)
        {
            flowPanelBills.Controls.Clear();
            if (bills == null || bills.Count == 0)
            {
                return;
            }

            foreach (var bill in bills)
            {
                // (Giả sử ucBillCard tồn tại và đã được cập nhật Model mới)
                var card = new ucBillCard(bill);
                // card.SendBillClicked += Card_OnSendBillClicked; // (Logic Status đã bị xóa)
                card.ExportPDFClicked += Card_OnExportPDFClicked;

                // (Sự kiện mới để mở Form Edit)
                //card.EditDetailsClicked += Card_OnEditDetailsClicked;

                flowPanelBills.Controls.Add(card);
            }
        }

        private void BtnGenerateBills_Click(object sender, EventArgs e)
        {
            // --- SỬA LỖI 2 (Encoding) ---
            var confirm = MessageBox.Show($"Bạn có chắc muốn tạo HĐ nháp cho tháng {DateTime.Now:MM/yyyy}?",
                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // Sửa tên hàm
                bool success = _billService.GenerateMonthlyBills(_ownerId, DateTime.Now.Month, DateTime.Now.Year);
                if (success)
                {
                    MessageBox.Show("Tạo HĐ nháp thành công!");
                    LoadBillsByMonth();
                }
                else
                {
                    MessageBox.Show("Tạo HĐ thất bại.");
                }
            }
        }

        //private void Card_OnEditDetailsClicked(object sender, Guid billId)
        //{
        //    // Mở Form chúng ta đã tạo ở lượt trước
        //    using (FormEditBillDetails frm = new FormEditBillDetails(billId))
        //    {
        //        if (frm.ShowDialog() == DialogResult.OK)
        //        {
        //            // Tải lại danh sách
        //            LoadBillsByMonth();
        //        }
        //    }
        //}

        private void Card_OnExportPDFClicked(object sender, Guid billId)
        {
            _billService.ExportBillToPDF(billId);
        }

        private void BtnConfirmPayment_Click(object sender, EventArgs e)
        {
            // (FormConfirmPayment này đã bị xóa vì logic không còn phù hợp Model)
            // var formConfirm = new FormConfirmPayment(_ownerId);
            // formConfirm.ShowDialog();

            // Thay vào đó, bạn có thể muốn mở Form "Nhập Excel" ở đây
            MessageBox.Show("Chức năng này đã bị vô hiệu hóa do thay đổi Model.\n(Logic Payment 1-1 thay thế Status).");

            LoadBillsByMonth();
        }
    }
}