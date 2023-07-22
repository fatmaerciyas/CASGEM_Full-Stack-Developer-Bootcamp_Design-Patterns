using Microsoft.EntityFrameworkCore;

namespace CQRS.Dal
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-SUUA4BNC\\MSSQL;initial catalog=CasgemCQRSDb;integrated Security=true");
        }

        public DbSet<Product> Products { get; set; }
    }
}
