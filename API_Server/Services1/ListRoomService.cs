using Microsoft.EntityFrameworkCore;
using API_Server.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyPhongTro.src.Services1
{
    public class ListRoomService
    {
        /// <summary>
        /// T?o dãy tr? m?i
        /// </summary>
        public bool CreateListRoom(ListRoom listRoom)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    context.ListRooms.Add(listRoom);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"L?i CreateListRoom: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// C?p nh?t thông tin dãy tr?
        /// </summary>
        public bool UpdateListRoom(ListRoom listRoomData)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var existingListRoom = context.ListRooms.Find(listRoomData.Id);
                    if (existingListRoom == null) return false;

                    existingListRoom.Name = listRoomData.Name;
                    existingListRoom.Address = listRoomData.Address;
                    existingListRoom.Status = listRoomData.Status;

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"L?i UpdateListRoom: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa m?m dãy tr? (c?p nh?t Status = "Deleted")
        /// </summary>
        public bool DeleteListRoom(Guid listRoomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var listRoom = context.ListRooms.Find(listRoomId);
                    if (listRoom == null) return false;

                    listRoom.Status = "Deleted";
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"L?i DeleteListRoom: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// L?y thông tin chi ti?t m?t dãy tr?
        /// </summary>
        public ListRoom GetListRoomById(Guid listRoomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.ListRooms
                        .Include(lr => lr.Rooms)
                        .Include(lr => lr.IdOwnerNavigation)
                        .FirstOrDefault(lr => lr.Id == listRoomId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"L?i GetListRoomById: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// L?y t?t c? dãy tr? c?a m?t ch? tr?
        /// </summary>
        public List<ListRoom> GetAllListRoomsByOwner(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.ListRooms
                        .Include(lr => lr.Rooms)
                        .Where(lr => lr.IdOwner == ownerId && lr.Status != "Deleted")
                        .OrderBy(lr => lr.Name)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"L?i GetAllListRoomsByOwner: {ex.Message}");
                return new List<ListRoom>();
            }
        }

        /// <summary>
        /// Alias cho GetAllListRoomsByOwner - ?? t??ng thích v?i code c?
        /// </summary>
        public List<ListRoom> GetListRoomsByOwner(Guid ownerId)
        {
            return GetAllListRoomsByOwner(ownerId);
        }

        /// <summary>
        /// L?y ho?c t?o dãy tr? m?c ??nh n?u ch?a có
        /// </summary>
        public ListRoom GetOrCreateDefaultListRoom(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    // Tìm dãy tr? ??u tiên c?a owner
                    var existingListRoom = context.ListRooms
                        .FirstOrDefault(lr => lr.IdOwner == ownerId && lr.Status != "Deleted");

                    if (existingListRoom != null)
                        return existingListRoom;

                    // N?u ch?a có, t?o m?c ??nh
                    var defaultListRoom = new ListRoom
                    {
                        Id = Guid.NewGuid(),
                        IdOwner = ownerId,
                        Name = "Dãy tr? m?c ??nh",
                        Address = "Ch?a c?p nh?t",
                        Status = "Active"
                    };

                    context.ListRooms.Add(defaultListRoom);
                    context.SaveChanges();

                    return defaultListRoom;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"L?i GetOrCreateDefaultListRoom: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// L?y danh sách dãy tr? ??n gi?n (ch? Id và Name) ?? hi?n th? trong ComboBox
        /// </summary>
        public List<ListRoom> GetListRoomsForDropdown(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.ListRooms
                        .Where(lr => lr.IdOwner == ownerId && lr.Status != "Deleted")
                        .Select(lr => new ListRoom
                        {
                            Id = lr.Id,
                            Name = lr.Name,
                            Address = lr.Address
                        })
                        .OrderBy(lr => lr.Name)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"L?i GetListRoomsForDropdown: {ex.Message}");
                return new List<ListRoom>();
            }
        }

        /// <summary>
        /// Ki?m tra dãy tr? có phòng nào ?ang thuê không
        /// </summary>
        public bool HasOccupiedRooms(Guid listRoomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Rooms
                        .Any(r => r.IdListRoom == listRoomId && r.Status == "?ã thuê");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"L?i HasOccupiedRooms: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// ??m s? phòng trong dãy tr?
        /// </summary>
        public int CountRoomsInListRoom(Guid listRoomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Rooms
                        .Count(r => r.IdListRoom == listRoomId && r.Status != "Deleted");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"L?i CountRoomsInListRoom: {ex.Message}");
                return 0;
            }
        }

        /// <summary>
        /// C?p nh?t tr?ng thái dãy tr?
        /// </summary>
        public bool UpdateListRoomStatus(Guid listRoomId, string newStatus)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var listRoom = context.ListRooms.Find(listRoomId);
                    if (listRoom == null) return false;

                    listRoom.Status = newStatus;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"L?i UpdateListRoomStatus: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa c?ng dãy tr? (ch? khi không có phòng nào)
        /// </summary>
        public bool HardDeleteListRoom(Guid listRoomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var listRoom = context.ListRooms
                        .Include(lr => lr.Rooms)
                        .FirstOrDefault(lr => lr.Id == listRoomId);

                    if (listRoom == null) return false;

                    // Ki?m tra xem có phòng nào không
                    if (listRoom.Rooms.Any())
                    {
                        Console.WriteLine("Không th? xóa dãy tr? vì còn phòng bên trong.");
                        return false;
                    }

                    context.ListRooms.Remove(listRoom);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"L?i HardDeleteListRoom: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Tìm ki?m dãy tr? theo t? khóa
        /// </summary>
        public List<ListRoom> SearchListRooms(Guid ownerId, string keyword)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.ListRooms
                        .Include(lr => lr.Rooms)
                        .Where(lr => lr.IdOwner == ownerId &&
                                    lr.Status != "Deleted" &&
                                    (lr.Name.Contains(keyword) || lr.Address.Contains(keyword)))
                        .OrderBy(lr => lr.Name)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"L?i SearchListRooms: {ex.Message}");
                return new List<ListRoom>();
            }
        }

        /// <summary>
        /// L?y th?ng kê dãy tr?
        /// </summary>
        public ListRoomStatistics GetListRoomStatistics(Guid listRoomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var listRoom = context.ListRooms
                        .Include(lr => lr.Rooms)
                        .FirstOrDefault(lr => lr.Id == listRoomId);

                    if (listRoom == null)
                        return new ListRoomStatistics();

                    return new ListRoomStatistics
                    {
                        TotalRooms = listRoom.Rooms.Count(r => r.Status != "Deleted"),
                        AvailableRooms = listRoom.Rooms.Count(r => r.Status == "Tr?ng"),
                        OccupiedRooms = listRoom.Rooms.Count(r => r.Status == "?ã thuê"),
                        MaintenanceRooms = listRoom.Rooms.Count(r => r.Status == "B?o trì"),
                        TotalRevenue = listRoom.Rooms
                            .Where(r => r.Status == "?ã thuê")
                            .Sum(r => r.Price ?? 0)
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"L?i GetListRoomStatistics: {ex.Message}");
                return new ListRoomStatistics();
            }
        }

        /// <summary>
        /// Ki?m tra tên dãy tr? ?ã t?n t?i ch?a
        /// </summary>
        public bool IsListRoomNameExists(Guid ownerId, string name, Guid? excludeId = null)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var query = context.ListRooms
                        .Where(lr => lr.IdOwner == ownerId && 
                                    lr.Name == name && 
                                    lr.Status != "Deleted");

                    if (excludeId.HasValue)
                    {
                        query = query.Where(lr => lr.Id != excludeId.Value);
                    }

                    return query.Any();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"L?i IsListRoomNameExists: {ex.Message}");
                return false;
            }
        }
    }

    /// <summary>
    /// Class th?ng kê phòng
    /// </summary>
    public class RoomStatistics
    {
        public int TotalRooms { get; set; }
        public int AvailableRooms { get; set; }
        public int OccupiedRooms { get; set; }
        public int MaintenanceRooms { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal LowestPrice { get; set; }
        public decimal HighestPrice { get; set; }
        public decimal TotalArea { get; set; }
    }

    /// <summary>
    /// Class th?ng kê dãy tr?
    /// </summary>
    public class ListRoomStatistics
    {
        public int TotalRooms { get; set; }
        public int AvailableRooms { get; set; }
        public int OccupiedRooms { get; set; }
        public int MaintenanceRooms { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
