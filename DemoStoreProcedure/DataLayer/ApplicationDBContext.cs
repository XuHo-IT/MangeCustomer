using DemoStoreProcedure.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoStoreProcedure.DataLayer
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> Customer { get; set; }
    }
}
