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

namespace QuanLyPhongTro.src.Components
{
    public partial class ucRoomDetail : UserControl
    {
        private Room? room_session;
        public ucRoomDetail()
        {
            InitializeComponent();
            Mediator.Mediator.Instance.Register<Room>("ucRoomDetail", async (room) =>
            {
                room_session = room ?? new();
                await BindData();
            });
            
        }

        private async Task BindData()
        {
            name_opp.Text = room_session!.IdOwnerNavigation!.Username;
            room_name.Text = room_session.Name;
            if (room_session.Bills.First().IdPersonNavigation?.IdDetailNavigation?.Avatar != null && 
                room_session.Bills.First().IdPersonNavigation?.IdDetailNavigation?.Avatar?.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(room_session.Bills.First().IdPersonNavigation!.IdDetailNavigation!.Avatar!))
                {
                    avatar_img.Image = Image.FromStream(ms);
                }
            }
            else
            {
                avatar_img.Image = null;
            }
            tbNameuser.Text = room_session.Bills.First().IdPersonNavigation?.Username;
            tbdien.Text = room_session.
                await Task.CompletedTask;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RoomDetail_Load(object sender, EventArgs e)
        {
            //role = renter -> hide sign button
            //role = owner -> show sign button
            // Load Person avatar here
            /*
             * avatar != null ? avatar : default avatar
             */
        }
    }
}
