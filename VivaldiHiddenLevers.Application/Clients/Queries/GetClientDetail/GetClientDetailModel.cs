using VivaldiHiddenLevers.Application.Interfaces.Mapping;
using VivaldiHiddenLevers.Domain.Entities;

namespace VivaldiHiddenLevers.Application.Clients.Queries.GetClientDetail
{
    public class ClientDetailModel : IMapFrom<Client>
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string AdvisorEmail { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
