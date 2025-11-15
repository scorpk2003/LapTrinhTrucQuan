using QuanLyPhongTro.Model;
using QuanLyPhongTro.Services;
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
            // (Không cần set Culture ở đây nữa)
            InitializeComponent();
            _request = request;
            _contractService = new ContractService();
            _requestService = new BookingRequestService();

            // Gán sự kiện
            this.btnCreate.Click += BtnCreate_Click;
            this.btnCancel.Click += (s, e) => this.Close();

            // Tải dữ liệu từ Yêu cầu (Request)
            LoadDataFromRequest();
        }

        private void LoadDataFromRequest()
        {
            if (_request == null) return;

            lblRoomName.Text = _request.Room.Name;
            lblRenterName.Text = _request.Renter.Username;

            if (_request.DesiredStartDate > DateTime.Now)
                dtpStartDate.Value = _request.DesiredStartDate;

            // Gán giá trị cho ô số
            numDuration.Value = _request.DesiredDurationMonths;

            txtNote.Text = _request.Note;

            // Đặt tiền cọc mặc định
            if (_request.Room.Price.HasValue)
                nudDeposit.Value = _request.Room.Price.Value;
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày bắt đầu không thể là một ngày trong quá khứ.");
                return;
            }

            // Đọc giá trị từ ô số
            int duration = (int)numDuration.Value;

            Contract contract = new Contract
            {
                IdRoom = _request.IdRoom,
                IdRenter = _request.IdRenter,
                StartDate = dtpStartDate.Value.Date,
                EndDate = dtpStartDate.Value.Date.AddMonths(duration),
                Deposit = nudDeposit.Value,
                Note = txtNote.Text,
                Status = "Active"
            };

            // Gọi Service
            bool success = _contractService.CreateContract(contract);
            if (success)
            {
                // Cập nhật trạng thái của Yêu cầu (Request)
                _requestService.UpdateRequestStatus(_request.Id, "Approved");

                MessageBox.Show("Tạo hợp đồng thành công!");
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