using Microsoft.EntityFrameworkCore;

namespace RestaurangGuiden.Models
{
    public class AccountContext : DbContext                              //Den har klasse hanterar databasen för användarkonton.

    
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
