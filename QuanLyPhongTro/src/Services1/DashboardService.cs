using Microsoft.EntityFrameworkCore;
using QuanLyPhongTro.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyPhongTro.src.DTO;
namespace QuanLyPhongTro.src.Services1
{
    public class DashboardService
    {
        /// <summary>
        /// 1. TÍNH DOANH THU
        /// </summary>
        public async Task< decimal> GetTotalRevenueAsync(Guid ownerId, DateTime startDate, DateTime endDate)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return  await context.Payments
                        .Include(p => p.IdBillNavigation)
                            .ThenInclude(b => b.IdRoomNavigation)
                        .Where(p => p.IdBillNavigation.IdRoomNavigation!.IdOwner == ownerId &&
                                    p.PaymentDate.HasValue && 
                                    p.PaymentDate.Value >= startDate && 
                                    p.PaymentDate.Value <= endDate)
                        .SumAsync(p => p.Amount ?? 0);
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
        public async Task <decimal> GetTotalExpensesAsync(Guid ownerId, DateTime startDate, DateTime endDate)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    return await context.Expenses
                        .Where(e => e.IdOwner == ownerId &&
                                    e.DateIncurred >= startDate &&
                                    e.DateIncurred <= endDate)
                        .SumAsync(e => e.Amount);
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
        public async Task <(int Occupied, int Total)> GetOccupancyStatsAsync(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var rooms =  await context.Rooms
                        .Where(r => r.IdOwner == ownerId && r.Status != "Deleted")
                        .ToListAsync();

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
        public async Task< List<Bill>> GetUnpaidBillsAsync(Guid ownerId) 
        {
            BillService billService = new BillService();
            return await billService.GetUnpaidBillsAsync(ownerId);
        }

        /// <summary>
        /// 5. (Nâng cao) Lấy dữ liệu Doanh thu theo tháng
        /// </summary>
        public async Task<Dictionary<string, decimal>> GetMonthlyRevenueAsync(Guid ownerId, int year)
        {
            var monthlyRevenue = new Dictionary<string, decimal>();
            try
            {
                using (var context = new AppContextDB())
                {
                    var allPayments = await context.Payments
                        .Include(p => p.IdBillNavigation)
                            .ThenInclude(b => b.IdRoomNavigation)
                        .Where(p => p.IdBillNavigation.IdRoomNavigation!.IdOwner == ownerId &&
                                    p.PaymentDate.HasValue &&
                                    p.PaymentDate.Value.Year == year)
                        .ToListAsync();
                    for (int month = 1; month <= 12; month++)
                    {
                        var revenue = context.Payments
                            .Include(p => p.IdBillNavigation)
                                .ThenInclude(b => b.IdRoomNavigation)
                            .Where(p => p.IdBillNavigation.IdRoomNavigation!.IdOwner == ownerId && // Sửa
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
        /// <summary>
        /// 6. Lấy thống kê tổng quan (Dashboard Overview)
        /// </summary>
        public async Task<DashboardOverview> GetDashboardOverviewAsync(Guid ownerId)
        {
            var now = DateTime.Now;
            var startOfMonth = new DateTime(now.Year, now.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            var revenueTask = GetTotalRevenueAsync(ownerId, startOfMonth, endOfMonth);
            var expensesTask = GetTotalExpensesAsync(ownerId, startOfMonth, endOfMonth);
            var occupancyTask = GetOccupancyStatsAsync(ownerId);
            var unpaidBillsTask = GetUnpaidBillsAsync(ownerId);

            await Task.WhenAll(revenueTask, expensesTask, occupancyTask, unpaidBillsTask);

            var (occupied, total) = await occupancyTask;
            var unpaidBills = await unpaidBillsTask;

            return new DashboardOverview
            {
                TotalRevenue = await revenueTask,
                TotalExpenses = await expensesTask,
                NetProfit = await revenueTask - await expensesTask,
                OccupiedRooms = occupied,
                TotalRooms = total,
                OccupancyRate = total > 0 ? (decimal)occupied / total * 100 : 0,
                UnpaidBillsCount = unpaidBills.Count,
                TotalUnpaidAmount = unpaidBills.Sum(b => b.TotalMoney ?? 0)
            };
        }


        /// <summary>
        /// 7. Lấy dữ liệu Chi phí theo tháng
        /// </summary>
        public async Task<Dictionary<string, decimal>> GetMonthlyExpensesAsync(Guid ownerId, int year)
        {
            var monthlyExpenses = new Dictionary<string, decimal>();
            try
            {
                using (var context = new AppContextDB())
                {
                    var allExpenses = await context.Expenses
                        .Where(e => e.IdOwner == ownerId && e.DateIncurred.Year == year)
                        .ToListAsync();

                    for (int month = 1; month <= 12; month++)
                    {
                        var expense = allExpenses
                            .Where(e => e.DateIncurred.Month == month)
                            .Sum(e => e.Amount);

                        monthlyExpenses.Add(month.ToString(), expense);
                    }

                    return monthlyExpenses;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetMonthlyExpensesAsync: {ex.Message}");
                return monthlyExpenses;
            }
        }

        /// <summary>
        /// 8. Lấy top phòng có doanh thu cao nhất
        /// </summary>
        public async Task<List<RoomRevenueStats>> GetTopRevenueRoomsAsync(Guid ownerId, int topCount = 5)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
                    var endOfYear = new DateTime(DateTime.Now.Year, 12, 31);

                    var roomRevenues = await context.Payments
                        .Include(p => p.IdBillNavigation)
                            .ThenInclude(b => b.IdRoomNavigation)
                        .Where(p => p.IdBillNavigation.IdRoomNavigation!.IdOwner == ownerId &&
                                    p.PaymentDate.HasValue &&
                                    p.PaymentDate.Value >= startOfYear &&
                                    p.PaymentDate.Value <= endOfYear)
                        .GroupBy(p => new
                        {
                            RoomId = p.IdBillNavigation.IdRoom,
                            RoomName = p.IdBillNavigation.IdRoomNavigation!.Name
                        })
                        .Select(g => new RoomRevenueStats
                        {
                            RoomId = g.Key.RoomId.Value,
                            RoomName = g.Key.RoomName,
                            TotalRevenue = g.Sum(p => p.Amount ?? 0)
                        })
                        .OrderByDescending(r => r.TotalRevenue)
                        .Take(topCount)
                        .ToListAsync();

                    return roomRevenues;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetTopRevenueRoomsAsync: {ex.Message}");
                return new List<RoomRevenueStats>();
            }
        }

        /// <summary>
        /// 9. Lấy thống kê thanh toán theo phương thức
        /// </summary>
        public async Task<Dictionary<string, decimal>> GetPaymentMethodStatsAsync(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var stats = await context.Payments
                        .Include(p => p.IdBillNavigation)
                            .ThenInclude(b => b.IdRoomNavigation)
                        .Where(p => p.IdBillNavigation.IdRoomNavigation!.IdOwner == ownerId &&
                                    p.PaymentDate.HasValue)
                        .GroupBy(p => p.PaymentMethod ?? "Khác")
                        .Select(g => new
                        {
                            Method = g.Key,
                            Total = g.Sum(p => p.Amount ?? 0)
                        })
                        .ToDictionaryAsync(x => x.Method, x => x.Total);

                    return stats;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetPaymentMethodStatsAsync: {ex.Message}");
                return new Dictionary<string, decimal>();
            }
        }

        /// <summary>
        /// 10. Lấy dữ liệu so sánh doanh thu/chi phí theo năm
        /// </summary>
        public async Task<YearlyComparison> GetYearlyComparisonAsync(Guid ownerId, int year)
        {
            try
            {
                var startOfYear = new DateTime(year, 1, 1);
                var endOfYear = new DateTime(year, 12, 31);
                var startOfLastYear = new DateTime(year - 1, 1, 1);
                var endOfLastYear = new DateTime(year - 1, 12, 31);

                var currentYearRevenueTask = GetTotalRevenueAsync(ownerId, startOfYear, endOfYear);
                var lastYearRevenueTask = GetTotalRevenueAsync(ownerId, startOfLastYear, endOfLastYear);
                var currentYearExpensesTask = GetTotalExpensesAsync(ownerId, startOfYear, endOfYear);
                var lastYearExpensesTask = GetTotalExpensesAsync(ownerId, startOfLastYear, endOfLastYear);

                await Task.WhenAll(currentYearRevenueTask, lastYearRevenueTask,
                                   currentYearExpensesTask, lastYearExpensesTask);

                var currentRevenue = await currentYearRevenueTask;
                var lastRevenue = await lastYearRevenueTask;
                var currentExpenses = await currentYearExpensesTask;
                var lastExpenses = await lastYearExpensesTask;

                return new YearlyComparison
                {
                    CurrentYearRevenue = currentRevenue,
                    LastYearRevenue = lastRevenue,
                    RevenueGrowth = lastRevenue > 0 ? (currentRevenue - lastRevenue) / lastRevenue * 100 : 0,
                    CurrentYearExpenses = currentExpenses,
                    LastYearExpenses = lastExpenses,
                    ExpenseGrowth = lastExpenses > 0 ? (currentExpenses - lastExpenses) / lastExpenses * 100 : 0
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetYearlyComparisonAsync: {ex.Message}");
                return new YearlyComparison();
            }
        }

        /// <summary>
        /// 11. Đếm số phòng theo trạng thái
        /// </summary>
        public async Task<Dictionary<string, int>> GetRoomStatusCountAsync(Guid ownerId)
        {
            try
            {
                using (var context = new AppContextDB())
                {
                    var stats = await context.Rooms
                        .Where(r => r.IdOwner == ownerId && r.Status != "Deleted")
                        .GroupBy(r => r.Status)
                        .Select(g => new
                        {
                            Status = g.Key,
                            Count = g.Count()
                        })
                        .ToDictionaryAsync(x => x.Status ?? "Khác", x => x.Count);

                    return stats;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi GetRoomStatusCountAsync: {ex.Message}");
                return new Dictionary<string, int>();
            }
        }

        // Synchronous wrapper method for backward compatibility
        public Dictionary<string, decimal> GetMonthlyRevenue(Guid ownerId, int year)
        {
            return GetMonthlyRevenueAsync(ownerId, year).GetAwaiter().GetResult();
        }

        public (int Occupied, int Total) GetOccupancyStats(Guid ownerId)
        {
            return GetOccupancyStatsAsync(ownerId).GetAwaiter().GetResult();
        }

        public List<Bill> GetUnpaidBills(Guid ownerId)
        {
            return GetUnpaidBillsAsync(ownerId).GetAwaiter().GetResult();
        }
    }
    }
