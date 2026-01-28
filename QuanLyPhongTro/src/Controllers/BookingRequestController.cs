using QuanLyPhongTro.src.Models;
using QuanLyPhongTro.src.Services1;
using Microsoft.AspNetCore.Mvc;

namespace API_Server.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingRequestController : ControllerBase
    {
        private readonly BookingRequestService _service;

        public BookingRequestController()
        {
            _service = new BookingRequestService();
        }

        /// <summary>
        /// Tạo yêu cầu thuê phòng
        /// POST: api/BookingRequest
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateRequest([FromBody] BookingRequest request)
        {
            if (request == null)
                return BadRequest("Request is null");

            var success = await _service.CreateRequestAsync(request);
            if (!success)
                return BadRequest("Không thể tạo yêu cầu");

            return Ok("Tạo yêu cầu thành công");
        }

        /// <summary>
        /// Lấy các yêu cầu Pending theo Owner
        /// GET: api/BookingRequest/owner/{ownerId}/pending
        /// </summary>
        [HttpGet("owner/{ownerId}/pending")]
        public async Task<IActionResult> GetPendingByOwner(Guid ownerId)
        {
            var result = await _service.GetPendingRequestsByOwnerAsync(ownerId);
            return Ok(result);
        }

        /// <summary>
        /// Lấy chi tiết yêu cầu theo ID
        /// GET: api/BookingRequest/{id}
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var request = await _service.GetRequestByIdAsync(id);
            if (request == null)
                return NotFound("Không tìm thấy yêu cầu");

            return Ok(request);
        }

        /// <summary>
        /// Cập nhật trạng thái yêu cầu
        /// PUT: api/BookingRequest/{id}/status
        /// </summary>
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(
            Guid id,
            [FromQuery] string status)
        {
            var success = await _service.UpdateRequestStatusAsync(id, status);
            if (!success)
                return BadRequest("Cập nhật trạng thái thất bại");

            return Ok("Cập nhật trạng thái thành công");
        }

        /// <summary>
        /// Xóa yêu cầu
        /// DELETE: api/BookingRequest/{id}
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.DeleteRequestAsync(id);
            if (!success)
                return NotFound("Không tìm thấy yêu cầu");

            return Ok("Xóa thành công");
        }

        /// <summary>
        /// Lấy lịch sử yêu cầu của renter
        /// GET: api/BookingRequest/renter/{renterId}
        /// </summary>
        [HttpGet("renter/{renterId}")]
        public async Task<IActionResult> GetByRenter(Guid renterId)
        {
            var result = await _service.GetRequestsByRenterAsync(renterId);
            return Ok(result);
        }

        /// <summary>
        /// Lấy yêu cầu theo trạng thái của owner
        /// GET: api/BookingRequest/owner/{ownerId}/status/{status}
        /// </summary>
        [HttpGet("owner/{ownerId}/status/{status}")]
        public async Task<IActionResult> GetByStatus(Guid ownerId, string status)
        {
            var result = await _service.GetRequestsByStatusAsync(ownerId, status);
            return Ok(result);
        }

        /// <summary>
        /// Kiểm tra renter có yêu cầu pending cho phòng chưa
        /// GET: api/BookingRequest/check-pending
        /// </summary>
        [HttpGet("check-pending")]
        public async Task<IActionResult> HasPending(
            [FromQuery] Guid renterId,
            [FromQuery] Guid roomId)
        {
            var exists = await _service.HasPendingRequestAsync(renterId, roomId);
            return Ok(exists);
        }

        /// <summary>
        /// Đếm số yêu cầu pending của owner
        /// GET: api/BookingRequest/owner/{ownerId}/count-pending
        /// </summary>
        [HttpGet("owner/{ownerId}/count-pending")]
        public async Task<IActionResult> CountPending(Guid ownerId)
        {
            var count = await _service.CountPendingRequestsAsync(ownerId);
            return Ok(count);
        }

        /// <summary>
        /// Lấy yêu cầu gần nhất của renter cho phòng
        /// GET: api/BookingRequest/latest
        /// </summary>
        [HttpGet("latest")]
        public async Task<IActionResult> GetLatest(
            [FromQuery] Guid renterId,
            [FromQuery] Guid roomId)
        {
            var request = await _service.GetLatestRequestForRoomAsync(renterId, roomId);
            if (request == null)
                return NotFound();

            return Ok(request);
        }
    }
}
