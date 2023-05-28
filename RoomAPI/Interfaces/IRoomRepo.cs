using RoomAPI.Models;

namespace RoomAPI.Interfaces
{
    public interface IRoomRepo<K,T>
    {
        T Get(int roomId);
        ICollection<T> GetAll();
        T Add(Room room);
        T Update(Room hotel);
        T Delete(int roomlId);

    }
}
