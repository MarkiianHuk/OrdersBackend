using Microsoft.EntityFrameworkCore;
using OrdersBackend.DAL.Models;

namespace OrdersBackend.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
    }
}
