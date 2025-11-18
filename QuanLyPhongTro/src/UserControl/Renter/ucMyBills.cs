using QuanLyPhongTro.src.Services1;
using QuanLyPhongTro.src.Mediator;
using QuanLyPhongTro.src.Models;
using System;
using System.Drawing; // <-- Thêm
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

            // Ensure columns are ready even if mediator publishes before Load event
            if (dgvBills.Columns.Count == 0)
                SetupDgv();

            Mediator.Instance.Register<Contract>("UcMyBills", (contract) =>
            {
                _renterId = contract.IdRenter;
                // Guard: make sure columns exist
                if (dgvBills.Columns.Count == 0)
                    SetupDgv();
                LoadData();
                return Task.CompletedTask;
            });

            this.Load += UcMyBills_Load;
            this.dgvBills.CellDoubleClick += DgvBills_CellDoubleClick;
        }

        private void UcMyBills_Load(object sender, EventArgs e)
        {
            if (dgvBills.Columns.Count == 0)
                SetupDgv();
        }

        private void SetupDgv()
        {
            dgvBills.AutoGenerateColumns = false;
            dgvBills.Columns.Clear();
            dgvBills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var colId = new DataGridViewTextBoxColumn { Name = "BillId", Visible = false };
            dgvBills.Columns.Add(colId);

            dgvBills.Columns.Add("Title", "Hóa đơn");
            dgvBills.Columns.Add("RoomName", "Phòng");
            dgvBills.Columns.Add("Total", "Tổng tiền");
            dgvBills.Columns.Add("Status", "Trạng thái");

            dgvBills.Columns["Total"].DefaultCellStyle.Format = "N0";
        }

        public async void LoadData()
        {
            if (_renterId == Guid.Empty || !_renterId.HasValue) return;

            // Guard: ensure columns exist
            if (dgvBills.Columns.Count == 0)
                SetupDgv();

            var bills = _billService.GetBillsByRenter(_renterId.Value);
            dgvBills.Rows.Clear();

            await Mediator.Instance.PublishList<Bill>("ucBill", bills, async (controls) =>
            {
                foreach (var control in controls)
                    this.Controls.Add(control);
            });

            //foreach (var bill in bills)
            //{
            //    string statusText;
            //    if (bill.Payment == null)
            //        statusText = "Chưa thanh toán";
            //    else if (bill.Payment.Amount < bill.TotalMoney)
            //        statusText = $"Đã trả {bill.Payment.Amount:N0}";
            //    else
            //        statusText = "Đã thanh toán";


            //    dgvBills.Rows.Add(
            //        bill.Id,
            //        $"Hóa đơn tháng {bill.PaymentDate.Value.ToString("MM/yyyy")}", 
            //        bill.IdRoomNavigation?.Name, 
            //        bill.TotalMoney,
            //        statusText 
            //    );
            //}
        }

        private void DgvBills_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Guid billId = (Guid)dgvBills.Rows[e.RowIndex].Cells["BillId"].Value;

            var formDetail = new FormBillDetail(billId);
            if (formDetail.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}