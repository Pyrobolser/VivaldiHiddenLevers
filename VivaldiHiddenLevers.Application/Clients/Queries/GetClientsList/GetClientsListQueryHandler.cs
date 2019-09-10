using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using VivaldiHiddenLevers.Application.Interfaces;

namespace VivaldiHiddenLevers.Application.Clients.Queries.GetClientsList
{
    public class GetClientsListQueryHandler : IRequestHandler<GetClientsListQuery, ClientsListViewModel>
    {
        private readonly IVivaldiHiddenLeversDbContext _context;
        private readonly IMapper _mapper;

        public GetClientsListQueryHandler(IVivaldiHiddenLeversDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ClientsListViewModel> Handle(GetClientsListQuery request, CancellationToken cancellationToken)
        {
            return new ClientsListViewModel
            {
                Clients = await _context.Clients.ProjectTo<ClientLookupModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
