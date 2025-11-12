using QuanLyPhongTro.src.Test.Model;
using QuanLyPhongTro.src.Mediator;
using QuanLyPhongTro.src.Test.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class ucMyBills : UserControl
    {
        private readonly BillService _billService;
        private Guid? _renterId;

        public ucMyBills()
        {
            InitializeComponent();
            _billService = new BillService();

            // Đăng ký nhận Hợp đồng
            Mediator.Instance.Register<Contract>("UcMyBills", (contract) =>
            {
                _renterId = contract.IdRenter;
                LoadData(); // Tải dữ liệu
                return Task.CompletedTask;
            });

            this.Load += UcMyBills_Load;
        }

        private void UcMyBills_Load(object sender, EventArgs e)
        {
            SetupDgv();
        }

        private void SetupDgv()
        {
            dgvBills.AutoGenerateColumns = false;
            dgvBills.Columns.Clear();
            dgvBills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvBills.Columns.Add("Title", "Hóa đơn");
            dgvBills.Columns.Add("RoomName", "Phòng");
            dgvBills.Columns.Add("Total", "Tổng tiền");
            dgvBills.Columns.Add("Status", "Trạng thái");

            dgvBills.Columns["Total"].DefaultCellStyle.Format = "N0";
        }

        public void LoadData()
        {
            if (_renterId == Guid.Empty) return;

            var bills = _billService.GetBillsByRenter(_renterId.Value);
            dgvBills.Rows.Clear();

            foreach (var bill in bills)
            {
                dgvBills.Rows.Add(
                    $"Hóa đơn tháng {bill.PaymentDate:MM/yyyy}",
                    bill.Room?.Name,
                    bill.TotalMoney,
                    bill.Status
                );
            }
        }
    }
}