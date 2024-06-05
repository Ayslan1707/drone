using DroneMonitoramento.Models;
using Microsoft.EntityFrameworkCore;

namespace DroneMonitoramento.Data
{
    public class DroneContext : DbContext
    {
        public DroneContext(DbContextOptions<DroneContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        public DbSet<Drone> Drones { get; set; }
        public DbSet<OceanWaste> OceanWastes { get; set; }
    }
}
