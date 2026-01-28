using API_Server.src.Models;
using API_Server.src.Services1;
using Microsoft.AspNetCore.Mvc;
using API_Server.src.Models;
using API_Server.src.Services1;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly RoomService _roomService;

        public RoomsController()
        {
            _roomService = new RoomService();
        }

        // GET: api/rooms/owner/{ownerId}
        [HttpGet("owner/{ownerId}")]
        public async Task<IActionResult> GetRoomsByOwner(Guid ownerId)
        {
            var rooms = await _roomService.GetAllRoomsByOwnerAsync(ownerId);
            return Ok(rooms);
        }

        // GET: api/rooms/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(Guid id)
        {
            var room = await _roomService.GetRoomWithDetailsAsync(id);
            if (room == null)
                return NotFound();

            return Ok(room);
        }

        // POST: api/rooms
        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] Room room)
        {
            if (room == null)
                return BadRequest();

            var success = await _roomService.CreateRoomAsync(room, new List<string>());

            if (!success)
                return BadRequest("Tạo phòng thất bại");

            return Ok(room);
        }

        // PUT: api/rooms
        [HttpPut]
        public async Task<IActionResult> UpdateRoom([FromBody] Room room)
        {
            var success = await _roomService.UpdateRoomAsync(room);

            if (!success)
                return NotFound("Không tìm thấy phòng");

            return Ok("Cập nhật thành công");
        }

        // DELETE: api/rooms/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(Guid id)
        {
            var success = await _roomService.DeleteRoomAsync(id);

            if (!success)
                return NotFound("Không tìm thấy phòng");

            return Ok("Xóa thành công");
        }

        // GET: api/rooms/available
        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableRooms()
        {
            var rooms = await _roomService.GetAllAvailableRoomsAsync();
            return Ok(rooms);
        }

        // GET: api/rooms/statistics/{ownerId}
        [HttpGet("statistics/{ownerId}")]
        public async Task<IActionResult> GetRoomStatistics(Guid ownerId)
        {
            var stats = await _roomService.GetRoomStatisticsAsync(ownerId);
            return Ok(stats);
        }
    }
}
