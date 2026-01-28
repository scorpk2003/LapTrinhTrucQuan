using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.src.DTO

{
    public class DashboardOverview
    {
        public decimal TotalRevenue { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal NetProfit { get; set; }
        public int OccupiedRooms { get; set; }
        public int TotalRooms { get; set; }
        public decimal OccupancyRate { get; set; }
        public int UnpaidBillsCount { get; set; }
        public decimal TotalUnpaidAmount { get; set; }
    }
    public class YearlyComparison
    {
        public decimal CurrentYearRevenue { get; set; }
        public decimal LastYearRevenue { get; set; }
        public decimal RevenueGrowth { get; set; }

        public decimal CurrentYearExpenses { get; set; }
        public decimal LastYearExpenses { get; set; }
        public decimal ExpenseGrowth { get; set; }
    }
    public class RoomRevenueStats
    {
        public Guid RoomId { get; set; }
        public string RoomName { get; set; } = string.Empty;
        public decimal TotalRevenue { get; set; }
    }
    public class ReportStatistic
    {
        public int TotalContracts { get; set; }
        public decimal TotalRevenue { get; set; }
    }
    public class ServiceUsageStats
    {
        public string ServiceName { get; set; } = string.Empty;
        public int UsageCount { get; set; }
    }
}

