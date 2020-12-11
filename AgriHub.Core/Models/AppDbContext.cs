using AgriHub.Models;
using Microsoft.EntityFrameworkCore;

namespace AgriHub.Core.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Broiler> Broilers { get; set; }
        public DbSet<BroilerTrans> BroilerTrans { get; set; }
        public DbSet<Brooder> Brooders { get; set; }
        public DbSet<PenHouse> PenHouses { get; set; }

    }
}
