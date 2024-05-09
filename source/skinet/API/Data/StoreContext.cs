using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace API.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}