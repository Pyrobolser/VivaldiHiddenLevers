using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VivaldiHiddenLevers.Application.Apis.HLEntities;
using VivaldiHiddenLevers.Application.Interfaces;
using VivaldiHiddenLevers.Application.Interfaces.Mapping;
using VivaldiHiddenLevers.Domain.Entities;

namespace VivaldiHiddenLevers.Application.StressTests.Commands
{
    public class CreateStressTestForClient : IRequest, IMapTo<StressTest>
    {
        public int ClientId { get; set; }

        public ICollection<HLPosition> Positions { get; set; }

        public class Handler : IRequestHandler<CreateStressTestForClient, Unit>
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

            public async Task<Unit> Handle(CreateStressTestForClient request, CancellationToken cancellationToken)
            {
                var stressTestInput = _mapper.Map<HLInput>(request);

                var entity = await _hlClient.CreateStressTest(stressTestInput);

                entity.ClientId = request.ClientId;

                _context.StressTests.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
