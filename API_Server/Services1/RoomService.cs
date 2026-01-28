using Microsoft.EntityFrameworkCore;
using API_Server.src.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API_Server.src.Services1
{
    public class RoomService
    {
        /// <summary>
        /// Tạo phòng mới và lưu các hình ảnh liên quan
        /// </summary>
        public async Task<bool> CreateRoomAsync(Room room, List<string> imageUrls)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    using (var transaction = await context.Database.BeginTransactionAsync()) // ⭐ BeginTransaction() → BeginTransactionAsync()
                    {
                        try
                        {
                            // 1. Lưu phòng
                            await context.Rooms.AddAsync(room); // ⭐ Add() → AddAsync()
                            await context.SaveChangesAsync(); // ⭐ SaveChanges() → SaveChangesAsync()

                            // 2. Lưu các hình ảnh
                            if (imageUrls != null && imageUrls.Count > 0)
                            {
                                foreach (var url in imageUrls)
                                {
                                    var roomImage = new RoomImage
                                    {
                                        Id = Guid.NewGuid(),
                                        IdRoom = room.Id,
                                        ImageUrl = url
                                    };
                                    await context.RoomImages.AddAsync(roomImage); // ⭐ Add() → AddAsync()
                                }
                                await context.SaveChangesAsync(); // ⭐ SaveChanges() → SaveChangesAsync()
                            }

                            await transaction.CommitAsync(); // ⭐ Commit() → CommitAsync()
                            return true;
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync(); // ⭐ Rollback() → RollbackAsync()
                            Console.WriteLine($"Lỗi CreateRoomAsync: {ex.Message}");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi CreateRoomAsync (Outer): {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lấy Dãy Trọ
        /// </summary>
        public async Task<ListRoom?> GetListRoomAsync(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.ListRooms // ⭐ Thêm await
                        .FirstOrDefaultAsync(p => p.IdOwnerNavigation!.Id == ownerId); // ⭐ FirstOrDefault() → FirstOrDefaultAsync()
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetListRoomAsync: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Cập nhật thông tin TEXT (Tên, Giá, Trạng thái...)
        /// </summary>
        public async Task<bool> UpdateRoomAsync(Room roomData)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var existingRoom = await context.Rooms.FindAsync(roomData.Id); // ⭐ Find() → FindAsync()
                    if (existingRoom == null) return false;

                    // Cập nhật các thuộc tính
                    existingRoom.Name = roomData.Name;
                    existingRoom.Price = roomData.Price;
                    existingRoom.Area = roomData.Area;
                    existingRoom.Status = roomData.Status;
                    existingRoom.Description = roomData.Description;

                    context.Rooms.Update(existingRoom);
                    await context.SaveChangesAsync(); // ⭐ SaveChanges() → SaveChangesAsync()
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi UpdateRoomAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa mềm phòng (cập nhật Status = "Deleted")
        /// </summary>
        public async Task<bool> DeleteRoomAsync(Guid roomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var room = await context.Rooms.FindAsync(roomId); // ⭐ Find() → FindAsync()
                    if (room == null) return false;

                    room.Status = "Deleted";
                    context.Rooms.Update(room);

                    await context.SaveChangesAsync(); // ⭐ SaveChanges() → SaveChangesAsync()
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi DeleteRoomAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lấy thông tin chi tiết một phòng (BAO GỒM ẢNH)
        /// </summary>
        public async Task<Room> GetRoomWithDetailsAsync(Guid roomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var room = await context.Rooms // ⭐ Thêm await
                        .Include(r => r.RoomImages)
                        .Include(r => r.IdOwnerNavigation)
                        .FirstOrDefaultAsync(r => r.Id == roomId); // ⭐ FirstOrDefault() → FirstOrDefaultAsync()

                    return room;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetRoomWithDetailsAsync: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Lấy tất cả phòng của một chủ trọ
        /// </summary>
        public async Task<List<Room>> GetAllRoomsByOwnerAsync(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Rooms // ⭐ Thêm await
                        .Where(r => r.IdOwner == ownerId && r.Status != "Deleted")
                        .OrderBy(r => r.Name)
                        .ToListAsync(); // ⭐ ToList() → ToListAsync()
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetAllRoomsByOwnerAsync: {ex.Message}");
                return new List<Room>();
            }
        }

        /// <summary>
        /// Thêm một ảnh mới vào phòng (dùng cho FormEditRoom)
        /// </summary>
        public async Task<RoomImage> AddImageToRoomAsync(Guid roomId, string imageUrl)
        {
            try
            {
                var newImage = new RoomImage
                {
                    Id = Guid.NewGuid(),
                    IdRoom = roomId,
                    ImageUrl = imageUrl
                };

                using (var context = new AppContextDB())
                {
                    await context.RoomImages.AddAsync(newImage); // ⭐ Add() → AddAsync()
                    await context.SaveChangesAsync(); // ⭐ SaveChanges() → SaveChangesAsync()
                    return newImage;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi AddImageToRoomAsync: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Xóa một ảnh khỏi CSDL (dùng cho FormEditRoom)
        /// </summary>
        public async Task<bool> DeleteRoomImageAsync(Guid imageId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var image = await context.RoomImages.FindAsync(imageId); // ⭐ Find() → FindAsync()
                    if (image == null) return false;

                    context.RoomImages.Remove(image);
                    await context.SaveChangesAsync(); // ⭐ SaveChanges() → SaveChangesAsync()

                    // ⭐ Xóa file trong Task.Run để tránh block
                    await Task.Run(() =>
                    {
                        try
                        {
                            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, image.ImageUrl);
                            if (File.Exists(fullPath))
                            {
                                File.Delete(fullPath);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Lỗi xóa file ảnh: {ex.Message}");
                        }
                    });

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi DeleteRoomImageAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lấy tất cả các phòng đang "Còn trống"
        /// </summary>
        public async Task<List<Room>> GetAllAvailableRoomsAsync()
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Rooms // ⭐ Thêm await
                        .Include(r => r.RoomImages)
                        .Where(r => r.Status == "Trống")
                        .OrderBy(r => r.Price)
                        .ToListAsync(); // ⭐ ToList() → ToListAsync()
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetAllAvailableRoomsAsync: {ex.Message}");
                return new List<Room>();
            }
        }

        /// <summary>
        /// Lấy Room theo ID (đơn giản, không include)
        /// </summary>
        public async Task<Room> GetRoomByIdAsync(Guid roomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Rooms.FindAsync(roomId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetRoomByIdAsync: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Tìm kiếm phòng theo từ khóa
        /// </summary>
        public async Task<List<Room>> SearchRoomsAsync(Guid ownerId, string keyword)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Rooms
                        .Where(r => r.IdOwner == ownerId &&
                                   r.Status != "Deleted" &&
                                   (r.Name.Contains(keyword) ||
                                    (r.Description != null && r.Description.Contains(keyword))))
                        .OrderBy(r => r.Name)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi SearchRoomsAsync: {ex.Message}");
                return new List<Room>();
            }
        }

        /// <summary>
        /// Lấy phòng theo trạng thái
        /// </summary>
        public async Task<List<Room>> GetRoomsByStatusAsync(Guid ownerId, string status)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Rooms
                        .Where(r => r.IdOwner == ownerId && r.Status == status)
                        .OrderBy(r => r.Name)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetRoomsByStatusAsync: {ex.Message}");
                return new List<Room>();
            }
        }

        /// <summary>
        /// Đếm số phòng theo trạng thái
        /// </summary>
        public async Task<int> CountRoomsByStatusAsync(Guid ownerId, string status)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Rooms
                        .CountAsync(r => r.IdOwner == ownerId && r.Status == status);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi CountRoomsByStatusAsync: {ex.Message}");
                return 0;
            }
        }

        /// <summary>
        /// Lấy thống kê phòng
        /// </summary>
        public async Task<RoomStatistics> GetRoomStatisticsAsync(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var rooms = await context.Rooms
                        .Where(r => r.IdOwner == ownerId && r.Status != "Deleted")
                        .ToListAsync();

                    return new RoomStatistics
                    {
                        TotalRooms = rooms.Count,
                        AvailableRooms = rooms.Count(r => r.Status == "Trống"),
                        OccupiedRooms = rooms.Count(r => r.Status == "Đã thuê"),
                        MaintenanceRooms = rooms.Count(r => r.Status == "Bảo trì"),
                        AveragePrice = rooms.Any() ? rooms.Average(r => r.Price ?? 0) : 0,
                        LowestPrice = rooms.Any() ? rooms.Min(r => r.Price ?? 0) : 0,
                        HighestPrice = rooms.Any() ? rooms.Max(r => r.Price ?? 0) : 0,
                        TotalArea = rooms.Sum(r => r.Area ?? 0)
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetRoomStatisticsAsync: {ex.Message}");
                return new RoomStatistics();
            }
        }

        /// <summary>
        /// Lấy phòng theo khoảng giá
        /// </summary>
        public async Task<List<Room>> GetRoomsByPriceRangeAsync(
            Guid ownerId,
            decimal minPrice,
            decimal maxPrice)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Rooms
                        .Include(r => r.RoomImages)
                        .Where(r => r.IdOwner == ownerId &&
                                   r.Status != "Deleted" &&
                                   r.Price >= minPrice &&
                                   r.Price <= maxPrice)
                        .OrderBy(r => r.Price)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetRoomsByPriceRangeAsync: {ex.Message}");
                return new List<Room>();
            }
        }

        /// <summary>
        /// Cập nhật trạng thái phòng
        /// </summary>
        public async Task<bool> UpdateRoomStatusAsync(Guid roomId, string newStatus)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var room = await context.Rooms.FindAsync(roomId);
                    if (room == null) return false;

                    room.Status = newStatus;
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi UpdateRoomStatusAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra phòng có đang được thuê không
        /// </summary>
        public async Task<bool> IsRoomOccupiedAsync(Guid roomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Contracts
                        .AnyAsync(c => c.IdRoom == roomId && c.Status == "Active");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi IsRoomOccupiedAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lấy danh sách ảnh của phòng
        /// </summary>
        public async Task<List<RoomImage>> GetRoomImagesAsync(Guid roomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.RoomImages
                        .Where(ri => ri.IdRoom == roomId)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetRoomImagesAsync: {ex.Message}");
                return new List<RoomImage>();
            }
        }

        /// <summary>
        /// Cập nhật nhiều ảnh cùng lúc
        /// </summary>
        public async Task<bool> UpdateRoomImagesAsync(Guid roomId, List<string> imageUrls)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    using (var transaction = await context.Database.BeginTransactionAsync())
                    {
                        try
                        {
                            // Xóa tất cả ảnh cũ
                            var oldImages = await context.RoomImages
                                .Where(ri => ri.IdRoom == roomId)
                                .ToListAsync();

                            context.RoomImages.RemoveRange(oldImages);

                            // Thêm ảnh mới
                            foreach (var url in imageUrls)
                            {
                                var newImage = new RoomImage
                                {
                                    Id = Guid.NewGuid(),
                                    IdRoom = roomId,
                                    ImageUrl = url
                                };
                                await context.RoomImages.AddAsync(newImage);
                            }

                            await context.SaveChangesAsync();
                            await transaction.CommitAsync();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();
                            Console.WriteLine($"Lỗi UpdateRoomImagesAsync (Transaction): {ex.Message}");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi UpdateRoomImagesAsync: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa cứng phòng (thật sự xóa khỏi database)
        /// </summary>
        public async Task<bool> HardDeleteRoomAsync(Guid roomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    using (var transaction = await context.Database.BeginTransactionAsync())
                    {
                        try
                        {
                            var room = await context.Rooms
                                .Include(r => r.RoomImages)
                                .FirstOrDefaultAsync(r => r.Id == roomId);

                            if (room == null) return false;

                            // Xóa tất cả ảnh
                            if (room.RoomImages.Any())
                            {
                                context.RoomImages.RemoveRange(room.RoomImages);
                            }

                            // Xóa phòng
                            context.Rooms.Remove(room);

                            await context.SaveChangesAsync();
                            await transaction.CommitAsync();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();
                            Console.WriteLine($"Lỗi HardDeleteRoomAsync (Transaction): {ex.Message}");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi HardDeleteRoomAsync: {ex.Message}");
                return false;
            }
        }
    }

    
}