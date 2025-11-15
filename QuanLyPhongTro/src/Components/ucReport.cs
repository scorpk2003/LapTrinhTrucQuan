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
    public partial class ucReport : Form
    {
        Report report_session = new();
        public ucReport()
        {
            InitializeComponent();

            Mediator.Mediator.Instance.Register<Report>("ucReport", async (report) =>
            {
                report_session = report;
                await Task.CompletedTask;
            });

            this.BeginInvoke(new Action(() =>
            {
                this.Activate();
            }));
        }
    }
}
