using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.src.Test.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyPhongTro.Services
{
    public class RoomService
    {
        /// <summary>
        /// Tạo phòng mới và lưu các hình ảnh liên quan
        /// </summary>
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
                                        IdRoom = room.Id,
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

        /// <summary>
        /// Cập nhật thông tin TEXT (Tên, Giá, Trạng thái...)
        /// </summary>
        public bool UpdateRoom(Room roomData)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var existingRoom = context.Rooms.Find(roomData.Id);
                    if (existingRoom == null) return false;

                    // Cập nhật các thuộc tính
                    existingRoom.Name = roomData.Name;
                    existingRoom.Address = roomData.Address;
                    existingRoom.Price = roomData.Price;

                    existingRoom.Area = roomData.Area; 

                    existingRoom.Status = roomData.Status;

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

        /// <summary>
        /// Xóa mềm phòng (cập nhật Status = "Deleted")
        /// </summary>
        public bool DeleteRoom(Guid roomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var room = context.Rooms.Find(roomId);
                    if (room == null) return false;

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

        /// <summary>
        /// Lấy thông tin chi tiết một phòng (BAO GỒM ẢNH)
        /// </summary>
        public Room GetRoomWithDetails(Guid roomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var room = context.Rooms 
                        .Include(r => r.RoomImages)
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

        /// <summary>
        /// Lấy tất cả phòng của một chủ trọ
        /// </summary>
        public List<Room> GetAllRoomsByOwner(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Rooms
                        .Where(r => r.IdOwner == ownerId && r.Status != "Deleted")
                        .OrderBy(r => r.Name)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetAllRoomsByOwner: {ex.Message}");
                return new List<Room>();
            }
        }

        /// <summary>
        /// Thêm một ảnh mới vào phòng (dùng cho FormEditRoom)
        /// </summary>
        public RoomImage AddImageToRoom(Guid roomId, string imageUrl)
        {
            try
            {
                var newImage = new RoomImage
                {
                    IdRoom = roomId,
                    ImageUrl = imageUrl
                };
                using (var context = new AppContextDB())
                {
                    context.RoomImages.Add(newImage);
                    context.SaveChanges();
                    return newImage;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi AddImageToRoom: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Xóa một ảnh khỏi CSDL (dùng cho FormEditRoom)
        /// </summary>
        public bool DeleteRoomImage(Guid imageId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var image = context.RoomImages.Find(imageId);
                    if (image == null) return false;

                    context.RoomImages.Remove(image);
                    context.SaveChanges();

                    try
                    {
                        string fullPath = Path.Combine(Application.StartupPath, image.ImageUrl);
                        if (File.Exists(fullPath))
                        {
                            File.Delete(fullPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi xóa file ảnh: {ex.Message}");
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi DeleteRoomImage: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lấy tất cả các phòng đang "Còn trống"
        /// </summary>
        public List<Room> GetAllAvailableRooms()
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Rooms
                        .Include(r => r.RoomImages)
                        .Where(r => r.Status == "Trống")
                        .OrderBy(r => r.Price)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetAllAvailableRooms: {ex.Message}");
                return new List<Room>();
            }
        }
    }
}