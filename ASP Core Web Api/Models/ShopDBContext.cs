using Microsoft.EntityFrameworkCore;

namespace ASP_Core_Web_Api.Models
{
    public class ShopDBContext:DbContext
    {
        public ShopDBContext()
        {

        }
        public ShopDBContext(DbContextOptions<ShopDBContext> options)
        : base(options)
        {
        }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
    }
}
