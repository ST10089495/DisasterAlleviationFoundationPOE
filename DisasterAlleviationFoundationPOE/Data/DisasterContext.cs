using Microsoft.EntityFrameworkCore;
using DisasterAlleviationFoundationPOE.Models;

namespace DisasterAlleviationFoundationPOE.Data
{
    public class DisasterContext : DbContext
    {
        public DisasterContext(DbContextOptions<DisasterContext> options) 
        : base(options)
        { 
        }
        public DbSet<NewDonations> NewDonations { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<Disaster> Disasters { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Goods> Goods { get; set; }
    }
}
