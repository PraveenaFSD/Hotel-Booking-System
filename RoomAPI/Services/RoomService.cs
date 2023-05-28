using RoomAPI.Interfaces;
using RoomAPI.Models;
using System.Linq;

namespace RoomAPI.Services
{
    public class RoomService
    {
        private readonly IRoomRepo<int, Room> _repo;

        public RoomService(IRoomRepo<int, Room> repo)
        {
            _repo = repo;
        }

        public ICollection<Room> RoomsByPrice(int price) {
            ICollection<Room> rooms = _repo.GetAll().Where(u=>u.RoomPrice==price).ToList(); 
            if(rooms.Count!=0)
            {
                return rooms;
            }
            return null;
        }
        public ICollection<Room> RoomsByPriceRange(int minPrice,int maxPrice)
        {
            ICollection<Room> rooms = _repo.GetAll().Where(p => p.RoomPrice >= minPrice && p.RoomPrice <= maxPrice).ToList();
            if (rooms.Count != 0)
            {
                return rooms;
            }
            return null;
        }
        public int  CountofAvailableRooms()
        {
            ICollection<Room> roomDetails=_repo.GetAll().Where(p => p.Availability.Contains("Available")).ToList();    
            int rooms=roomDetails.Count;
            return rooms;
    
        }
         public int CountofAvailableRoomsByHotel(int hotelId)
        {
            ICollection<Room> roomDetails = _repo.GetAll().Where(p => p.Availability.ToLower().Contains("available") && p.HotelId==hotelId).ToList();
            int rooms = roomDetails.Count;
            return rooms;

        }
        public ICollection<Room> AvailableRooms()
        {
            ICollection<Room> rooms = _repo.GetAll().Where(p => p.Availability.ToLower().Contains("available") ).ToList();
            return rooms;
        }


    }
}
