using Microsoft.EntityFrameworkCore;
using API_Server.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Server.src.Services1
{
    public class BookingRequestService
    {
        /// <summary>
        /// T?o yêu c?u thuê phòng m?i
        /// </summary>
        public async Task <bool> CreateRequestAsync(BookingRequest request)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    // Debug logging
                    System.Diagnostics.Debug.WriteLine($"=== CreateRequest DEBUG ===");
                    System.Diagnostics.Debug.WriteLine($"IdRenter: {request.IdRenter}");
                    System.Diagnostics.Debug.WriteLine($"IdRoom: {request.IdRoom}");
                    
                    // Ki?m tra xem Renter và Room có t?n t?i không
                    var renterExists =  await context.People.AnyAsync(p => p.Id == request.IdRenter);
                    var roomExists = await context.Rooms.AnyAsync(r => r.Id == request.IdRoom);
                    
                    System.Diagnostics.Debug.WriteLine($"Renter exists: {renterExists}");
                    System.Diagnostics.Debug.WriteLine($"Room exists: {roomExists}");
                    
                    if (!renterExists)
                    {
                        System.Diagnostics.Debug.WriteLine("ERROR: Renter không tồn tại!");
                        return false;
                    }
                    
                    if (!roomExists)
                    {
                        System.Diagnostics.Debug.WriteLine("ERROR: Room không tồn tại!");
                        return false;
                    }

                    // Ki?m tra trùng l?p - Ngu?i thuê này dã g?i yêu c?u Pending cho phòng này chua?
                    bool alreadyExists = await context.BookingRequests.AnyAsync(req =>
                        req.IdRenter == request.IdRenter &&
                        req.IdRoom == request.IdRoom &&
                        req.Status == "Pending");

                    System.Diagnostics.Debug.WriteLine($"Already exists: {alreadyExists}");

                    if (alreadyExists)
                    {
                        System.Diagnostics.Debug.WriteLine("ERROR: Request dã t?n t?i!");
                        return false;
                    }

                    // Thêm yêu c?u m?i
                     await context.BookingRequests.AddAsync(request);
                   await context.SaveChangesAsync();
                    
                    System.Diagnostics.Debug.WriteLine("SUCCESS: Request created!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"EXCEPTION: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    System.Diagnostics.Debug.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                return false;
            }
        }

        /// <summary>
        /// L?y t?t c? yêu c?u Pending c?a Owner
        /// </summary>
        public async Task< List<BookingRequest>> GetPendingRequestsByOwnerAsync(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    System.Diagnostics.Debug.WriteLine($"=== GetPendingRequestsByOwnerAsync DEBUG ===");
                    System.Diagnostics.Debug.WriteLine($"OwnerId: {ownerId}");
                    
                    // ??m t?ng s? booking requests trong DB
                    var totalRequests =  await context.BookingRequests.CountAsync();
                    System.Diagnostics.Debug.WriteLine($"Total BookingRequests in DB: {totalRequests}");
                    
                    // ??m s? pending requests
                    var pendingCount = await context.BookingRequests.CountAsync(req => req.Status == "Pending");
                    System.Diagnostics.Debug.WriteLine($"Pending requests: {pendingCount}");
                    
                    var result =  await context.BookingRequests
                        .Include(req => req.IdRenterNavigation)
                            .ThenInclude(r => r.IdDetailNavigation)
                        .Include(req => req.IdRoomNavigation)
                        .Where(req => req.IdRoomNavigation.IdOwner == ownerId && req.Status == "Pending")
                        .OrderByDescending(req => req.DateCreated)
                        .ToListAsync();
                    
                    System.Diagnostics.Debug.WriteLine($"Requests for owner {ownerId}: {result.Count}");
                    
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetPendingRequests: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
                return new List<BookingRequest>();
            }
        }

        /// <summary>
        /// L?y chi ti?t yêu c?u theo ID
        /// </summary>
        public  async Task <BookingRequest?> GetRequestByIdAsync(Guid requestId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return  await context.BookingRequests
                        .Include(req => req.IdRenterNavigation)
                            .ThenInclude(r => r.IdDetail)
                        .Include(req => req.IdRoomNavigation)
                        .FirstOrDefaultAsync(req => req.Id == requestId);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetRequestById: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// C?p nh?t tr?ng thái yêu c?u (Approved/Rejected)
        /// </summary>
        public async Task <bool> UpdateRequestStatusAsync(Guid requestId, string newStatus)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var request =  await context.BookingRequests.FindAsync(requestId);
                    if (request == null) return false;

                    // Ch? cho phép các tr?ng thái h?p l?
                    if (newStatus != "Approved" && newStatus != "Rejected" && newStatus != "Pending")
                        return false;

                    request.Status = newStatus;
                     await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi UpdateRequestStatus: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa yêu c?u (n?u c?n)
        /// </summary>
        public  async Task <bool> DeleteRequestAsync(Guid requestId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var request = await context.BookingRequests.FindAsync(requestId);
                    if (request == null) return false;

                    context.BookingRequests.Remove(request);
                   await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi DeleteRequest: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// L?y l?ch s? yêu c?u c?a Renter
        /// </summary>
        public async Task <List<BookingRequest>> GetRequestsByRenterAsync(Guid renterId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return  await context.BookingRequests
                        .Include(req => req.IdRoomNavigation)
                        .Where(req => req.IdRenter == renterId)
                        .OrderByDescending(req => req.DateCreated)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetRequestsByRenter: {ex.Message}");
                return new List<BookingRequest>();
            }
        }
        /// <summary>
        /// Lấy tất cả yêu cầu theo trạng thái
        /// </summary>
        public async Task<List<BookingRequest>> GetRequestsByStatusAsync(Guid ownerId, string status)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.BookingRequests
                        .Include(req => req.IdRenterNavigation)
                            .ThenInclude(r => r.IdDetailNavigation)
                        .Include(req => req.IdRoomNavigation)
                        .Where(req => req.IdRoomNavigation.IdOwner == ownerId && req.Status == status)
                        .OrderByDescending(req => req.DateCreated)
                        .ToListAsync();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetRequestsByStatusAsync: {ex.Message}");
                return new List<BookingRequest>();
            }
        }

        /// <summary>
        /// Kiểm tra xem người thuê đã có yêu cầu pending cho phòng này chưa
        /// </summary>
        public async Task<bool> HasPendingRequestAsync(Guid renterId, Guid roomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.BookingRequests.AnyAsync(req =>
                        req.IdRenter == renterId &&
                        req.IdRoom == roomId &&
                        req.Status == "Pending");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi HasPendingRequestAsync: {ex.Message}");
                return false;
            }
        }
        /// <summary>
        /// Đếm số lượng yêu cầu pending của owner
        /// </summary>
        public async Task<int> CountPendingRequestsAsync(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.BookingRequests
                        .CountAsync(req => req.IdRoomNavigation.IdOwner == ownerId && req.Status == "Pending");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi CountPendingRequestsAsync: {ex.Message}");
                return 0;
            }
        }

        /// <summary>
        /// Lấy yêu cầu gần nhất của renter cho một phòng cụ thể
        /// </summary>
        public async Task<BookingRequest?> GetLatestRequestForRoomAsync(Guid renterId, Guid roomId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.BookingRequests
                        .Include(req => req.IdRoomNavigation)
                        .Where(req => req.IdRenter == renterId && req.IdRoom == roomId)
                        .OrderByDescending(req => req.DateCreated)
                        .FirstOrDefaultAsync();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetLatestRequestForRoomAsync: {ex.Message}");
                return null;
            }
        }
    }
}
