using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VivaldiHiddenLevers.Application.Apis.HLEntities;
using VivaldiHiddenLevers.Application.Interfaces;
using VivaldiHiddenLevers.Application.Interfaces.Mapping;
using VivaldiHiddenLevers.Domain.Entities;

namespace VivaldiHiddenLevers.Application.RiskProfiles.Commands
{
    public class CreateRiskProfileForClient : IRequest, IMapTo<RiskProfile>
    {
        public int ClientId { get; set; }

        public ICollection<HLPosition> Positions { get; set; }

        public class Handler : IRequestHandler<CreateRiskProfileForClient, Unit>
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

            public async Task<Unit> Handle(CreateRiskProfileForClient request, CancellationToken cancellationToken)
            {
                var riskProfileInput = _mapper.Map<HLInput>(request);

                var entity = await _hlClient.CreateRiskProfile(riskProfileInput);

                entity.ClientId = request.ClientId;

                _context.RiskProfiles.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
