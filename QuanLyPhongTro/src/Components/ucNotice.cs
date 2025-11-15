using QuanLyPhongTro.src.Test;
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
            Name = "ucNotice" + Guid.NewGuid();
            Mediator.Mediator.Instance.Register<Notice>(Name, async (message) =>
            {
                notice_session = message;
                switch (notice_session.Status)
                {
                    case "Đã xử lí":
                        this.BackColor = AppColors.Read;
                        break;
                    case "Đã Đọc":
                        this.BackColor = AppColors.Success;
                        break;
                    default:
                        this.BackColor = AppColors.Fail;
                        break;
                }
                title_lb.Text = notice_session.Title;
                await Task.CompletedTask;
            });
        }

        private async void stat_btn_Click(object sender, EventArgs e)
        {
            if (!Mediator.Mediator.Instance.TryLock("ucReport")) return;
            Report rp = new();
            await Mediator.Mediator.Instance.Publish<Report>("ucReport", rp);
        }
    }
}
