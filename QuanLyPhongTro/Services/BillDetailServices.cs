using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.Data;
using QuanLyPhongTro.Model;

namespace QuanLyPhongTro.Services
{
    public class BillDetailServices
    {
        /// <summary>
        /// Lấy danh sách chi tiết hóa đơn theo BillId (bao gồm thông tin dịch vụ)
        /// </summary>
        public List<BillDetail> GetBillDetailsByBillId(Guid billId)
        {
            try
            {
                using var context = new AppContextDB();

                // ✅ Lấy chi tiết hóa đơn theo IdBill
                return context.BillDetails
                              .Where(d => d.IdBill == billId)
                              .Include(d => d.Service) // Lấy thông tin dịch vụ liên quan
                              .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetBillDetailsByBillId: {ex.Message}");
                return new List<BillDetail>();
            }
        }

        /// <summary>
        /// Thêm nhiều chi tiết hóa đơn cùng lúc
        /// </summary>
        public bool AddBillDetails(List<BillDetail> details)
        {
            try
            {
                using var context = new AppContextDB();
                context.BillDetails.AddRange(details);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi AddBillDetails: {ex.Message}");
                return false;
            }
        }
        public Bill GetBillWithDetails(Guid billId)
        {
            try
            {
                using var context = new AppContextDB();

                var billWithDetails = context.Bills
                    .Where(b => b.Id == billId)
                    .Include(b => b.BillDetails)
                        .ThenInclude(d => d.Service)
                    .Include(b => b.Room)      // nếu bạn muốn lấy luôn thông tin phòng
                    .Include(b => b.Person)    // nếu bạn muốn lấy luôn thông tin người thuê
                    .FirstOrDefault();

                return billWithDetails;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetBillWithDetails: {ex.Message}");
                return null;
            }
        }


        /// <summary>
        /// Cập nhật thông tin chi tiết hóa đơn
        /// </summary>
        public bool UpdateBillDetail(BillDetail detail)
        {
            try
            {
                using var context = new AppContextDB();
                var existing = context.BillDetails.Find(detail.Id);
                if (existing == null) return false;

                existing.Quantity = detail.Quantity;
                existing.Total = detail.Total;
                existing.IdService = detail.IdService;

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi UpdateBillDetail: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa chi tiết hóa đơn theo ID
        /// </summary>
        public bool DeleteBillDetail(Guid id)
        {
            try
            {
                using var context = new AppContextDB();
                var detail = context.BillDetails.Find(id);
                if (detail == null) return false;

                context.BillDetails.Remove(detail);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi DeleteBillDetail: {ex.Message}");
                return false;
            }
        }
    }
}
