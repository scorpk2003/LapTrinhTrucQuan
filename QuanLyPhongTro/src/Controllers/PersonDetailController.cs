using QuanLyPhongTro.src.Models;
using QuanLyPhongTro.src.Services1;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyPhongTro.src.Controllers
{
    [ApiController]
    [Route("api/person-details")]
    public class PersonDetailController : ControllerBase
    {
        private readonly PersonDetailServices _service;

        public PersonDetailController()
        {
            _service = new PersonDetailServices();
        }

        /// <summary>
        /// Lấy chi tiết người dùng theo Id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetPersonDetailByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Lấy tất cả chi tiết người dùng
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllPersonDetailsAsync();
            return Ok(result);
        }

        /// <summary>
        /// Thêm chi tiết người dùng
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonDetail detail)
        {
            var success = await _service.AddPersonDetailAsync(detail);
            if (!success) return BadRequest("Không thể thêm người dùng");
            return Ok(detail);
        }

        /// <summary>
        /// Cập nhật chi tiết người dùng
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PersonDetail detail)
        {
            if (id != detail.Id) return BadRequest("Id không khớp");

            var success = await _service.UpdatePersonDetailAsync(detail);
            if (!success) return BadRequest("Cập nhật thất bại");

            return Ok(detail);
        }

        /// <summary>
        /// Xóa chi tiết người dùng
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.DeletePersonDetailAsync(id);
            if (!success) return NotFound();

            return Ok("Đã xóa thành công");
        }

        /// <summary>
        /// Tìm theo CCCD
        /// </summary>
        [HttpGet("by-cccd/{cccd}")]
        public async Task<IActionResult> GetByCccd(string cccd)
        {
            var result = await _service.GetByCardIdAsync(cccd);
            if (result == null) return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Tìm theo số điện thoại
        /// </summary>
        [HttpGet("by-phone/{phone}")]
        public async Task<IActionResult> GetByPhone(string phone)
        {
            var result = await _service.GetByPhoneAsync(phone);
            if (result == null) return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Tìm theo email
        /// </summary>
        [HttpGet("by-email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var result = await _service.GetByEmailAsync(email);
            if (result == null) return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Tìm kiếm theo tên
        /// </summary>
        [HttpGet("search")]
        public async Task<IActionResult> SearchByName([FromQuery] string keyword)
        {
            var result = await _service.SearchByNameAsync(keyword);
            return Ok(result);
        }

        /// <summary>
        /// Lấy theo giới tính
        /// </summary>
        [HttpGet("gender/{gender}")]
        public async Task<IActionResult> GetByGender(string gender)
        {
            var result = await _service.GetByGenderAsync(gender);
            return Ok(result);
        }

        /// <summary>
        /// Đếm tổng số người dùng
        /// </summary>
        [HttpGet("count")]
        public async Task<IActionResult> Count()
        {
            var count = await _service.CountAllAsync();
            return Ok(count);
        }

        /// <summary>
        /// Lấy chi tiết người dùng kèm Person
        /// </summary>
        [HttpGet("{id}/with-person")]
        public async Task<IActionResult> GetWithPerson(Guid id)
        {
            var result = await _service.GetPersonDetailWithPersonAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
