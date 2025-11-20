using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.src.Models;
using QuanLyPhongTro.src.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro.src.Components
{
    public partial class ucReport : UserControl
    {
        private Report report_session = new();
        private readonly ReportService reportService; // service xử lý báo cáo

        public ucReport(ReportService reportService)
        {
            InitializeComponent();
            Name = "ucReport" + Guid.NewGuid().ToString().Substring(0, 4);

            this.reportService = reportService; // gán service

            // Debug Mediator
            System.Diagnostics.Debug.WriteLine($"[-- {Name} --] Mediator instance: {Mediator.Mediator.Instance.GetHashCode()}");

            // Đăng ký nhận dữ liệu Report từ Mediator
            Mediator.Mediator.Instance.Register<Report>(Name, async (model) =>
            {
                if (model != null)
                    report_session = model;

                await BindReport(report_session);
            });
        }

        // Bind dữ liệu Report lên các control
        private async Task BindReport(Report r)
        {
            try
            {
                if (r == null)
                    throw new Exception("Report model is NULL");

                name_room.Text = r.IdRoomNavigation?.Name ?? "Room";
                name_usr.Text = r.IdReporterNavigation?.Username ?? "User";

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ucReport Bind Error: " + ex.Message);
            }
        }

        // Button gửi báo cáo
        private async void send_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(des_rtxt.Text))
            {
                MessageBox.Show("Nội dung báo cáo không được bỏ trống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var newReport = new Report
                {
                    Id = Guid.NewGuid(),
                    IdReporter = report_session.IdReporter,
                    IdRoom = report_session.IdRoom,
                    Title = "Báo cáo phòng",
                    Description = des_rtxt.Text.Trim(),
                    DateCreated = DateTime.Now,
                    Status = "Pending"
                };

                // Gọi service để lưu
                reportService.CreateReport(newReport);

                MessageBox.Show("Gửi báo cáo thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                des_rtxt.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu báo cáo:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
