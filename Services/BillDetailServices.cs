using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using QuanLyPhongTro.Models;

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
                using (var context = new AppContextDB())

                {

                    // ✅ Lấy chi tiết hóa đơn theo IdBill
                    return context.BillDetails
                                  .Where(d => d.IdBill == billId)
                                  .Include(d => d.IdServiceNavigation) // Lấy thông tin dịch vụ liên quan
                                  .ToList();
                }    
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi GetBillDetailsByBillId: {ex.Message}");
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
        public Bill? GetBillWithDetails(Guid billId)
        {
            try
            {
                using var context = new AppContextDB();

                var billWithDetails = context.Bills
    .Where(b => b.Id == billId)
    .Include(b => b.BillDetails) // Lấy chi tiết hóa đơn
        .ThenInclude(d => d.IdServiceNavigation) // Lấy dịch vụ
    .Include(b => b.Payment) // Lấy thông tin thanh toán
    .FirstOrDefault();

                System.Diagnostics.Debug.WriteLine($"\n\n\tLấy được BillWithDetails: {billWithDetails}\n\n");

                return billWithDetails;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"\n\n\tLỗi GetBillWithDetails: {ex.Message}\n\n");
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
