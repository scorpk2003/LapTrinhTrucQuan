using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.Data;
using QuanLyPhongTro.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyPhongTro.Services
{
    public class DashboardService
    {
        /// <summary>
        /// 1. TÍNH DOANH THU: Lấy tổng doanh thu (từ bảng Payment)
        /// </summary>
        public decimal GetTotalRevenue(Guid ownerId, DateTime startDate, DateTime endDate)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    // Lấy tổng tiền từ các Bill thuộc Owner, trong khoảng ngày
                    return context.Payments
                        .Include(p => p.Bill.Room) // Lấy Bill -> Room
                        .Where(p => p.Bill.Room.IdOwner == ownerId &&
                                    p.PaymentDate >= startDate &&
                                    p.PaymentDate <= endDate)
                        .Sum(p => p.Amount);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetTotalRevenue: {ex.Message}");
                return 0;
            }
        }

        /// <summary>
        /// 2. TÍNH CHI PHÍ: Lấy tổng chi phí (từ bảng Expense mới)
        /// </summary>
        public decimal GetTotalExpenses(Guid ownerId, DateTime startDate, DateTime endDate)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return context.Expense
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
        /// 4. LẤY NỢ ĐỌNG (Dùng lại hàm của BillService)
        /// </summary>
        public List<Bill> GetUnpaidBills(Guid ownerId)
        {
            // Chúng ta có thể gọi trực tiếp BillService
            BillService billService = new BillService();
            return billService.GetUnpaidBills(ownerId);
        }

        /// <summary>
        /// (Nâng cao) Lấy dữ liệu Doanh thu theo từng tháng để vẽ biểu đồ
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
                            .Include(p => p.Bill.Room)
                            .Where(p => p.Bill.Room.IdOwner == ownerId &&
                                        p.PaymentDate.Year == year &&
                                        p.PaymentDate.Month == month)
                            .Sum(p => p.Amount);

                        monthlyRevenue.Add(month.ToString(), revenue); // Key = "1", "2", ... "12"
                    }
                    return monthlyRevenue;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetMonthlyRevenue: {ex.Message}");
                return monthlyRevenue; // Trả về rỗng
            }
        }
    }
}