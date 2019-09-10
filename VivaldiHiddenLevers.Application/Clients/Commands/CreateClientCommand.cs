using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VivaldiHiddenLevers.Application.Apis.HLEntities;
using VivaldiHiddenLevers.Application.Infrastructure.AutoMapper;
using VivaldiHiddenLevers.Application.Interfaces;
using VivaldiHiddenLevers.Application.Interfaces.Mapping;
using VivaldiHiddenLevers.Domain.Entities;

namespace VivaldiHiddenLevers.Application.Clients.Commands
{
    public class CreateClientCommand : IRequest, IMapTo<Client>
    {
        public string Id { get; set; }

        public string AdvisorEmail { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public class Handler : IRequestHandler<CreateClientCommand, Unit>
        {
            private readonly IVivaldiHiddenLeversClient _hlClient;
            private readonly IVivaldiHiddenLeversDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IVivaldiHiddenLeversDbContext context, IMapper mapper, IVivaldiHiddenLeversClient hlClient)
            {
                _hlClient = hlClient;
                _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(CreateClientCommand request, CancellationToken cancellationToken)
            {
                HLClientResult hlClientResult = await _hlClient.CreateClient(request.AdvisorEmail, request.Name, request.Email, request.Phone, request.Id);

                var entity = _mapper.MergeInto<Client>(request, hlClientResult);

                _context.Clients.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
