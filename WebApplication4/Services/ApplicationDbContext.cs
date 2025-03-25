using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
    }
}
