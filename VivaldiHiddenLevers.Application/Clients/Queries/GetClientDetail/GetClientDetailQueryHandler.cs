using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VivaldiHiddenLevers.Application.Exceptions;
using VivaldiHiddenLevers.Application.Interfaces;
using VivaldiHiddenLevers.Domain.Entities;

namespace VivaldiHiddenLevers.Application.Clients.Queries.GetClientDetail
{
    public class GetClientDetailQueryHandler : IRequestHandler<GetClientDetailQuery, ClientDetailModel>
    {
        private readonly IVivaldiHiddenLeversDbContext _context;
        private readonly IMapper _mapper;

        public GetClientDetailQueryHandler(IVivaldiHiddenLeversDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ClientDetailModel> Handle(GetClientDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Clients
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Client), request.Id);
            }

            return _mapper.Map<ClientDetailModel>(entity);
        }
    }
}
