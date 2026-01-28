using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Server.src.DTO
{
   
}
public class RoomStatistics
{
    public int TotalRooms { get; set; }
    public int AvailableRooms { get; set; }
    public int OccupiedRooms { get; set; }
    public int MaintenanceRooms { get; set; }
    public decimal AveragePrice { get; set; }
    public decimal LowestPrice { get; set; }
    public decimal HighestPrice { get; set; }
    public decimal TotalArea { get; set; }

    /// <summary>
    /// Tỷ lệ lấp đầy (%)
    /// </summary>
    public decimal OccupancyRate => TotalRooms > 0
        ? (decimal)OccupiedRooms / TotalRooms * 100
        : 0;
}