using System.Threading.Tasks;
using VivaldiHiddenLevers.ApiHiddenLevers.Entities.Output;

namespace VivaldiHiddenLevers.ApiHiddenLevers
{
    public interface IHiddenLeversClient
    {
        Task<HiddenLeversClientOutput> CreateClient(string advisorEmail, string clientName, string clientEmail, string clientPhone, string uniqueClientId);
    }
}
