using QuanLyPhongTro.src.Services1;
using QuanLyPhongTro.src.Models;
using System;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class FormCreateContract : Form
    {
        private readonly BookingRequest _request;
        private readonly ContractService _contractService;
        private readonly BookingRequestService _requestService;

        public FormCreateContract(BookingRequest request)
        {
            InitializeComponent();
            _request = request;
            _contractService = new ContractService();
            _requestService = new BookingRequestService();

            this.btnCreate.Click += BtnCreate_Click;
            this.btnCancel.Click += (s, e) => this.Close();

            LoadDataFromRequest();
        }

        private void LoadDataFromRequest()
        {
            if (_request == null) return;

            lblRoomName.Text = _request.Room?.Name ?? "N/A";
            lblRenterName.Text = _request.Renter?.Username ?? "N/A";

            if (_request.DesiredStartDate > DateTime.Now)
                dtpStartDate.Value = _request.DesiredStartDate;

            numDuration.Value = _request.DesiredDurationMonths;
            txtNote.Text = _request.Note ?? string.Empty;

            if (_request.Room?.Price.HasValue == true)
                nudDeposit.Value = _request.Room.Price.Value;
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày bắt đầu không thể là một ngày trong quá khứ.");
                return;
            }

            int duration = (int)numDuration.Value;

            Contract contract = new Contract
            {
                IdRoom = _request.IdRoom,
                IdRenter = _request.IdRenter,
                StartDate = DateOnly.FromDateTime(dtpStartDate.Value.Date),
                EndDate = DateOnly.FromDateTime(dtpStartDate.Value.Date.AddMonths(duration)),
                Deposit = nudDeposit.Value,
                Status = "Tạm thời" // ✅ Thay đổi: Chờ Renter upload ảnh hợp đồng
            };

            // Gọi Service
            bool success = _contractService.CreateContract(contract);
            if (success)
            {
                // Cập nhật trạng thái của Yêu cầu (Request)
                _requestService.UpdateRequestStatus(_request.Id, "Approved");

                MessageBox.Show(
                    "Tạo hợp đồng thành công!\n\n" +
                    "Hợp đồng đang ở trạng thái 'Tạm thời'.\n" +
                    "Người thuê cần upload ảnh hợp đồng đã ký để kích hoạt.",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tạo hợp đồng thất bại! Phòng có thể đã được cho thuê.");
            }
        }
    }
}