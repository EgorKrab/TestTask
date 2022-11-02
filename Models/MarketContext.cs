using Microsoft.EntityFrameworkCore;

namespace TestTask.Models
{
    public class MarketContext : DbContext 
    {
        public DbSet<Market> Markets { get; set; }
        public MarketContext(DbContextOptions<MarketContext> options)
            : base(options) 
        {
            Database.EnsureCreated();
        }
    }
}
