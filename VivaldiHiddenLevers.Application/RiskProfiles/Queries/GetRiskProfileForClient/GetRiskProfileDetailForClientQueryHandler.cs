using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using VivaldiHiddenLevers.Application.Exceptions;
using VivaldiHiddenLevers.Application.Interfaces;
using VivaldiHiddenLevers.Domain.Entities;

namespace VivaldiHiddenLevers.Application.RiskProfiles.Queries.GetRiskProfileForClient
{
    public class GetRiskProfileDetailForClientQueryHandler : IRequestHandler<GetRiskProfileDetailForClientQuery, RiskProfileDetailModel>
    {
        private readonly IVivaldiHiddenLeversDbContext _context;
        private readonly IMapper _mapper;

        public GetRiskProfileDetailForClientQueryHandler(IVivaldiHiddenLeversDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RiskProfileDetailModel> Handle(GetRiskProfileDetailForClientQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.RiskProfiles
                .FirstOrDefaultAsync(st => st.ClientId == request.ClientId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(StressTest), request.ClientId);
            }

            return _mapper.Map<RiskProfileDetailModel>(entity);
        }
    }
}
