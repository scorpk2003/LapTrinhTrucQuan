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
    public partial class ucNotice : UserControl
    {
        private Notice notice_session = new();
        public ucNotice()
        {
            InitializeComponent();
            Name = "ucNotice" + Guid.NewGuid().ToString().Substring(0, 4);
            Mediator.Mediator.Instance.Register<Notice>(Name, async (message) =>
            {
                notice_session = message;
                switch (notice_session.Status)
                {
                    case State.Handled:
                        this.BackColor = AppColors.Success;
                        break;
                    case State.Recv:
                        this.BackColor = AppColors.Read;
                        break;
                    default:
                        this.BackColor = AppColors.Background;
                        break;
                }
                title_lb.Text = notice_session.Title;
                await Task.CompletedTask;
            });
        }

        private async Task stat_btn_Click(object sender, EventArgs e)
        {
            ReportService report = new();
            Report? rp;
            rp = report.GetReport(notice_session.Id!);
            await Mediator.Mediator.Instance.Publish<Report>("ucReport", rp);
        }
    }
}
