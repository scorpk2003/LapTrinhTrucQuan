using QuanLyPhongTro.src.Services1;
using QuanLyPhongTro.src.Mediator;
using QuanLyPhongTro.src.Models;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class ucMyContract : UserControl
    {
        private Contract _contract;
        private readonly ReportService _reportService;

        public ucMyContract()
        {
            InitializeComponent();
            _reportService = new ReportService();

            Mediator.Instance.Register<Contract>("UcMyContract", (contract) =>
            {
                _contract = contract;
                LoadData();
                return Task.CompletedTask;
            });

            this.Load += (s, e) => { /* placeholder to ensure InitializeComponent ran */ };
            this.btnRequestRenewal.Click += BtnRequestRenewal_Click;
            this.btnRequestTermination.Click += BtnRequestTermination_Click;
            this.picContractImage.Click += PicContractImage_Click;
        }

        public void LoadData()
        {
            if (_contract == null) return;
            lblStartDate.Text = $"Ngày bắt đầu: {_contract.StartDate.Value.ToString("dd/MM/yyyy")}";
            lblEndDate.Text = $"Ngày kết thúc: {_contract.EndDate.Value.ToString("dd/MM/yyyy")}";
            lblDeposit.Text = $"Tiền cọc: {_contract.Deposit:N0} VND";
            
            // Load và hiển thị ảnh hợp đồng
            LoadContractImage();
        }

        private void LoadContractImage()
        {
            try
            {
                // Kiểm tra xem hợp đồng có ảnh không
                if (string.IsNullOrEmpty(_contract.ImageUrl))
                {
                    // Không có ảnh
                    picContractImage.Image = null;
                    picContractImage.Visible = false;
                    lblNoImage.Visible = true;
                    lblNoImage.BringToFront();
                    return;
                }

                // Tạo đường dẫn đầy đủ đến file ảnh
                string fullPath = Path.Combine(Application.StartupPath, _contract.ImageUrl);

                // Kiểm tra file có tồn tại không
                if (File.Exists(fullPath))
                {
                    // Dispose ảnh cũ nếu có
                    if (picContractImage.Image != null)
                    {
                        picContractImage.Image.Dispose();
                    }

                    // Load ảnh mới
                    using (var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                    {
                        picContractImage.Image = Image.FromStream(fs);
                    }
                    
                    picContractImage.Visible = true;
                    lblNoImage.Visible = false;
                }
                else
                {
                    // File không tồn tại
                    picContractImage.Image = null;
                    picContractImage.Visible = false;
                    lblNoImage.Text = "Ảnh hợp đồng không tìm thấy";
                    lblNoImage.Visible = true;
                    lblNoImage.BringToFront();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi load ảnh hợp đồng: {ex.Message}");
                picContractImage.Image = null;
                picContractImage.Visible = false;
                lblNoImage.Text = "Lỗi khi tải ảnh hợp đồng";
                lblNoImage.Visible = true;
                lblNoImage.BringToFront();
            }
        }

        private void PicContractImage_Click(object sender, EventArgs e)
        {
            // Cho phép xem ảnh full size khi click vào
            if (picContractImage.Image != null)
            {
                using (Form fullSizeForm = new Form())
                {
                    fullSizeForm.Text = "Ảnh Hợp đồng - Xem toàn màn hình";
                    fullSizeForm.Size = new Size(1000, 800);
                    fullSizeForm.StartPosition = FormStartPosition.CenterParent;
                    fullSizeForm.FormBorderStyle = FormBorderStyle.Sizable;

                    PictureBox fullSizePic = new PictureBox
                    {
                        Dock = DockStyle.Fill,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Image = picContractImage.Image
                    };

                    fullSizeForm.Controls.Add(fullSizePic);
                    fullSizeForm.ShowDialog(this);
                }
            }
        }

        private void BtnRequestRenewal_Click(object sender, EventArgs e)
        {
            using (FormRenewContract frm = new FormRenewContract(12, "Gửi Yêu cầu Gia hạn"))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int months = frm.MonthsToAdd;
                    SendRequest("Yêu cầu Gia hạn Hợp đồng",
                        $"Tôi muốn gia hạn hợp đồng thêm {months} tháng.");
                }
            }
        }

        private void BtnRequestTermination_Click(object sender, EventArgs e)
        {
            SendRequest("Yêu cầu Chấm dứt Hợp đồng",
                "Tôi muốn chấm dứt hợp đồng vào ngày cuối tháng này.");
        }

        private void SendRequest(string title, string description)
        {
            var confirm = MessageBox.Show($"Bạn có chắc muốn gửi '{title}' đến chủ trọ?",
                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.No) return;

            if (!_contract.IdRoom.HasValue || !_contract.IdRenter.HasValue)
            {
                MessageBox.Show("Lỗi: Hợp đồng không liên kết với phòng hoặc người thuê.");
                return;
            }

            var report = new Report
            {
                Title = title,
                Description = description,
                IdRoom = _contract.IdRoom.Value,
                IdReporter = _contract.IdRenter.Value,
                Status = "Pending"
            };

            bool success = _reportService.CreateReport(report);
            if (success)
                MessageBox.Show("Gửi yêu cầu thành công!", "Thành công");
            else
                MessageBox.Show("Gửi yêu cầu thất bại.", "Lỗi");
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            // Dispose ảnh khi control bị destroy
            if (picContractImage.Image != null)
            {
                picContractImage.Image.Dispose();
                picContractImage.Image = null;
            }
            base.OnHandleDestroyed(e);
        }
    }
}