using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomAPI.Interfaces;
using RoomAPI.Models;
using RoomAPI.Services;
using System.Text;

namespace RoomAPI.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepo<int, Room> _repo;
        private readonly RoomService _service;

        public RoomController(IRoomRepo<int,Room> roomRepo, RoomService roomService)
        {
            _repo=roomRepo;
            _service=roomService;
          
        }
        [Authorize(Roles ="staff")]
        [HttpPost("Add Rooms")]
        [ProducesResponseType(typeof(Room), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Room> AddRoomDetails([FromBody] Room room)
        {
            var resultRoom = _repo.Add(room);
            if (resultRoom != null)
            {
                return Ok(resultRoom);
            }
            return BadRequest(new { message="Cannot Add Room" });

        }

        [Authorize(Roles = "staff")]
        [HttpDelete("Delete Room Details")]
        [ProducesResponseType(typeof(Room), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Room> DeleteRoom(int roomId)
        {
            Room room = _repo.Get(roomId);
            if (room == null)
                return NotFound(new { message = "No such room is present" });
            room = _repo.Delete(roomId);
            if (room == null)
                return BadRequest(new { message="Unable to delete room details" });
            return Ok(room);
        }
        [Authorize(Roles ="staff")]
        [HttpPost("Update Room Details")]
        [ProducesResponseType(typeof(Room), 200)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<Room> UpdateRoomDetails([FromBody] Room room)
        {
            var roomResult = _repo.Update(room);
            if (roomResult != null)
            {
                return Ok(roomResult);
            }
            return BadRequest(new { message = "Cannot Update Room Details" });
        }
        [HttpGet("Get All Room Details")]
        [ProducesResponseType(typeof(ICollection<Room>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Room> GetAllRoomDetails()
        {
            ICollection<Room> roomHotel = _repo.GetAll().ToList();
            if (roomHotel != null)
            {
                return Ok(roomHotel);
            }
            return BadRequest(new { message="No Room Details" });

        }
        [HttpGet("Get Room Details By Id")]
        [ProducesResponseType(typeof(Room), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Room> GetRoomDetailsById(int roomId)
        {
            var resultRoom = _repo.Get(roomId);
            if (resultRoom != null)
            {
                return Ok(resultRoom);
            }
            return NotFound(new { message = "No room Details in this particular Id" });

        }
        [HttpGet("Get Room Details By Price")]
        [ProducesResponseType(typeof(ICollection<Room>), 200)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Room> GetRoomDetailsByPrice(int roomPrice)
        {
            ICollection<Room> rooms = _service.RoomsByPrice(roomPrice);
            if (rooms != null)
            {
                return Ok(rooms);
            }
            return NotFound(new { message = "No room Details in this particular price" });

        }
        [HttpGet("Get Room Details By Price Range")]
        [ProducesResponseType(typeof(ICollection<Room>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Room> GetRoomDetailsByPriceRange(int minPrice, int maxPrice)
        {
            ICollection<Room> rooms = _service.RoomsByPriceRange(minPrice, maxPrice);
            if (rooms != null)
            {
                return Ok(rooms);
            }
            return NotFound(new { message = "No room Details in this particular price range" });

        }

       
        [HttpGet("Get Count of available rooms")]
        [ProducesResponseType(typeof(RoomCount), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<RoomCount> GetCountofAvailableRooms()
        { 
            var roomCount = _service.CountofAvailableRooms();
            if (roomCount > 0)
            {
                return Ok(roomCount);

            }
            return NotFound(new { message = "No rooms Available" });

        }
        [HttpGet("Get Count of available rooms in particular hotel")]
        [ProducesResponseType(typeof(RoomCount), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<RoomCount> GetCountofAvailableRoomsByHotel(int hotelId)
        {
             var count = _service.CountofAvailableRoomsByHotel(hotelId);
            if (count > 0)
            {
                return Ok(count);

            }
            return NotFound(new { message = "No room Details in this particular hotel" });
        }



    }
}
