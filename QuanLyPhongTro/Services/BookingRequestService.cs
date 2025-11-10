using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.Data;
using QuanLyPhongTro.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyPhongTro.Services
{
    public class BookingRequestService
    {
        /// <summary>
        /// Tạo một yêu cầu thuê phòng mới
        /// </summary>
        public bool CreateRequest(BookingRequest request)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    context.BookingRequests.Add(request);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi CreateRequest: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lấy các yêu cầu đang chờ (Pending) của một chủ trọ
        /// </summary>
        public List<BookingRequest> GetPendingRequestsByOwner(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.BookingRequests
                        .Include(req => req.Renter) // Tải tên người thuê
                        .Include(req => req.Room)   // Tải tên phòng
                        .Where(req => req.Room.IdOwner == ownerId && req.Status == "Pending")
                        .OrderByDescending(req => req.DateCreated)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetPendingRequests: {ex.Message}");
                return new List<BookingRequest>();
            }
        }

        /// <summary>
        /// Cập nhật trạng thái (Approved/Rejected)
        /// </summary>
        public bool UpdateRequestStatus(Guid requestId, string newStatus)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var request = context.BookingRequests.Find(requestId);
                    if (request == null) return false;

                    request.Status = newStatus;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi UpdateRequestStatus: {ex.Message}");
                return false;
            }
        }
    }
}