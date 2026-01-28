using Microsoft.AspNetCore.Mvc;
using API_Server.src.DTO.Bill;
using API_Server.src.Models;
using API_Server.src.Services1;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace API_Server.src.Controllers
{
    /// <summary>
    /// Controller quản lý chi tiết hóa đơn
    /// </summary>
    [ApiController]
    [Route("api/billdetail")]
    [Produces("application/json")]
    public class BillDetailController : ControllerBase
    {
        private readonly BillDetailServices _service;

        public BillDetailController()
        {
            _service = new BillDetailServices();
        }

        /// <summary>
        /// Lấy danh sách chi tiết hóa đơn theo BillId
        /// </summary>
        /// <param name="billId">ID của hóa đơn</param>
        /// <returns>Danh sách chi tiết hóa đơn</returns>
        /// <response code="200">Trả về danh sách chi tiết hóa đơn</response>
        /// <response code="404">Không tìm thấy chi tiết hóa đơn</response>
        /// <response code="500">Lỗi server</response>
        [HttpGet("bill/{billId}")]
        [ProducesResponseType(typeof(List<BillDetail>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<BillDetail>>> GetByBillId(Guid billId)
        {
            try
            {
                var details = await _service.GetBillDetailsByBillIdAsync(billId);

                if (details == null || details.Count == 0)
                    return NotFound(new
                    {
                        success = false,
                        message = $"Không tìm thấy chi tiết hóa đơn cho Bill ID {billId}"
                    });

                return Ok(new
                {
                    success = true,
                    message = "Lấy danh sách chi tiết hóa đơn thành công",
                    data = details,
                    count = details.Count
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Lỗi server",
                    error = ex.Message
                });
            }
        }

        /// <summary>
        /// Lấy hóa đơn kèm chi tiết đầy đủ (bao gồm thông tin thanh toán)
        /// </summary>
        /// <param name="billId">ID của hóa đơn</param>
        /// <returns>Hóa đơn với đầy đủ thông tin</returns>
        /// <response code="200">Trả về hóa đơn đầy đủ</response>
        /// <response code="404">Không tìm thấy hóa đơn</response>
        [HttpGet("bill/{billId}/full")]
        [ProducesResponseType(typeof(Bill), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Bill>> GetBillWithDetails(Guid billId)
        {
            try
            {
                var bill = await _service.GetBillWithDetailsAsync(billId);

                if (bill == null)
                    return NotFound(new
                    {
                        success = false,
                        message = $"Không tìm thấy hóa đơn với ID {billId}"
                    });

                return Ok(new
                {
                    success = true,
                    message = "Lấy thông tin hóa đơn thành công",
                    data = bill
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Lỗi server",
                    error = ex.Message
                });
            }
        }

        /// <summary>
        /// Thêm nhiều chi tiết hóa đơn cùng lúc
        /// </summary>
        /// <param name="request">Danh sách chi tiết cần thêm</param>
        /// <returns>Kết quả thêm chi tiết</returns>
        /// <response code="201">Thêm chi tiết thành công</response>
        /// <response code="400">Dữ liệu không hợp lệ</response>
        [HttpPost("bulk")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddBulk([FromBody] AddBillDetailsRequest request)
        {
            try
            {
                // Validate request
                if (!ModelState.IsValid)
                    return BadRequest(new
                    {
                        success = false,
                        message = "Dữ liệu không hợp lệ",
                        errors = ModelState
                    });

                if (request.Details == null || request.Details.Count == 0)
                    return BadRequest(new
                    {
                        success = false,
                        message = "Danh sách chi tiết không được rỗng"
                    });

                // Gán ID và BillId cho tất cả details
                foreach (var detail in request.Details)
                {
                    detail.Id = Guid.NewGuid();
                    detail.IdBill = request.BillId;

                    // Tính toán Total nếu chưa có
                    if (!detail.Total.HasValue && detail.Quantity.HasValue)
                    {
                        // Lấy giá từ service nếu cần
                        detail.Total = detail.Quantity.Value * (detail.Electricity ?? 0 + detail.Water ?? 0);
                    }
                }

                bool success = await _service.AddBillDetailsAsync(request.Details);

                if (success)
                    return CreatedAtAction(
                        nameof(GetByBillId),
                        new { billId = request.BillId },
                        new
                        {
                            success = true,
                            message = "Thêm chi tiết hóa đơn thành công",
                            data = request.Details,
                            count = request.Details.Count
                        });

                return BadRequest(new
                {
                    success = false,
                    message = "Không thể thêm chi tiết hóa đơn"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Lỗi server",
                    error = ex.Message
                });
            }
        }

        /// <summary>
        /// Thêm một chi tiết hóa đơn
        /// </summary>
        /// <param name="detail">Chi tiết hóa đơn cần thêm</param>
        /// <returns>Kết quả thêm chi tiết</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] BillDetail detail)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                detail.Id = Guid.NewGuid();

                var details = new List<BillDetail> { detail };
                bool success = await _service.AddBillDetailsAsync(details);

                if (success)
                    return CreatedAtAction(
                        nameof(GetByBillId),
                        new { billId = detail.IdBill },
                        new
                        {
                            success = true,
                            message = "Thêm chi tiết hóa đơn thành công",
                            data = detail
                        });

                return BadRequest(new
                {
                    success = false,
                    message = "Không thể thêm chi tiết hóa đơn"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Lỗi server",
                    error = ex.Message
                });
            }
        }

        /// <summary>
        /// Cập nhật chi tiết hóa đơn
        /// </summary>
        /// <param name="id">ID của chi tiết hóa đơn</param>
        /// <param name="detail">Thông tin chi tiết hóa đơn mới</param>
        /// <returns>Kết quả cập nhật</returns>
        /// <response code="204">Cập nhật thành công</response>
        /// <response code="400">ID không khớp</response>
        /// <response code="404">Không tìm thấy chi tiết</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid id, [FromBody] BillDetail detail)
        {
            try
            {
                if (id != detail.Id)
                    return BadRequest(new
                    {
                        success = false,
                        message = "ID không khớp"
                    });

                if (!ModelState.IsValid)
                    return BadRequest(new
                    {
                        success = false,
                        message = "Dữ liệu không hợp lệ",
                        errors = ModelState
                    });

                bool success = await _service.UpdateBillDetailAsync(detail);

                if (success)
                    return NoContent();

                return NotFound(new
                {
                    success = false,
                    message = $"Không tìm thấy chi tiết hóa đơn với ID {id}"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Lỗi server",
                    error = ex.Message
                });
            }
        }

        /// <summary>
        /// Xóa một chi tiết hóa đơn
        /// </summary>
        /// <param name="id">ID của chi tiết hóa đơn</param>
        /// <returns>Kết quả xóa</returns>
        /// <response code="204">Xóa thành công</response>
        /// <response code="404">Không tìm thấy chi tiết</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                bool success = await _service.DeleteBillDetailAsync(id);

                if (success)
                    return NoContent();

                return NotFound(new
                {
                    success = false,
                    message = $"Không tìm thấy chi tiết hóa đơn với ID {id}"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Lỗi server",
                    error = ex.Message
                });
            }
        }

        /// <summary>
        /// Xóa tất cả chi tiết của một hóa đơn
        /// </summary>
        /// <param name="billId">ID của hóa đơn</param>
        /// <returns>Kết quả xóa</returns>
        /// <response code="204">Xóa thành công</response>
        [HttpDelete("bill/{billId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAllByBill(Guid billId)
        {
            try
            {
                bool success = await _service.DeleteBillDetailsByBillIdAsync(billId);

                if (success)
                    return NoContent();

                return Ok(new
                {
                    success = true,
                    message = "Không có chi tiết nào để xóa"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Lỗi server",
                    error = ex.Message
                });
            }
        }

        /// <summary>
        /// Lấy tổng tiền của một hóa đơn
        /// </summary>
        /// <param name="billId">ID của hóa đơn</param>
        /// <returns>Tổng tiền</returns>
        /// <response code="200">Trả về tổng tiền</response>
        [HttpGet("bill/{billId}/total")]
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        public async Task<ActionResult<decimal>> GetTotalAmount(Guid billId)
        {
            try
            {
                var total = await _service.GetTotalAmountByBillIdAsync(billId);
                return Ok(new
                {
                    success = true,
                    billId = billId,
                    totalAmount = total,
                    formattedAmount = $"{total:N0} VND"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Lỗi server",
                    error = ex.Message
                });
            }
        }

        /// <summary>
        /// Kiểm tra chi tiết hóa đơn có tồn tại không
        /// </summary>
        /// <param name="id">ID của chi tiết hóa đơn</param>
        /// <returns>True nếu tồn tại, False nếu không</returns>
        /// <response code="200">Trả về kết quả kiểm tra</response>
        [HttpGet("{id}/exists")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Exists(Guid id)
        {
            try
            {
                bool exists = await _service.ExitsAsync(id);
                return Ok(new
                {
                    success = true,
                    id = id,
                    exists = exists
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Lỗi server",
                    error = ex.Message
                });
            }
        }

        /// <summary>
        /// Lấy thống kê chi tiết hóa đơn theo BillId
        /// </summary>
        /// <param name="billId">ID của hóa đơn</param>
        /// <returns>Thống kê chi tiết</returns>
        [HttpGet("bill/{billId}/statistics")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetStatistics(Guid billId)
        {
            try
            {
                var details = await _service.GetBillDetailsByBillIdAsync(billId);
                var total = await _service.GetTotalAmountByBillIdAsync(billId);

                return Ok(new
                {
                    success = true,
                    billId = billId,
                    statistics = new
                    {
                        totalItems = details.Count,
                        totalAmount = total,
                        totalElectricity = details.Sum(d => d.Electricity ?? 0),
                        totalWater = details.Sum(d => d.Water ?? 0),
                        averageAmount = details.Count > 0 ? total / details.Count : 0,
                        details = details.Select(d => new
                        {
                            d.Id,
                            serviceName = d.IdServiceNavigation?.Name,
                            d.Quantity,
                            d.Electricity,
                            d.Water,
                            d.Total
                        })
                    }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Lỗi server",
                    error = ex.Message
                });
            }
        }
    }
}