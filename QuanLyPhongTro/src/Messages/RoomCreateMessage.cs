using QuanLyPhongTro.src.Model;

namespace QuanLyPhongTro.src.Messages
{
    // Đây là nội dung tin nhắn
    public class RoomCreatedMessage
    {
        public Room NewRoom { get; }

        public RoomCreatedMessage(Room newRoom)
        {
            NewRoom = newRoom;
        }
    }
}