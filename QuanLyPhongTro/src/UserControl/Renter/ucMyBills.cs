using QuanLyPhongTro.Model;
using QuanLyPhongTro.src.Mediator;
using QuanLyPhongTro.Services;
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

            Mediator.Instance.Register<Contract>("UcMyBills", (contract) =>
            {
                _renterId = contract.IdRenter;
                LoadData();
                return Task.CompletedTask;
            });

            this.Load += UcMyBills_Load;
            
            this.dgvBills.CellDoubleClick += DgvBills_CellDoubleClick;
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

            var colId = new DataGridViewTextBoxColumn
            {
                Name = "BillId",
                Visible = false
            };
            dgvBills.Columns.Add(colId);

            dgvBills.Columns.Add("Title", "Hóa đơn");
            dgvBills.Columns.Add("RoomName", "Phòng");
            dgvBills.Columns.Add("Total", "Tổng tiền");
            dgvBills.Columns.Add("Status", "Trạng thái");

            dgvBills.Columns["Total"].DefaultCellStyle.Format = "N0";
        }

        public void LoadData()
        {
            if (_renterId == Guid.Empty) return;

            var bills = _billService.GetBillByRenter(_renterId.Value);
            dgvBills.Rows.Clear();

            foreach (var bill in bills)
            {
                dgvBills.Rows.Add(
                    bill.Id,
                    $"Hóa đơn tháng {bill.PaymentDate:MM/yyyy}",
                    bill.Room?.Name,
                    bill.TotalMoney,
                    bill.Status
                );
            }
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