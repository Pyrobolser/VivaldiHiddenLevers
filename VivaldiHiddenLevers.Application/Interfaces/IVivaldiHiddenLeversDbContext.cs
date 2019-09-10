using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using VivaldiHiddenLevers.Domain.Entities;

namespace VivaldiHiddenLevers.Application.Interfaces
{
    public interface IVivaldiHiddenLeversDbContext
    {
        DbSet<Client> Clients { get; set; }

        DbSet<RiskProfile> RiskProfiles { get; set; }

        DbSet<StressTest> StressTests { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
