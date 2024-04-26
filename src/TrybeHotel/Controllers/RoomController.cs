using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("room")]
    public class RoomController : Controller
    {
        private readonly IRoomRepository _repository;
        public RoomController(IRoomRepository repository)
        {
            _repository = repository;
        }

        // 6. Desenvolva o endpoint GET /room/:hotelId
        [HttpGet("{HotelId}")]
        public IActionResult GetRoom(int HotelId){
            try
            {
                if (HotelId.GetType() != typeof(int))
                    return BadRequest("HotelId must be an integer");
                else if (HotelId < 0)
                    return BadRequest("HotelId must be a positive integer");
                
                return Ok(_repository.GetRooms(HotelId));
            }
            catch (Exception err)
            {
                
                throw new Exception(err.Message);
            }
        }

        // 7. Desenvolva o endpoint POST /room
        [HttpPost]
        public IActionResult PostRoom([FromBody] Room room){
            try
            {
                var newRoom = _repository.AddRoom(room);
                return Created("", newRoom);
            }
            catch (Exception err)
            {
                
                throw new Exception(err.Message);
            }
        }

        // 8. Desenvolva o endpoint DELETE /room/:roomId
        [HttpDelete("{RoomId}")]
        public IActionResult Delete(int RoomId)
        {
            if (RoomId.GetType() != typeof(int))
                return BadRequest("RoomId must be an integer");
            else if (RoomId < 0)
                return BadRequest("RoomId must be a positive integer");

            try
            {
                _repository.DeleteRoom(RoomId);
                return NoContent();
            }
            catch (Exception err)
            {
                
                throw new Exception(err.Message);
            }
        }
    }
}