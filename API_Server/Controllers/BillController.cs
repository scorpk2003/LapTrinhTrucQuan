using Microsoft.AspNetCore.Mvc;
using API_Server.src.Models;
using API_Server.src.DTO.Bill;
using API_Server.src.Services1;

namespace API_Server.Controllers
{
    [ApiController]
    [Route("api/bills")]
    public class BillController : ControllerBase
    {
        private readonly BillService _billService;

        public BillController()
        {
            _billService = new BillService();
        }

        // =========================
        // 0. TEST API - thêm chi tiết hóa đơn (FAKE, KHÔNG DB)
        // =========================
        [HttpPost("details")]
        public IActionResult AddBillDetails([FromBody] AddBillDetailsRequest request)
        {
            if (request == null || request.Details == null)
                return BadRequest("Dữ liệu không hợp lệ");

            var totalAmount = request.Details.Sum(d => d.Total ?? 0);

            return Ok(new
            {
                request.BillId,
                TotalItems = request.Details.Count,
                TotalAmount = totalAmount
            });
        }

        // =========================
        // 1. Lấy hóa đơn theo tháng
        // =========================
        [HttpGet("owner/{ownerId}")]
        public async Task<IActionResult> GetBillsByMonth(
            Guid ownerId,
            [FromQuery] int month,
            [FromQuery] int year)
        {
            var bills = await _billService.GetBillsByMonthAsync(month, year, ownerId);
            return Ok(bills);
        }

        // =========================
        // 2. Hóa đơn chưa thanh toán
        // =========================
        [HttpGet("owner/{ownerId}/unpaid")]
        public async Task<IActionResult> GetUnpaidBills(Guid ownerId)
        {
            var bills = await _billService.GetUnpaidBillsAsync(ownerId);
            return Ok(bills);
        }

        // =========================
        // 3. Hóa đơn theo người thuê
        // =========================
        [HttpGet("renter/{renterId}")]
        public async Task<IActionResult> GetBillsByRenter(Guid renterId)
        {
            var bills = await _billService.GetBillsByRenterAsync(renterId);
            return Ok(bills);
        }

        // =========================
        // 4. Lấy hóa đơn + chi tiết
        // =========================
        [HttpGet("{billId}")]
        public async Task<IActionResult> GetBillWithDetails(Guid billId)
        {
            var bill = await _billService.GetBillWithDetailsAsync(billId);
            if (bill == null)
                return NotFound("Không tìm thấy hóa đơn");

            return Ok(bill);
        }

        // =========================
        // 5. Tạo hóa đơn mới
        // =========================
        [HttpPost]
        public async Task<IActionResult> CreateBill([FromBody] Bill bill)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bill.Id = Guid.NewGuid();
            bool success = await _billService.CreateBillAsync(bill);

            if (!success)
                return BadRequest("Không thể tạo hóa đơn");

            return CreatedAtAction(nameof(GetBillWithDetails),
                new { billId = bill.Id },
                bill);
        }

        // =========================
        // 6. Thanh toán hóa đơn
        // =========================
        [HttpPost("{billId}/pay")]
        public async Task<IActionResult> PayBill(
            Guid billId,
            [FromQuery] decimal amount,
            [FromQuery] string paymentMethod)
        {
            bool success = await _billService.PayBillAsync(billId, amount, paymentMethod);
            if (!success)
                return BadRequest("Thanh toán thất bại");

            return Ok("Thanh toán thành công");
        }

        // =========================
        // 7. Hóa đơn chưa trả mới nhất
        // =========================
        [HttpGet("renter/{renterId}/latest-unpaid")]
        public async Task<IActionResult> GetLatestUnpaidBill(Guid renterId)
        {
            var bill = await _billService.GetLatestUnpaidBillAsync(renterId);
            if (bill == null)
                return NotFound("Không có hóa đơn chưa thanh toán");

            return Ok(bill);
        }

        // =========================
        // 8. Thống kê chi tiêu 12 tháng
        // =========================
        [HttpGet("renter/{renterId}/spending")]
        public async Task<IActionResult> GetMonthlySpending(Guid renterId)
        {
            var data = await _billService.GetMonthlySpendingAsync(renterId);
            return Ok(data);
        }

        // =========================
        // 9. Cập nhật hóa đơn + chi tiết
        // =========================
        [HttpPut("{billId}")]
        public async Task<IActionResult> UpdateBill(
            Guid billId,
            [FromBody] List<BillDetail> details,
            [FromQuery] decimal totalMoney)
        {
            bool success = await _billService.UpdateBillAndDetails(billId, details, totalMoney);
            if (!success)
                return BadRequest("Cập nhật thất bại");

            return NoContent();
        }
    }
}
