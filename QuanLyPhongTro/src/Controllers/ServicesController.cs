using QuanLyPhongTro.src.Models;
using QuanLyPhongTro.src.Services1;
using Microsoft.AspNetCore.Mvc;
using API_Server.src.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly ServiceServices _serviceServices;

        public ServicesController()
        {
            _serviceServices = new ServiceServices();
        }

        // GET: api/services
        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            var services = await _serviceServices.GetAllServicesAsync();
            return Ok(services);
        }

        // GET: api/services/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(Guid id)
        {
            var service = await _serviceServices.GetServiceByIdAsync(id);
            if (service == null)
                return NotFound("Không tìm thấy dịch vụ");

            return Ok(service);
        }

        // POST: api/services
        [HttpPost]
        public async Task<IActionResult> AddService([FromBody] Service service)
        {
            if (service == null)
                return BadRequest("Dữ liệu không hợp lệ");

            // kiểm tra trùng tên
            if (await _serviceServices.IsServiceNameExistsAsync(service.Name))
                return BadRequest("Tên dịch vụ đã tồn tại");

            var success = await _serviceServices.AddServiceAsync(service);
            if (!success)
                return BadRequest("Thêm dịch vụ thất bại");

            return Ok(service);
        }

        // PUT: api/services/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(Guid id, [FromBody] Service service)
        {
            if (service == null || id != service.Id)
                return BadRequest("Dữ liệu không hợp lệ");

            // kiểm tra trùng tên (trừ chính nó)
            if (await _serviceServices.IsServiceNameExistsAsync(service.Name, id))
                return BadRequest("Tên dịch vụ đã tồn tại");

            var success = await _serviceServices.UpdateServiceAsync(service);
            if (!success)
                return NotFound("Không tìm thấy dịch vụ");

            return Ok("Cập nhật thành công");
        }

        // DELETE: api/services/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(Guid id)
        {
            // kiểm tra đang được sử dụng
            if (await _serviceServices.IsServiceInUseAsync(id))
                return BadRequest("Dịch vụ đang được sử dụng, không thể xóa");

            var success = await _serviceServices.DeleteServiceAsync(id);
            if (!success)
                return NotFound("Không tìm thấy dịch vụ");

            return Ok("Xóa thành công");
        }

        // GET: api/services/search?keyword=...
        [HttpGet("search")]
        public async Task<IActionResult> SearchServices([FromQuery] string keyword)
        {
            var services = await _serviceServices.SearchServicesAsync(keyword ?? "");
            return Ok(services);
        }

        // GET: api/services/unit/{unit}
        [HttpGet("unit/{unit}")]
        public async Task<IActionResult> GetServicesByUnit(string unit)
        {
            var services = await _serviceServices.GetServicesByUnitAsync(unit);
            return Ok(services);
        }

        // GET: api/services/price-range?min=0&max=100000
        [HttpGet("price-range")]
        public async Task<IActionResult> GetServicesByPriceRange(
            [FromQuery] decimal min,
            [FromQuery] decimal max)
        {
            var services = await _serviceServices.GetServicesByPriceRangeAsync(min, max);
            return Ok(services);
        }

        // GET: api/services/statistics
        [HttpGet("statistics")]
        public async Task<IActionResult> GetServiceStatistics()
        {
            var stats = await _serviceServices.GetServiceStatisticsAsync();
            return Ok(stats);
        }

        // GET: api/services/count
        [HttpGet("count")]
        public async Task<IActionResult> CountServices()
        {
            var count = await _serviceServices.CountServicesAsync();
            return Ok(count);
        }

        // GET: api/services/units
        [HttpGet("units")]
        public async Task<IActionResult> GetDistinctUnits()
        {
            var units = await _serviceServices.GetDistinctUnitsAsync();
            return Ok(units);
        }

        // PUT: api/services/bulk-update-price
        [HttpPut("bulk-update-price")]
        public async Task<IActionResult> BulkUpdatePrice(
            [FromBody] BulkUpdatePriceRequest request)
        {
            var success = await _serviceServices
                .BulkUpdatePriceAsync(request.ServiceIds, request.NewPrice);

            if (!success)
                return BadRequest("Cập nhật thất bại");

            return Ok("Cập nhật giá thành công");
        }

        // PUT: api/services/{id}/adjust-price
        [HttpPut("{id}/adjust-price")]
        public async Task<IActionResult> AdjustPriceByPercentage(
            Guid id,
            [FromQuery] decimal percentage)
        {
            var success = await _serviceServices
                .AdjustPriceByPercentageAsync(id, percentage);

            if (!success)
                return NotFound("Không tìm thấy dịch vụ");

            return Ok("Điều chỉnh giá thành công");
        }
    }

    // DTO cho bulk update
    public class BulkUpdatePriceRequest
    {
        public List<Guid> ServiceIds { get; set; } = new();
        public decimal NewPrice { get; set; }
    }
}
