using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyPhongTro.src.Services1
{
    public class DashboardService
    {
        /// <summary>
        /// 1. TÍNH DOANH THU
        /// </summary>
        public decimal GetTotalRevenue(Guid ownerId, DateTime startDate, DateTime endDate)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Payments
                        .Include(p => p.IdPaymentNavigation)
                            .ThenInclude(b => b.IdRoomNavigation)
                        .Where(p => p.IdPaymentNavigation.IdRoomNavigation.IdOwner == ownerId &&
                                    p.PaymentDate.HasValue && 
                                    p.PaymentDate.Value >= startDate && 
                                    p.PaymentDate.Value <= endDate)
                        .Sum(p => p.Amount ?? 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetTotalRevenue: {ex.Message}");
                return 0;
            }
        }

        /// <summary>
        /// 2. TÍNH CHI PHÍ
        /// </summary>
        public decimal GetTotalExpenses(Guid ownerId, DateTime startDate, DateTime endDate)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Expenses
                        .Where(e => e.IdOwner == ownerId &&
                                    e.DateIncurred >= startDate &&
                                    e.DateIncurred <= endDate)
                        .Sum(e => e.Amount);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetTotalExpenses: {ex.Message}");
                return 0;
            }
        }

        /// <summary>
        /// 3. TÍNH TỶ LỆ LẤP ĐẦY
        /// </summary>
        public (int Occupied, int Total) GetOccupancyStats(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var rooms = context.Rooms
                        .Where(r => r.IdOwner == ownerId && r.Status != "Deleted")
                        .ToList();

                    int total = rooms.Count;
                    int occupied = rooms.Count(r => r.Status == "Đã thuê");
                    

                    return (occupied, total);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetOccupancyStats: {ex.Message}");
                return (0, 0);
            }
        }

        /// <summary>
        /// 4. LẤY NỢ ĐỌNG
        /// </summary>
        public List<Bill> GetUnpaidBills(Guid ownerId) 
        {
            BillService billService = new BillService();
            return billService.GetUnpaidBills(ownerId);
        }

        /// <summary>
        /// 5. (Nâng cao) Lấy dữ liệu Doanh thu theo tháng
        /// </summary>
        public Dictionary<string, decimal> GetMonthlyRevenue(Guid ownerId, int year)
        {
            var monthlyRevenue = new Dictionary<string, decimal>();
            try
            {
                using (var context = new AppContextDB())
                {
                    for (int month = 1; month <= 12; month++)
                    {
                        var revenue = context.Payments
                            .Include(p => p.IdPaymentNavigation)
                                .ThenInclude(b => b.IdRoomNavigation)
                            .Where(p => p.IdPaymentNavigation.IdRoomNavigation.IdOwner == ownerId && // Sửa
                                        p.PaymentDate.HasValue && 
                                        p.PaymentDate.Value.Year == year &&
                                        p.PaymentDate.Value.Month == month)
                            .Sum(p => p.Amount ?? 0);

                        monthlyRevenue.Add(month.ToString(), revenue);
                    }
                    return monthlyRevenue;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetMonthlyRevenue: {ex.Message}");
                return monthlyRevenue;
            }
        }
    }
}