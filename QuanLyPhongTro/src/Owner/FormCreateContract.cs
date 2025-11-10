using QuanLyPhongTro.Model;
using QuanLyPhongTro.Services;
using System;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class FormCreateContract : Form
    {
        private readonly BookingRequest _request; // Lưu yêu cầu gốc
        private readonly ContractService _contractService;
        private readonly BookingRequestService _requestService;

        /// <summary>
        /// Constructor này dùng để TẠO MỚI (chưa làm)
        /// </summary>
        public FormCreateContract(Guid ownerId)
        {
            InitializeComponent();
            // (Code cho phép chủ trọ tự chọn phòng, tự chọn người thuê)
        }

        /// <summary>
        /// Constructor này dùng để DUYỆT (tự điền)
        /// </summary>
        public FormCreateContract(BookingRequest request)
        {
            InitializeComponent();
            _request = request;
            _contractService = new ContractService();
            _requestService = new BookingRequestService();

            this.Load += FormCreateContract_Load;
            this.btnSave.Click += BtnSave_Click;
            this.btnCancel.Click += (s, e) => this.Close();
        }

        private void FormCreateContract_Load(object sender, EventArgs e)
        {
            // Tự động điền thông tin từ Yêu cầu
            txtRoom.Text = _request.Room.Name;
            txtRenter.Text = _request.Renter.Username;
            dtpStartDate.Value = _request.DesiredStartDate;
            dtpEndDate.Value = _request.DesiredStartDate.AddMonths(_request.DesiredDurationMonths);

            // (Chủ trọ tự nhập tiền cọc)
            numDeposit.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 1. Tạo đối tượng Contract
            var contract = new Contract
            {
                IdRoom = _request.IdRoom,
                IdRenter = _request.IdRenter,
                StartDate = dtpStartDate.Value,
                EndDate = dtpEndDate.Value,
                Deposit = numDeposit.Value,
                Status = "Active" // Sẽ được service gán
            };

            // 2. Gọi Service để tạo HĐ (và cập nhật phòng)
            bool success = _contractService.CreateContract(contract);

            if (success)
            {
                // 3. Cập nhật Yêu cầu (Request) thành "Approved"
                _requestService.UpdateRequestStatus(_request.Id, "Approved");

                MessageBox.Show("Tạo hợp đồng thành công! Phòng đã được cập nhật trạng thái 'Đã thuê'.", "Thành công");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tạo hợp đồng thất bại. Phòng có thể đã được thuê trong lúc bạn xét duyệt.", "Lỗi");
            }
        }
    }
}