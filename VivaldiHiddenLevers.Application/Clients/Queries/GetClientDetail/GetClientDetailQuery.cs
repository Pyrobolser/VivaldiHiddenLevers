using MediatR;

namespace VivaldiHiddenLevers.Application.Clients.Queries.GetClientDetail
{
    public class GetClientDetailQuery : IRequest<ClientDetailModel>
    {
        public int Id { get; set; }
    }
}
