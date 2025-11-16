using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.src.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace QuanLyPhongTro.src.Components
{
    public partial class ucUser : UserControl
    {
        private PersonDetail user_session = new();

        // Constructor
        public ucUser()
        {
            InitializeComponent();
            Name = "ucUser" + Guid.NewGuid().ToString().Substring(0, 4);

            System.Diagnostics.Debug.WriteLine($"[-- {Name} --] Mediator instance: {Mediator.Mediator.Instance.GetHashCode()}");

            // Đăng ký nhận dữ liệu từ Mediator
            Mediator.Mediator.Instance.Register<PersonDetail>(Name, async (model) =>
            {
                if (model != null)
                    user_session = model;

                await BindUser(user_session);
            });
        }

        // Bind dữ liệu từ PersonDetail lên các control
        private async Task BindUser(PersonDetail p)
        {
            try
            {
                if (p == null)
                    throw new Exception("User model is NULL");

                tbName.Text = p.Name;
                tbCCCD.Text = p.Cccd;
                tbGender.Text = p.Gender;
                tbPhone.Text = p.Phone;
                tbEmail.Text = p.Gmail;

                if (p.Avatar != null && p.Avatar.Length > 0)
                    ptb_avatar.Image = ByteArrayToImage(p.Avatar);

                if (p.CccdImage != null && p.CccdImage.Length > 0)
                    ptbAfterCCCD.Image = ByteArrayToImage(p.CccdImage);

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                MessageBox.Show("UserControl Bind Error: " + ex.Message);
            }
        }

        // Sự kiện Edit: mở form chi tiết user
        private async void btEdit_Click(object sender, EventArgs e)
        {
            Form detailForm = new Form();
            detailForm.AutoSize = true;
            detailForm.Text = "User Detail";

            // Hiển thị thông tin trực tiếp trong các Label/TextBox
            Label lbName = new Label() { Left = 20, Top = 20, Width = 200, Text = "Name: " + user_session.Name };
            Label lbCCCD = new Label() { Left = 20, Top = 50, Width = 200, Text = "CCCD: " + user_session.Cccd };
            Label lbPhone = new Label() { Left = 20, Top = 80, Width = 200, Text = "Phone: " + user_session.Phone };
            detailForm.Controls.Add(lbName);
            detailForm.Controls.Add(lbCCCD);
            detailForm.Controls.Add(lbPhone);

            detailForm.Show();
            await Task.CompletedTask;
        }

        // Chuyển byte[] thành Image
        private Image ByteArrayToImage(byte[] bytes)
        {
            using MemoryStream ms = new MemoryStream(bytes);
            return Image.FromStream(ms);
        }

        // Optional: click vào CCCD image
        private void ptbAfterCCCD_Click(object sender, EventArgs e)
        {
            // Thêm xử lý nếu cần
        }
    }
}
