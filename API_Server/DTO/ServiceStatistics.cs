using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Server.src.DTO
{
    public class ServiceStatistics
    {
        public int TotalServices { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal TotalRevenue { get; set; }
    }
    public class ServiceUsageStat
    {
        public Guid ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public int UsageCount { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
