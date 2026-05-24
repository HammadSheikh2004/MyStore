using Microsoft.EntityFrameworkCore;
using MinimalAPI.Models;

namespace MinimalAPI.DbContextClass
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> dbOptions) : base(dbOptions) { }
        
        public DbSet<Products> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
    }
}
