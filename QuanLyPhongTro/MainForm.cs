using QuanLyPhongTro.Model;
using QuanLyPhongTro.src.Mediator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class MainForm : Form
    {
        private readonly IMediator _mediator = Mediator.Instance;
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs a)
        {
            //panel01.Controls.Add(new Button());
            Bill b = new Bill();
            b.Id = Guid.NewGuid();
            b.Status = "Unpaid";
            b.TotalMoney = 100000;
            Console.WriteLine("Publishing BillControl");
            Task.Run(
                async () =>
                {
                    try
                    {
                        await _mediator.Publish<Bill>("BillControl", b);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error publishing BillControl: {ex.Message}");
                    }
                }
                );

        }

        private async Task getData(UserControl component)
        {
            panel01.Controls.Add(component);
            await Task.CompletedTask;
        }
    }
}
