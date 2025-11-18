using QuanLyPhongTro.src.Models;

namespace QuanLyPhongTro.src.Messages
{
    public class RoomCreatedMessage
    {
        public Room NewRoom { get; }

        public RoomCreatedMessage(Room newRoom)
        {
            NewRoom = newRoom;
        }
    }
}
