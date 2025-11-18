using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.src.Models;

namespace QuanLyPhongTro.src.Services1
{
    public class BillDetailServices
    {
        /// <summary>
        /// L?y danh sách chi ti?t hóa don theo BillId (bao g?m thông tin d?ch v?)
        /// </summary>
        public List<BillDetail> GetBillDetailsByBillId(Guid billId)
        {
            try
            {
                using (var context = new AppContextDB())

                {

                    // ? L?y chi ti?t hóa don theo IdBill
                    return context.BillDetails
                                  .Where(d => d.IdBill == billId)
                                  .Include(d => d.IdServiceNavigation) // L?y thông tin d?ch v? liên quan
                                  .ToList();
                }    
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"L?i GetBillDetailsByBillId: {ex.Message}");
                return new List<BillDetail>();
            }
        }

        /// <summary>
        /// Thêm nhi?u chi ti?t hóa don cùng lúc
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
                Console.WriteLine($"L?i AddBillDetails: {ex.Message}");
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
    .Include(b => b.BillDetails) // L?y chi ti?t hóa don
        .ThenInclude(d => d.IdServiceNavigation) // L?y d?ch v?
    .Include(b => b.Payment) // L?y thông tin thanh toán
    .FirstOrDefault();

                System.Diagnostics.Debug.WriteLine($"\n\n\tL?y du?c BillWithDetails: {billWithDetails}\n\n");

                return billWithDetails;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"\n\n\tL?i GetBillWithDetails: {ex.Message}\n\n");
                return null;
            }
        }


        /// <summary>
        /// C?p nh?t thông tin chi ti?t hóa don
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
                Console.WriteLine($"L?i UpdateBillDetail: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa chi ti?t hóa don theo ID
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
                Console.WriteLine($"L?i DeleteBillDetail: {ex.Message}");
                return false;
            }
        }
    }
}
