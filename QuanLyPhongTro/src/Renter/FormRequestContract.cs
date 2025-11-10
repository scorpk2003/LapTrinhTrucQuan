using QuanLyPhongTro.Model;
using QuanLyPhongTro.Services;
using System;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class FormRequestContract : Form
    {
        private readonly Guid _renterId;
        private readonly Room _room;
        private readonly BookingRequestService _requestService;

        public FormRequestContract(Guid renterId, Room room)
        {
            InitializeComponent();
            _renterId = renterId;
            _room = room;
            _requestService = new BookingRequestService();

            this.Load += FormRequestContract_Load;
            this.btnSendRequest.Click += BtnSendRequest_Click;
            this.btnCancel.Click += (s, e) => this.Close();
        }

        private void FormRequestContract_Load(object sender, EventArgs e)
        {
            lblRoomName.Text = _room.Name;
            dtpStartDate.Value = DateTime.Now.AddDays(1); // Mặc định là ngày mai
            cboDuration.SelectedIndex = 1; // Mặc định 12 tháng
        }

        private void BtnSendRequest_Click(object sender, EventArgs e)
        {
            // 1. Validate
            int duration = 0;
            if (cboDuration.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn thời hạn thuê.");
                return;
            }
            // "12 tháng" -> "12"
            duration = int.Parse(cboDuration.SelectedItem.ToString().Split(' ')[0]);

            // 2. Tạo đối tượng
            var request = new BookingRequest
            {
                IdRenter = _renterId,
                IdRoom = _room.Id,
                DesiredStartDate = dtpStartDate.Value,
                DesiredDurationMonths = duration,
                Note = txtNote.Text,
                Status = "Pending"
            };

            // 3. Gọi Service
            bool success = _requestService.CreateRequest(request);

            if (success)
            {
                MessageBox.Show("Gửi yêu cầu thành công! Chủ trọ sẽ sớm liên hệ với bạn.", "Thành công");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Gửi yêu cầu thất bại. Vui lòng thử lại.", "Lỗi");
            }
        }
    }
}