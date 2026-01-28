using API_Server.src.Models;
using API_Server.src.Services1;
using Microsoft.AspNetCore.Mvc;
using API_Server.src.Models;
using API_Server.src.Services1;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Server.src.Controllers
{
    [ApiController]
    [Route("api/people")]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _service;

        public PersonController()
        {
            _service = new PersonService();
        }

        // ========================= AUTH =========================

        /// <summary>
        /// Đăng nhập
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var person = await _service.GetAccountAsync(request.Username, request.Password);
            if (person == null)
                return Unauthorized("Sai tài khoản hoặc mật khẩu");

            return Ok(person);
        }

        /// <summary>
        /// Đăng ký (chỉ Person)
        /// </summary>
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] Person person)
        {
            var success = await _service.SignUpAsync(person);
            if (!success) return BadRequest("Đăng ký thất bại");

            return Ok("Đăng ký thành công");
        }

        /// <summary>
        /// Đăng ký Person + PersonDetail
        /// </summary>
        [HttpPost("signup-with-detail")]
        public async Task<IActionResult> SignUpWithDetail([FromBody] SignUpRequest request)
        {
            var success = await _service.SignUpWithDetailAsync(request.Person, request.Detail);
            if (!success) return BadRequest("Đăng ký thất bại");

            return Ok("Đăng ký thành công");
        }

        // ========================= GET =========================

        /// <summary>
        /// Lấy Person theo Id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var person = await _service.GetByIdAsync(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        /// <summary>
        /// Lấy Person kèm PersonDetail
        /// </summary>
        [HttpGet("{id}/detail")]
        public async Task<IActionResult> GetWithDetail(Guid id)
        {
            var person = await _service.GetPersonWithDetailAsync(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        /// <summary>
        /// Lấy tất cả người dùng
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllPeopleAsync());
        }

        /// <summary>
        /// Lấy người dùng theo Role
        /// </summary>
        [HttpGet("role/{role}")]
        public async Task<IActionResult> GetByRole(string role)
        {
            return Ok(await _service.GetPeopleByRoleAsync(role));
        }

        /// <summary>
        /// Tìm kiếm người dùng
        /// </summary>
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            return Ok(await _service.SearchPeopleAsync(keyword));
        }

        // ========================= UPDATE =========================

        /// <summary>
        /// Cập nhật Person
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> UpdatePerson([FromBody] Person person)
        {
            var success = await _service.UpdatePersonAsync(person);
            if (!success) return BadRequest("Cập nhật thất bại");

            return Ok("Cập nhật thành công");
        }

        /// <summary>
        /// Cập nhật PersonDetail
        /// </summary>
        [HttpPut("detail")]
        public async Task<IActionResult> UpdateDetail([FromBody] PersonDetail detail)
        {
            var success = await _service.UpdatePersonDetailAsync(detail);
            if (!success) return BadRequest("Cập nhật thất bại");

            return Ok("Cập nhật thành công");
        }

        /// <summary>
        /// Đổi mật khẩu
        /// </summary>
        [HttpPut("{id}/change-password")]
        public async Task<IActionResult> ChangePassword(Guid id, [FromBody] ChangePasswordRequest request)
        {
            var success = await _service.ChangePasswordAsync(id, request.OldPassword, request.NewPassword);
            if (!success) return BadRequest("Đổi mật khẩu thất bại");

            return Ok("Đổi mật khẩu thành công");
        }

        /// <summary>
        /// Reset mật khẩu (Admin)
        /// </summary>
        [HttpPut("{id}/reset-password")]
        public async Task<IActionResult> ResetPassword(Guid id, [FromBody] string newPassword)
        {
            var success = await _service.ResetPasswordAsync(id, newPassword);
            if (!success) return BadRequest("Reset mật khẩu thất bại");

            return Ok("Reset mật khẩu thành công");
        }

        // ========================= DELETE =========================

        /// <summary>
        /// Xóa Person
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.DeletePersonAsync(id);
            if (!success) return NotFound();

            return Ok("Đã xóa thành công");
        }

        // ========================= CHECK =========================

        [HttpGet("check-email")]
        public async Task<IActionResult> CheckEmail([FromQuery] string email)
        {
            return Ok(await _service.IsEmailExistsAsync(email));
        }

        [HttpGet("check-username")]
        public async Task<IActionResult> CheckUsername([FromQuery] string username)
        {
            return Ok(await _service.IsUsernameExistsAsync(username));
        }

        [HttpGet("count/{role}")]
        public async Task<IActionResult> CountByRole(string role)
        {
            return Ok(await _service.CountByRoleAsync(role));
        }
    }

    // ========================= DTO =========================

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class ChangePasswordRequest
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class SignUpRequest
    {
        public Person Person { get; set; }
        public PersonDetail Detail { get; set; }
    }
}
