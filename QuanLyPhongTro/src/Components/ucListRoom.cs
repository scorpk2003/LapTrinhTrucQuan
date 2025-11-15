using QuanLyPhongTro.Model;
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
        private Room room_session = new();
        public ucListRoom()
        {
            InitializeComponent();
            Mediator.Mediator.Instance.Register<Room>(Name, async (message) =>
            {
                room_session = message;
                await GetRoom();
            });
        }

        private async Task GetRoom()
        {
            name_lr.Text = room_session?.Name;
            name_add.Text = room_session?.Address;
            name_owr.Text = room_session?.Owner?.Username;
            if(room_session?.Status == "Còn Trống")
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
    }
}
