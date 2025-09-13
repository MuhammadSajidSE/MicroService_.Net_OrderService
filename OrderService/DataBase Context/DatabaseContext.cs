using Microsoft.EntityFrameworkCore;
using OrderService.Models;

namespace OrderService.DataBase_Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
    }

}
