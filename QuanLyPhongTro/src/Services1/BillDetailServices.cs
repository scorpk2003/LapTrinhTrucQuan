using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.src.Models;
using ScottPlot.Finance;
using System.Threading.Tasks;

namespace QuanLyPhongTro.src.Services1
{
    public class BillDetailServices
    {
        /// <summary>
        /// L?y danh sách chi ti?t hóa don theo BillId (bao g?m thông tin d?ch v?)
        /// </summary>
        public async Task<List<BillDetail>> GetBillDetailsByBillIdAsync(Guid billId)
        {
            try
            {
                using (var context = new AppContextDB())

                {

                    // ? L?y chi ti?t hóa don theo IdBill
                    return await context.BillDetails
                                  .Where(d => d.IdBill == billId)
                                  .Include(d => d.IdServiceNavigation) // L?y thông tin d?ch v? liên quan
                                  .ToListAsync();
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
        public async Task<bool> AddBillDetailsAsync(List<BillDetail> details)
        {
            try
            {
                using var context = new AppContextDB();
                await context.BillDetails.AddRangeAsync(details);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"L?i AddBillDetails: {ex.Message}");
                return false;
            }
        }
        public async Task<Bill?> GetBillWithDetailsAsync(Guid billId)
        {
            try
            {
                using var context = new AppContextDB();

                var billWithDetails = await context.Bills
    .Where(b => b.Id == billId)
    .Include(b => b.BillDetail) // L?y chi ti?t hóa don
        .ThenInclude(d => d.IdServiceNavigation) // L?y d?ch v?
    .Include(b => b.Payment) // L?y thông tin thanh toán
    .FirstOrDefaultAsync();

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
        public async Task<bool> UpdateBillDetailAsync(BillDetail detail)
        {
            try
            {
                using var context = new AppContextDB();
                var existing = await context.BillDetails.FindAsync(detail.Id);
                if (existing == null) return false;

                existing.IdService = detail.IdService;
                existing.Quantity = detail.Quantity;
                existing.Id = detail.Id;
                existing.IdBill = detail.IdBill;
                existing.Total = detail.Total;
                existing.Electricity = detail.Electricity;
                existing.Water = detail.Water;
                existing.IdBillNavigation = detail.IdBillNavigation;
                existing.IdServiceNavigation = detail.IdServiceNavigation;

                context.BillDetails.Update(existing);

                await context.SaveChangesAsync();
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
        public async Task<bool> DeleteBillDetailAsync(Guid id)
        {
            try
            {
                using var context = new AppContextDB();
                var detail = await context.BillDetails.FindAsync(id);
                if (detail == null) return false;

                context.BillDetails.Remove(detail);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"L?i DeleteBillDetail: {ex.Message}");
                return false;
            }
        }
        ///<summary>
        ///lấy tổng số tiền của một hoá đơn
        /// </summary>
        public async Task<decimal> GetTotalAmountByBillIdAsync(Guid billID)
        {
            try
            {
                using var context = new AppContextDB();
                var Total = await context.BillDetails
                    .Where(d => d.IdBill == billID)
                    .SumAsync(d => d.Total ?? 0);
                return Total;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetTotalAmountByBillIdAsync: {ex.Message}");
                return 0;
            }
        }
        ///<summary>
        /// Kiểm tra chi tiết hoá đơn có tồn tại không
        ///</summary>
        public async Task<bool> ExitsAsync(Guid Id)
        {
            try
            {
                using var context = new AppContextDB();
                return await context.BillDetails.AnyAsync(d => d.Id == Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ExitsAsync: {ex.Message}");
                return false;

            }
        }
        ///<summary>
        /// Xoá tất cả chi tiết hoá đơn theo BillId
        ///</summary>
        public async Task<bool> DeleteBillDetailsByBillIdAsync(Guid billId)
        {
            try
            {
                using var context = new AppContextDB();
                var details = await context.BillDetails.Where(d => d.IdBill == billId).ToListAsync();
                if (details.Count == 0) return true;
                context.BillDetails.RemoveRange(details);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi DeleteBillDetailsByBillIdAsync: {ex.Message}");
                return false;
            }
        }
    }
}
