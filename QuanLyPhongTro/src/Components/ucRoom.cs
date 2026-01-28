using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyPhongTro.src.Models;

namespace QuanLyPhongTro.src.Components
{
    public partial class ucRoom : UserControl
    {
        // Sử dụng một biến nội bộ để lưu dữ liệu Room
        // **Lưu ý: Bạn cần thay thế 'Room' bằng 'RoomDetail' nếu bạn có lớp chi tiết riêng.**
        private Room? room_session;

        // Constructor
        public ucRoom()
        {
            InitializeComponent();

            // Đặt tên cho UserControl để Mediator nhận diện
            Name = "ucRoom" + Guid.NewGuid().ToString().Substring(0, 4);

            System.Diagnostics.Debug.WriteLine($"[-- {Name} --] UserControl Initialized.");

            // Đăng ký nhận dữ liệu từ Mediator (Tương tự như ucUser)
            // Giả sử Mediator truyền vào đối tượng Room
            Mediator.Mediator.Instance.Register<Room>(Name, async (model) =>
            {
                if (model != null)
                    room_session = model;

                await BindRoom(room_session!);
            });

            // Đăng ký sự kiện click cho các controls
            this.Click += ucRoom_Click;
            room_name.Click += ucRoom_Click;
            state_radio.Click += ucRoom_Click;
        }

        // Bind dữ liệu từ Room lên các control (Tương tự như BindUser)
        private async Task BindRoom(Room r)
        {
            try
            {
                if (r == null)
                    throw new Exception("Room model is NULL");

                // 1. Cập nhật Tên phòng
                room_name.Text = r.Name;

                // 2. Cập nhật Trạng thái phòng và màu sắc
                string status = r.Status ?? "Không xác định";
                state_radio.Text = status;
                switch (r.Status)
                {
                    case State.Full:
                        this.BackColor = AppColors.Fail;
                        btSign.Enabled = false;
                        break;
                    case State.Room_Empty:
                        this.BackColor = AppColors.Success;
                        break;
                    default:
                        this.BackColor = AppColors.Background;
                        break;
                }

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                MessageBox.Show("RoomControl Bind Error: " + ex.Message);
            }
        }

        // Sự kiện Click: Mở form chi tiết phòng (Tương tự như btEdit_Click)
        private async void ucRoom_Click(object sender, EventArgs e)
        {
            if (room_session == null) return;

            if (!Mediator.Mediator.Instance.TryLock("ucRoomDetail")) return;

            Form Detail = new();
            Detail.AutoSize = true;

            await Mediator.Mediator.Instance.PublishForm<Room>("ucRoomDetail", 
                room_session, 
                async (detail) =>
                {
                    Detail.Controls.Add(detail);
                    Detail.FormClosed += (_, _) =>
                    {
                        Mediator.Mediator.Instance.ReleaseLock("ucRoomDetail");
                        Detail.Dispose();
                    };
                    Detail.Show();
                    await Task.CompletedTask;
                }
                );
        }
    }
}
