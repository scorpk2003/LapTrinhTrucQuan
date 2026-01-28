using API_Server.src.DTO;
using API_Server.src.Services1;
using Microsoft.AspNetCore.Mvc;
using API_Server.src.DTO;
using API_Server.src.Services1;

namespace API_Server.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardService _service;

        public DashboardController()
        {
            _service = new DashboardService();
        }

        /// <summary>
        /// 1. Tổng doanh thu theo khoảng thời gian
        /// GET: api/Dashboard/revenue
        /// </summary>
        [HttpGet("revenue")]
        public async Task<IActionResult> GetTotalRevenue(
            [FromQuery] Guid ownerId,
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            var result = await _service.GetTotalRevenueAsync(ownerId, startDate, endDate);
            return Ok(result);
        }

        /// <summary>
        /// 2. Tổng chi phí theo khoảng thời gian
        /// GET: api/Dashboard/expenses
        /// </summary>
        [HttpGet("expenses")]
        public async Task<IActionResult> GetTotalExpenses(
            [FromQuery] Guid ownerId,
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            var result = await _service.GetTotalExpensesAsync(ownerId, startDate, endDate);
            return Ok(result);
        }

        /// <summary>
        /// 3. Thống kê tỷ lệ lấp đầy
        /// GET: api/Dashboard/occupancy/{ownerId}
        /// </summary>
        [HttpGet("occupancy/{ownerId}")]
        public async Task<IActionResult> GetOccupancy(Guid ownerId)
        {
            var (occupied, total) = await _service.GetOccupancyStatsAsync(ownerId);
            return Ok(new
            {
                OccupiedRooms = occupied,
                TotalRooms = total,
                OccupancyRate = total > 0 ? (decimal)occupied / total * 100 : 0
            });
        }

        /// <summary>
        /// 4. Danh sách hóa đơn chưa thanh toán
        /// GET: api/Dashboard/unpaid-bills/{ownerId}
        /// </summary>
        [HttpGet("unpaid-bills/{ownerId}")]
        public async Task<IActionResult> GetUnpaidBills(Guid ownerId)
        {
            var result = await _service.GetUnpaidBillsAsync(ownerId);
            return Ok(result);
        }

        /// <summary>
        /// 5. Doanh thu theo tháng
        /// GET: api/Dashboard/monthly-revenue
        /// </summary>
        [HttpGet("monthly-revenue")]
        public async Task<IActionResult> GetMonthlyRevenue(
            [FromQuery] Guid ownerId,
            [FromQuery] int year)
        {
            var result = await _service.GetMonthlyRevenueAsync(ownerId, year);
            return Ok(result);
        }

        /// <summary>
        /// 6. Dashboard tổng quan
        /// GET: api/Dashboard/overview/{ownerId}
        /// </summary>
        [HttpGet("overview/{ownerId}")]
        public async Task<IActionResult> GetOverview(Guid ownerId)
        {
            DashboardOverview overview = await _service.GetDashboardOverviewAsync(ownerId);
            return Ok(overview);
        }

        /// <summary>
        /// 7. Chi phí theo tháng
        /// GET: api/Dashboard/monthly-expenses
        /// </summary>
        [HttpGet("monthly-expenses")]
        public async Task<IActionResult> GetMonthlyExpenses(
            [FromQuery] Guid ownerId,
            [FromQuery] int year)
        {
            var result = await _service.GetMonthlyExpensesAsync(ownerId, year);
            return Ok(result);
        }

        /// <summary>
        /// 8. Top phòng có doanh thu cao nhất
        /// GET: api/Dashboard/top-revenue-rooms
        /// </summary>
        [HttpGet("top-revenue-rooms")]
        public async Task<IActionResult> GetTopRevenueRooms(
            [FromQuery] Guid ownerId,
            [FromQuery] int top = 5)
        {
            var result = await _service.GetTopRevenueRoomsAsync(ownerId, top);
            return Ok(result);
        }

        /// <summary>
        /// 9. Thống kê theo phương thức thanh toán
        /// GET: api/Dashboard/payment-methods/{ownerId}
        /// </summary>
        [HttpGet("payment-methods/{ownerId}")]
        public async Task<IActionResult> GetPaymentMethods(Guid ownerId)
        {
            var result = await _service.GetPaymentMethodStatsAsync(ownerId);
            return Ok(result);
        }

        /// <summary>
        /// 10. So sánh doanh thu & chi phí theo năm
        /// GET: api/Dashboard/yearly-comparison
        /// </summary>
        [HttpGet("yearly-comparison")]
        public async Task<IActionResult> GetYearlyComparison(
            [FromQuery] Guid ownerId,
            [FromQuery] int year)
        {
            YearlyComparison result = await _service.GetYearlyComparisonAsync(ownerId, year);
            return Ok(result);
        }

        /// <summary>
        /// 11. Đếm số phòng theo trạng thái
        /// GET: api/Dashboard/room-status/{ownerId}
        /// </summary>
        [HttpGet("room-status/{ownerId}")]
        public async Task<IActionResult> GetRoomStatus(Guid ownerId)
        {
            var result = await _service.GetRoomStatusCountAsync(ownerId);
            return Ok(result);
        }
    }
}
