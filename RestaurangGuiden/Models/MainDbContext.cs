using Microsoft.EntityFrameworkCore;
using RestaurangGuiden.Models;

namespace RestaurangGuiden.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

        public DbSet<Restaurang> Restauranger { get; set; }
        public DbSet<Meny> Menyer { get; set; }
    }
     
}
