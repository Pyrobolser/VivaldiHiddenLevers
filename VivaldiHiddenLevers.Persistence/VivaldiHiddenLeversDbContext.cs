using Microsoft.EntityFrameworkCore;
using VivaldiHiddenLevers.Application.Interfaces;
using VivaldiHiddenLevers.Domain.Entities;

namespace VivaldiHiddenLevers.Persistence
{
    public class VivaldiHiddenLeversDbContext : DbContext, IVivaldiHiddenLeversDbContext
    {
        public VivaldiHiddenLeversDbContext(DbContextOptions<VivaldiHiddenLeversDbContext> options)
            : base(options)
        { }

        public DbSet<Client> Clients { get; set; }

        public DbSet<RiskProfile> RiskProfiles { get; set; }

        public DbSet<StressTest> StressTests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VivaldiHiddenLeversDbContext).Assembly);
        }
    }
}
