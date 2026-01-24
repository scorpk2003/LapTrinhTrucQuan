using QuanLyPhongTro.src.Models;
using System.Drawing;

namespace QuanLyPhongTro
{
    public partial class ucIncidentItem : UserControl
    {
        public Report ReportData { get; private set; }
        private bool _isSelected = false;

        public ucIncidentItem(Report report)
        {
            InitializeComponent();
            ReportData = report;
            LoadData();

            // Gán sự kiện click cho tất cả control con để trải nghiệm mượt mà
            foreach (Control c in this.Controls)
            {
                c.Click += (s, e) => this.InvokeOnClick(this, e);
            }
        }

        private void LoadData()
        {
            lblTitle.Text = ReportData.Title;
            
            // Thêm tooltip để hiển thị toàn bộ tiêu đề khi hover
            if (!string.IsNullOrEmpty(ReportData.Title))
            {
                toolTip.SetToolTip(lblTitle, ReportData.Title);
            }
            
            lblRoom.Text = $"🏠 Phòng: {ReportData.IdRoomNavigation?.Name ?? "N/A"}";
            lblDate.Text = $"📅 {ReportData.DateCreated?.ToString("dd/MM/yyyy HH:mm")}";
            lblStatus.Text = ReportData.Status;
            UpdateStatusDisplay();
        }

        private void UpdateStatusDisplay()
        {
            switch (ReportData.Status)
            {
                case "Pending":
                    lblStatus.Text = "● Đang chờ";
                    lblStatus.ForeColor = Color.OrangeRed;
                    break;
                case "InProgress":
                    lblStatus.Text = "● Đang xử lý";
                    lblStatus.ForeColor = Color.Orange;
                    break;
                case "Resolved":
                    lblStatus.Text = "● Đã giải quyết";
                    lblStatus.ForeColor = Color.Green;
                    break;
            }
        }

        /// <summary>
        /// Cập nhật trạng thái của item mà không cần reload toàn bộ
        /// </summary>
        public void UpdateStatus(string newStatus)
        {
            ReportData.Status = newStatus;
            UpdateStatusDisplay();
        }

        public void SetSelected(bool selected)
        {
            _isSelected = selected;
            this.BackColor = selected ? Color.AliceBlue : Color.White;
            pnlBorder.BackColor = selected ? Color.DodgerBlue : Color.LightGray;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (!_isSelected) this.BackColor = Color.FromArgb(245, 245, 245);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (!_isSelected) this.BackColor = Color.White;
            base.OnMouseLeave(e);
        }
    }
}