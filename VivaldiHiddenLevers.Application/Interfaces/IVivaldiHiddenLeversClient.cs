using VivaldiHiddenLevers.Domain.Entities;
using System.Threading.Tasks;
using VivaldiHiddenLevers.Application.Apis.HLEntities;

namespace VivaldiHiddenLevers.Application.Interfaces
{
    public interface IVivaldiHiddenLeversClient
    {
        Task<RiskProfile> CreateRiskProfile(HLInput positions);

        Task<StressTest> CreateStressTest(HLInput positions);

        Task<HLClientResult> CreateClient(string advisorEmail, string clientName, string clientEmail, string clientPhone, string uniqueClientId);
    }
}
