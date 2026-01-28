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

namespace QuanLyPhongTro.src
{
    public partial class ucListRoom : UserControl
    {
        private ListRoom room_session = new();
        public ucListRoom()
        {
            InitializeComponent();
            Name = "ucListRoom" + Guid.NewGuid().ToString().Substring(0, 4);
            Mediator.Mediator.Instance.Register<ListRoom>(Name, async (message) =>
            {
                room_session = message;
                await GetRoom();
            });
            this.Click += async (s, e) => await ListRoom_Click();
        }

        private async Task GetRoom()
        {
            name_lr.Text = room_session?.Name;
            name_add.Text = room_session?.Address;
            name_owr.Text = room_session?.IdOwnerNavigation.Username;
            if(room_session?.Status == State.Empty)
            {
                stat.Text = room_session.Status;
                stat.BackColor = Color.Green;
            }
            else
            {
                stat.Text = room_session?.Status;
                stat.BackColor = Color.Red;
            }
            await Task.CompletedTask;
        }

        private async Task ListRoom_Click()
        {
            if (room_session.Status == State.Full
                && UserSession.UserSession.Instance._user!.Role != "Owner")
            {
                MessageBox.Show("Dãy trọ đã hết phòng", "Hết Phòng", MessageBoxButtons.OK);
                await Task.CompletedTask;
            }
            // publish here
            await Task.CompletedTask;
        }
    }
}
