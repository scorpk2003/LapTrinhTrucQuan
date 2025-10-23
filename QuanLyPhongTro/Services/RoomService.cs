using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.Data;
using QuanLyPhongTro.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyPhongTro.Services
{
    public class RoomService
    {
        // CreateRoom(Room) -> AddRoom, RoomDetail (Model của bạn là RoomImage)
        /// <summary>
        /// Tạo phòng mới và lưu các hình ảnh liên quan
        /// </summary>
        /// <param name="room">Đối tượng Room (đã có IdOwner, Name, Address...)</param>
        /// <param name="imageUrls">Danh sách đường dẫn (hoặc tên file) hình ảnh</param>
        /// <returns>True nếu tạo thành công</returns>
        public bool CreateRoom(Room room, List<string> imageUrls)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            // 1. Lưu phòng
                            context.Rooms.Add(room);
                            context.SaveChanges();

                            // 2. Lưu các hình ảnh
                            if (imageUrls != null && imageUrls.Count > 0)
                            {
                                foreach (var url in imageUrls)
                                {
                                    var roomImage = new RoomImage
                                    {
                                        IdRoom = room.Id, // Gán ID phòng vừa tạo
                                        ImageUrl = url
                                    };
                                    context.RoomImages.Add(roomImage);
                                }
                                context.SaveChanges();
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"Lỗi CreateRoom: {ex.Message}");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi CreateRoom (Outer): {ex.Message}");
                return false;
            }
        }

        // EditRoom(Room) -> UpdateRoom
        /// <summary>
        /// Cập nhật thông tin phòng
        /// </summary>
        /// <param name="roomData">Đối tượng Room chứa thông tin mới</param>
        /// <returns>True nếu cập nhật thành công</returns>
        public bool UpdateRoom(Room roomData)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var existingRoom = context.Rooms.Find(roomData.Id);
                    if (existingRoom == null)
                    {
                        return false; // Không tìm thấy phòng
                    }

                    // Cập nhật các thuộc tính
                    existingRoom.Name = roomData.Name;
                    existingRoom.Address = roomData.Address;
                    existingRoom.Price = roomData.Price;
                    existingRoom.Area = roomData.Area;
                    existingRoom.Status = roomData.Status;
                    // không cập nhật IdOwner ở đây trừ khi bạn muốn

                    context.Rooms.Update(existingRoom);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi UpdateRoom: {ex.Message}");
                return false;
            }
        }

        // DeleteRoom(IdRoom) -> DeleteRoom
        /// <summary>
        /// Xóa phòng (Khuyến nghị: nên dùng "Xóa mềm" bằng cách cập nhật Status)
        /// </summary>
        /// <param name="roomId">ID phòng cần xóa</param>
        /// <returns>True nếu thành công</returns>
        public bool DeleteRoom(Guid roomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var room = context.Rooms.Find(roomId);
                    if (room == null)
                    {
                        return false; // Không tìm thấy
                    }

                    // *** Cách 1: Xóa Cứng (Hard Delete) - Không khuyến khích ***
                    // context.Rooms.Remove(room);

                    // *** Cách 2: Xóa Mềm (Soft Delete) - Khuyến khích ***
                    // Giả sử "Deleted" là 1 trạng thái trong Status
                    room.Status = "Deleted";
                    context.Rooms.Update(room);

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi DeleteRoom: {ex.Message}");
                return false;
            }
        }

        // FindRoom(IdRoom) & RoomDetail(GetIdRoomDetail)
        /// <summary>
        /// Lấy thông tin chi tiết một phòng (bao gồm cả ảnh)
        /// </summary>
        /// <param name="roomId">ID phòng</param>
        /// <returns>Đối tượng Room (đã bao gồm danh sách ảnh)</returns>
        public Room GetRoomWithDetails(Guid roomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var room = context.Rooms
                        // .Include(r => r.Owner) // Lấy cả thông tin chủ
                        // .Include(r => r.RoomImages) // Model của bạn chưa có ICollection<RoomImage>
                        .FirstOrDefault(r => r.Id == roomId);

                    return room;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetRoomWithDetails: {ex.Message}");
                return null;
            }
        }
    }
}