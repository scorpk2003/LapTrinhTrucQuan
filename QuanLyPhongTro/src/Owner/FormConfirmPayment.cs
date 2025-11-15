using QuanLyPhongTro.Model;
using QuanLyPhongTro.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class FormConfirmPayment : Form
    {
        private readonly BillService _billService;
        private readonly Guid _ownerId;

        public FormConfirmPayment(Guid ownerId)
        {
            InitializeComponent();
            _billService = new BillService();
            _ownerId = ownerId;

            this.Load += FormConfirmPayment_Load;
            this.btnConfirm.Click += BtnConfirm_Click;
            this.btnClose.Click += (s, e) => this.Close();
        }

        private void FormConfirmPayment_Load(object sender, EventArgs e)
        {
            SetupDgv();
            LoadPendingPayments();
        }

        private void SetupDgv()
        {
            dgvPendingPayments.AutoGenerateColumns = false;
            dgvPendingPayments.Columns.Clear();

            dgvPendingPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BillId",
                Visible = false
            });

            dgvPendingPayments.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Select",
                HeaderText = "Chọn",
                Width = 50
            });

            dgvPendingPayments.Columns.Add("RoomName", "Phòng");
            dgvPendingPayments.Columns.Add("RenterName", "Người thuê");
            dgvPendingPayments.Columns.Add("Amount", "Số tiền");
            dgvPendingPayments.Columns.Add("PaymentMethod", "Phương thức");
            dgvPendingPayments.Columns.Add("PaymentDate", "Ngày thanh toán");

            dgvPendingPayments.Columns["Amount"].DefaultCellStyle.Format = "N0";
        }

        private void LoadPendingPayments()
        {
            try
            {
                using (var context = new Data.AppContextDB())
                {
                    // Lấy các Payment chưa xác nhận (Status của Bill vẫn là "Sent" hoặc "Pending")
                    var pendingPayments = context.Payment
                        .Where(p => p.Bill.Room.IdOwner == _ownerId &&
                                    p.Bill.Status != "Paid")
                        .Select(p => new
                        {
                            BillId = p.IdBill,
                            RoomName = p.Bill.Room.Name,
                            RenterName = p.Bill.Person.PersonDetail.Name ?? p.Bill.Person.Username,
                            Amount = p.Amount,
                            PaymentMethod = p.PaymentMethod,
                            PaymentDate = p.PaymentDate
                        })
                        .ToList();

                    dgvPendingPayments.Rows.Clear();

                    foreach (var payment in pendingPayments)
                    {
                        dgvPendingPayments.Rows.Add(
                            payment.BillId,
                            false, // Checkbox chưa chọn
                            payment.RoomName,
                            payment.RenterName,
                            payment.Amount,
                            payment.PaymentMethod,
                            payment.PaymentDate.ToString("dd/MM/yyyy HH:mm")
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}");
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            int confirmedCount = 0;

            foreach (DataGridViewRow row in dgvPendingPayments.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["Select"].Value);

                if (isSelected)
                {
                    Guid billId = (Guid)row.Cells["BillId"].Value;

                    // Cập nhật trạng thái Bill thành "Paid"
                    bool success = _billService.UpdateBillStatus(billId, "Paid");

                    if (success)
                    {
                        confirmedCount++;
                    }
                }
            }

            if (confirmedCount > 0)
            {
                MessageBox.Show($"Đã xác nhận {confirmedCount} thanh toán!");
                LoadPendingPayments(); // Reload danh sách
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 thanh toán để xác nhận!");
            }
        }

        private void FormConfirmPayment_Load_1(object sender, EventArgs e)
        {

        }
    }
}
