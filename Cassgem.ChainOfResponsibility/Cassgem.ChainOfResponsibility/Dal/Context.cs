using Microsoft.EntityFrameworkCore;

namespace Cassgem.ChainOfResponsibility.Dal
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-SUUA4BNC\\MSSQL;initial Catalog=CasgemDbCoR;integrated Security=true");
        }
        public DbSet<CustomerProcess> CustomerProcesss { get; set; }
    }
}

