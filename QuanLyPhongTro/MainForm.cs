using QuanLyPhongTro.Model;
using QuanLyPhongTro.src.Mediator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongTro
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            Name = "MainForm";
            System.Diagnostics.Debug.WriteLine($"[-- {Name} --] Mediator has code: {Mediator.Instance.GetHashCode()}");
            InitializeComponent();
            //Mediator.Instance.Register<Control>("MainForm", async (comp) =>
            //{
            //    await getData(comp);
            //});

        }

        private async void button1_Click(object sender, EventArgs a)
        {
            //await Mediator.Instance.PublishForm<string>("BillDetailControl", "Unpaid", async (control) =>
            //{
            //    await getData(control);
            //});
            int item = 5;
            panel01.Controls.Clear();
            foreach (Control control in panel01.Controls)
            {
                control.Dispose();
            }
            List<Bill> bills = new List<Bill>();
            for (int i = 0; i < item; i++)
            {
                Bill b = new Bill();
                b.Id = Guid.NewGuid();
                b.Status = "Unpaid";
                b.TotalMoney = 100000 + i * 10000;
                bills.Add(b);
                System.Diagnostics.Debug.WriteLine($"Created Bill with Id: {b.Id}");
            }
            try
            {
                await Mediator.Instance.PublishList<Bill>("BillControl", bills, (controls) =>
                {
                    foreach (var control in controls)
                    {
                        panel01.SuspendLayout();
                        //Task.Delay(100).Wait();
                        panel01.Controls.Add(control);
                        panel01.ResumeLayout();
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("MainForm: " + ex.Message);
            }
        }

        private async Task getData(Control component)
        {
            try
            {
                if (component == null)
                {
                    System.Diagnostics.Debug.WriteLine("getData: component is null");
                }
                if(panel01.InvokeRequired)
                {
                    panel01.Invoke(new Action(() =>
                    {
                        panel01.SuspendLayout();
                        panel01.Controls.Add(component);
                        System.Diagnostics.Debug.WriteLine("Added component to panel01");
                        panel01.ResumeLayout();
                    }));
                }
                    panel01.Controls.Add(component);
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                MessageBox.Show("MainForm: " + ex.Message);
            }
        }
    }
}
