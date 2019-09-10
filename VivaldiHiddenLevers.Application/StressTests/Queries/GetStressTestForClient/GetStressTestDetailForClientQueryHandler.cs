using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VivaldiHiddenLevers.Application.Exceptions;
using VivaldiHiddenLevers.Application.Interfaces;
using VivaldiHiddenLevers.Domain.Entities;

namespace VivaldiHiddenLevers.Application.StressTests.Queries.GetStressTestForClient
{
    public class GetStressTestDetailForClientQueryHandler : IRequestHandler<GetStressTestDetailForClientQuery, StressTestDetailModel>
    {
        private readonly IVivaldiHiddenLeversDbContext _context;
        private readonly IMapper _mapper;

        public GetStressTestDetailForClientQueryHandler(IVivaldiHiddenLeversDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StressTestDetailModel> Handle(GetStressTestDetailForClientQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.StressTests
                .FirstOrDefaultAsync(st => st.ClientId == request.ClientId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(StressTest), request.ClientId);
            }

            return _mapper.Map<StressTestDetailModel>(entity);
        }
    }
}
