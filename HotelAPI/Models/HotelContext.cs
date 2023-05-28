using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Models
{
    public class HotelContext:DbContext
    {
        public HotelContext() { }
        public HotelContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
