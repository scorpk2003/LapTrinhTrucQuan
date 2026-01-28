using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.src.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyPhongTro.src.Test.Services
{
    public class BookingRequestService
    {
        /// <summary>
        /// T?o yêu c?u thuê phòng m?i
        /// </summary>
        public bool CreateRequest(BookingRequest request)
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
                    var renterExists = context.People.Any(p => p.Id == request.IdRenter);
                    var roomExists = context.Rooms.Any(r => r.Id == request.IdRoom);
                    
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
                    bool alreadyExists = context.BookingRequests.Any(req =>
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
                    context.BookingRequests.Add(request);
                    context.SaveChanges();
                    
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
        public List<BookingRequest> GetPendingRequestsByOwner(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    System.Diagnostics.Debug.WriteLine($"=== GetPendingRequestsByOwner DEBUG ===");
                    System.Diagnostics.Debug.WriteLine($"OwnerId: {ownerId}");
                    
                    // ??m t?ng s? booking requests trong DB
                    var totalRequests = context.BookingRequests.Count();
                    System.Diagnostics.Debug.WriteLine($"Total BookingRequests in DB: {totalRequests}");
                    
                    // ??m s? pending requests
                    var pendingCount = context.BookingRequests.Count(req => req.Status == "Pending");
                    System.Diagnostics.Debug.WriteLine($"Pending requests: {pendingCount}");
                    
                    var result = context.BookingRequests
                        .Include(req => req.Renter)
                            .ThenInclude(r => r.IdDetailNavigation)
                        .Include(req => req.Room)
                        .Where(req => req.Room.IdOwner == ownerId && req.Status == "Pending")
                        .OrderByDescending(req => req.DateCreated)
                        .ToList();
                    
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
        public BookingRequest GetRequestById(Guid requestId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.BookingRequests
                        .Include(req => req.Renter)
                            .ThenInclude(r => r.IdDetail)
                        .Include(req => req.Room)
                        .FirstOrDefault(req => req.Id == requestId);
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
        public bool UpdateRequestStatus(Guid requestId, string newStatus)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var request = context.BookingRequests.Find(requestId);
                    if (request == null) return false;

                    // Ch? cho phép các tr?ng thái h?p l?
                    if (newStatus != "Approved" && newStatus != "Rejected" && newStatus != "Pending")
                        return false;

                    request.Status = newStatus;
                    context.SaveChanges();
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
        public bool DeleteRequest(Guid requestId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var request = context.BookingRequests.Find(requestId);
                    if (request == null) return false;

                    context.BookingRequests.Remove(request);
                    context.SaveChanges();
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
        public List<BookingRequest> GetRequestsByRenter(Guid renterId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.BookingRequests
                        .Include(req => req.Room)
                        .Where(req => req.IdRenter == renterId)
                        .OrderByDescending(req => req.DateCreated)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetRequestsByRenter: {ex.Message}");
                return new List<BookingRequest>();
            }
        }
    }
}
