using Microsoft.EntityFrameworkCore;

namespace EventEase.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=HARRIS-LAPTOP\\SQLEXPRESS;Database=EventEaseLocal;Trusted_Connection=true;TrustServerCertificate=true;");
        }

    }

}
