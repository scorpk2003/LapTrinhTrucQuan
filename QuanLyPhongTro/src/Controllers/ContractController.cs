using QuanLyPhongTro.src.Services1;
using Microsoft.AspNetCore.Mvc;
using QuanLyPhongTro.src.Models;

namespace API_Server.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractController : ControllerBase
    {
        private readonly ContractService _service;

        public ContractController()
        {
            _service = new ContractService();
        }

        /// <summary>
        /// Lấy hợp đồng đang hoạt động theo phòng
        /// GET: api/Contract/room/{roomId}/active
        /// </summary>
        [HttpGet("room/{roomId}/active")]
        public async Task<IActionResult> GetActiveByRoom(Guid roomId)
        {
            var contract = await _service.GetActiveContractByRoomAsync(roomId);
            if (contract == null) return NotFound();
            return Ok(contract);
        }

        /// <summary>
        /// Lấy hợp đồng đang hoạt động theo người thuê
        /// GET: api/Contract/renter/{renterId}/active
        /// </summary>
        [HttpGet("renter/{renterId}/active")]
        public async Task<IActionResult> GetActiveByRenter(Guid renterId)
        {
            var contract = await _service.GetActiveContractByRenterAsync(renterId);
            if (contract == null) return NotFound();
            return Ok(contract);
        }

        /// <summary>
        /// Lấy tất cả hợp đồng đang hoạt động của owner
        /// GET: api/Contract/owner/{ownerId}/active
        /// </summary>
        [HttpGet("owner/{ownerId}/active")]
        public async Task<IActionResult> GetActiveByOwner(Guid ownerId)
        {
            var result = await _service.GetAllActiveContractsByOwnerAsync(ownerId);
            return Ok(result);
        }

        /// <summary>
        /// Tạo hợp đồng mới
        /// POST: api/Contract
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Contract contract)
        {
            if (contract == null) return BadRequest();

            var success = await _service.CreateContractAsync(contract);
            if (!success) return BadRequest("Không thể tạo hợp đồng");

            return Ok("Tạo hợp đồng thành công");
        }

        /// <summary>
        /// Kết thúc hợp đồng
        /// PUT: api/Contract/{id}/end
        /// </summary>
        [HttpPut("{id}/end")]
        public async Task<IActionResult> End(Guid id)
        {
            var success = await _service.EndContractAsync(id);
            if (!success) return BadRequest("Không thể kết thúc hợp đồng");

            return Ok("Đã kết thúc hợp đồng");
        }

        /// <summary>
        /// Gia hạn hợp đồng
        /// PUT: api/Contract/renew
        /// </summary>
        [HttpPut("renew")]
        public async Task<IActionResult> Renew(
            [FromQuery] Guid roomId,
            [FromQuery] int months)
        {
            var success = await _service.RenewContractAsync(roomId, months);
            if (!success) return BadRequest("Gia hạn thất bại");

            return Ok("Gia hạn thành công");
        }

        /// <summary>
        /// Lấy hợp đồng theo ID
        /// GET: api/Contract/{id}
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var contract = await _service.GetContractByIdAsync(id);
            if (contract == null) return NotFound();

            return Ok(contract);
        }

        /// <summary>
        /// Lấy hợp đồng theo renter
        /// GET: api/Contract/renter/{renterId}
        /// </summary>
        [HttpGet("renter/{renterId}")]
        public async Task<IActionResult> GetByRenter(Guid renterId)
        {
            var result = await _service.GetContractsByRenterAsync(renterId);
            return Ok(result);
        }

        /// <summary>
        /// Lấy hợp đồng sắp hết hạn
        /// GET: api/Contract/owner/{ownerId}/expiring
        /// </summary>
        [HttpGet("owner/{ownerId}/expiring")]
        public async Task<IActionResult> GetExpiring(
            Guid ownerId,
            [FromQuery] int days = 30)
        {
            var result = await _service.GetExpiringContractsAsync(ownerId, days);
            return Ok(result);
        }

        /// <summary>
        /// Đếm hợp đồng đang hoạt động
        /// GET: api/Contract/owner/{ownerId}/count-active
        /// </summary>
        [HttpGet("owner/{ownerId}/count-active")]
        public async Task<IActionResult> CountActive(Guid ownerId)
        {
            var count = await _service.CountActiveContractsAsync(ownerId);
            return Ok(count);
        }

        /// <summary>
        /// Kiểm tra phòng có hợp đồng active không
        /// GET: api/Contract/room/{roomId}/has-active
        /// </summary>
        [HttpGet("room/{roomId}/has-active")]
        public async Task<IActionResult> HasActive(Guid roomId)
        {
            var has = await _service.HasActiveContractAsync(roomId);
            return Ok(has);
        }

        /// <summary>
        /// Cập nhật hợp đồng
        /// PUT: api/Contract
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Contract contract)
        {
            var success = await _service.UpdateContractAsync(contract);
            if (!success) return BadRequest("Cập nhật thất bại");

            return Ok("Cập nhật thành công");
        }

        /// <summary>
        /// Lấy hợp đồng theo trạng thái
        /// GET: api/Contract/owner/{ownerId}/status/{status}
        /// </summary>
        [HttpGet("owner/{ownerId}/status/{status}")]
        public async Task<IActionResult> GetByStatus(Guid ownerId, string status)
        {
            var result = await _service.GetContractsByStatusAsync(ownerId, status);
            return Ok(result);
        }

        /// <summary>
        /// Tính tổng tiền đặt cọc đang giữ
        /// GET: api/Contract/owner/{ownerId}/total-deposit
        /// </summary>
        [HttpGet("owner/{ownerId}/total-deposit")]
        public async Task<IActionResult> TotalDeposit(Guid ownerId)
        {
            var total = await _service.GetTotalDepositAsync(ownerId);
            return Ok(total);
        }
    }
}
