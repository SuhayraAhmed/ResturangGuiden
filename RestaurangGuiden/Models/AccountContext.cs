using Microsoft.EntityFrameworkCore;

namespace RestaurangGuiden.Models
{
    public class AccountContext : DbContext                              

    
    {
        public DbSet<Account> Users { get; set; }

        public AccountContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource = AccountDB.db");
        }
    }
}
