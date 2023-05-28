using RoomAPI.Interfaces;
using RoomAPI.Models;
using System.Diagnostics;

namespace RoomAPI.Services
{
    public class RoomRepo:IRoomRepo<int,Room>
    {
        private RoomContext _context;

        public RoomRepo(RoomContext roomContext) {
        _context=roomContext;
        }
        public Room Add(Room room)
        {
            try
            {
                 _context.Add(room);
                _context.SaveChanges();
                return room;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(room);
            }
            return null;
        }
        public ICollection<Room> GetAll()
        {
            ICollection<Room> rooms = _context.Rooms.ToList();

            if (rooms != null)
            {
                return rooms;
            }
            return null;
        }


        public Room Get(int roomId)
        {
            try
            {
                var roomDetails = _context.Rooms.FirstOrDefault(u => u.RoomId == roomId);
                return roomDetails;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                

            }
            return null;
        }
        public Room Update(Room room)
        {
            try
            {
                var roomDetails = _context.Rooms.FirstOrDefault(u => u.RoomId == room.HotelId);
                if (roomDetails != null)
                {
                    roomDetails.RoomType = room.RoomType;
                    roomDetails.Availability = room.Availability;
                    roomDetails.RoomCapacity = room.RoomCapacity;
                    roomDetails.RoomPrice = room.RoomPrice;
                    
                    _context.SaveChanges();
                    return roomDetails;

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(room);
            }

            return null;
        }
        public Room Delete(int roomId)
        {

            try
            {
                var room = Get(roomId);
                _context.Rooms.Remove(room);
                _context.SaveChanges();
                return room;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);


            }
            return null;
        }

    }
}
