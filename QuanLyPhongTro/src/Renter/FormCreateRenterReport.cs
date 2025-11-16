using QuanLyPhongTro.src.Test.Models;
using QuanLyPhongTro.Services;
using System;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class FormCreateRenterReport : Form
    {
        private readonly Contract _contract;
        private readonly ReportService _reportService;

        public FormCreateRenterReport(Contract contract)
        {
            InitializeComponent();
            _contract = contract;
            _reportService = new ReportService();

            this.btnSend.Click += BtnSend_Click;
            this.btnCancel.Click += (s, e) => this.Close();
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Vui lòng nhập cả Tiêu đề và Mô tả.");
                return;
            }

            if (!_contract.IdRoom.HasValue)
            {
                MessageBox.Show("Lỗi: Hợp đồng không liên kết với phòng hoặc người thuê."); // Sửa Encoding
                return;
            }

            var report = new Report
            {
                Title = txtTitle.Text,
                Description = txtDescription.Text,
                IdRoom = _contract.IdRoom.Value,
                IdReporter = _contract.IdRenter.Value,
                Status = "Pending"
            };

            bool success = _reportService.CreateReport(report);
            if (success)
            {
                MessageBox.Show("Gửi báo cáo thành công!", "Thành công");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Gửi báo cáo thất bại.", "Lỗi");
            }
        }
    }
}
