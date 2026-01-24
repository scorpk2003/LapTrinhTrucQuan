using QuanLyPhongTro.src.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class ucReportItem : UserControl
    {
        public Report ReportData { get; private set; }
        private bool _isSelected = false;

        public ucReportItem()
        {
            InitializeComponent();
            WireClickPropagation();
        }

        public ucReportItem(Report report) : this()
        {
            ReportData = report;
            LoadReportData();
        }

        private void WireClickPropagation()
        {
            foreach (Control c in this.Controls)
            {
                c.Click += (s, e) => this.InvokeOnClick(this, e);
            }
        }

        private void LoadReportData()
        {
            if (ReportData == null) return;

            lblTitle.Text = ReportData.Title ?? "N/A";
            if (!string.IsNullOrEmpty(ReportData.Title))
                toolTip.SetToolTip(lblTitle, ReportData.Title);

            lblRoom.Text = $"🏠 Phòng: {ReportData.IdRoomNavigation?.Name ?? "N/A"}";

            lblDate.Text = ReportData.DateCreated.HasValue
                ? $"📅 {ReportData.DateCreated.Value:dd/MM/yyyy HH:mm}"
                : "📅 N/A";

            UpdateStatusDisplay();
        }

        private void UpdateStatusDisplay()
        {
            if (ReportData == null) return;

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
                    lblStatus.ForeColor = Color.FromArgb(39, 174, 96);
                    break;
                default:
                    lblStatus.Text = "● Không xác định";
                    lblStatus.ForeColor = Color.Gray;
                    break;
            }
        }

        public void UpdateStatus(string newStatus)
        {
            if (ReportData == null) return;
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
