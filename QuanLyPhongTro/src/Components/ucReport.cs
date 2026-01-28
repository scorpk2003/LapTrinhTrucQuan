using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.src.Models;
using QuanLyPhongTro.src.Services1;
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
        private Room report_session = new();
        public ucReport()
        {
            InitializeComponent();
            Name = "ucReport";

            // Debug Mediator
            System.Diagnostics.Debug.WriteLine($"[-- {Name} --] Mediator instance: {Mediator.Mediator.Instance.GetHashCode()}");

            // Đăng ký nhận dữ liệu Report từ Mediator
            Mediator.Mediator.Instance.Register<Room>(Name, async (model) =>
            {
                if (model != null)
                    report_session = model;

                await BindReport(report_session);
            });
        }

        // Bind dữ liệu Report lên các control
        private async Task BindReport(Room r)
        {
            try
            {
                if (r == null)
                    throw new Exception("Report model is NULL");

                //name_room.Text = r.IdRoomNavigation?.Name ?? "Room";
                //name_usr.Text = r.IdReporterNavigation?.Username ?? "User";
                name_room.Text = r.Name;
                name_usr.Text = r.Contracts.First().IdRenterNavigation!.Username;

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
                AppContextDB db = new AppContextDB();
                var newReport = new Report
                {
                    Id = Guid.NewGuid(),
                    IdReporter = report_session.Contracts.First().IdRenter,
                    IdRoom = report_session.Id,
                    Title = tb_title.Text,
                    Description = des_rtxt.Text.Trim(),
                    DateCreated = DateTime.Now,
                    Status = State.Pending,
                    Notice = new Notice()
                    {
                        Title = tb_title.Text,
                        Status = State.Pending,
                    },
                    IdReporterNavigation = db.People.Find(report_session.Contracts.First().IdRenter),
                    IdRoomNavigation = report_session,
                };

                // Gọi service để lưu
                ReportService reportService = new ReportService();
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
