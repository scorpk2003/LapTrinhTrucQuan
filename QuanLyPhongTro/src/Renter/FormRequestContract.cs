using QuanLyPhongTro.src.Test.Models;
using QuanLyPhongTro.src.Test.Services;
using System;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class FormRequestContract : Form
    {
        private readonly Person _renter;
        private readonly Room _room;
        private readonly BookingRequestService _requestService;

        public FormRequestContract(Person renter, Room room)
        {
            InitializeComponent();
            _renter = renter;
            _room = room;
            _requestService = new BookingRequestService();

            this.btnSend.Click += BtnSend_Click;
            this.btnCancel.Click += (s, e) => this.Close();
            LoadDefaultData();
        }

        private void LoadDefaultData()
        {
            lblRoomName.Text = _room.Name;
            lblRenterName.Text = _renter.Username;
            dtpStartDate.Value = DateTime.Now.Date.AddDays(1);
            numDuration.Value = 12;
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày muốn thuê không được là một ngày trong quá khứ.");
                return;
            }

            int duration = (int)numDuration.Value;

            BookingRequest request = new BookingRequest
            {
                IdRoom = _room.Id,
                IdRenter = _renter.Id,
                DesiredStartDate = dtpStartDate.Value.Date,
                DesiredDurationMonths = duration,
                Note = txtNote.Text,
                Status = "Pending"
            };

            System.Diagnostics.Debug.WriteLine($"=== DEBUG REQUEST ===");
            System.Diagnostics.Debug.WriteLine($"IdRenter: {_renter.Id}");
            System.Diagnostics.Debug.WriteLine($"IdRoom: {_room.Id}");
            System.Diagnostics.Debug.WriteLine($"Renter Object: {_renter}");
            System.Diagnostics.Debug.WriteLine($"Room Object: {_room}");

            bool success = _requestService.CreateRequest(request);
            if (success)
            {
                MessageBox.Show("Gửi yêu cầu thành công vui lòng chờ xác nhận!.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Gửi yêu cầu thất bại (Có thể bạn đã gửi yêu cầu cho phòng này rồi).");
            }
        }
    }
}
