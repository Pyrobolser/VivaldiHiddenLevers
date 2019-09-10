using VivaldiHiddenLevers.Application.Interfaces.Mapping;
using VivaldiHiddenLevers.Domain.Entities;

namespace VivaldiHiddenLevers.Application.Clients.Queries.GetClientsList
{
    public class ClientLookupModel : IMapFrom<Client>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
