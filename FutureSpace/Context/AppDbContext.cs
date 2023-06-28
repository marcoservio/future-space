using FutureSpace.Models;
using Microsoft.EntityFrameworkCore;

namespace FutureSpace.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<LaunchResult> LaunchResults { get; set; }
        public DbSet<Launch> Launchers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Pad> Pads { get; set; }
        public DbSet<Orbit> Orbits { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Rocket> Rockets { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<LaunchServiceProvider> LaunchServiceProviders { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Program_Launch> Programs { get; set; }
        public DbSet<Agencia> Agencies { get; set; }
    }
}
