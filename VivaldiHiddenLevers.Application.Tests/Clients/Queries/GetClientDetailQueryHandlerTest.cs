using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VivaldiHiddenLevers.Application.Clients.Queries.GetClientDetail;
using VivaldiHiddenLevers.Application.Tests.Infrastructure;
using VivaldiHiddenLevers.Persistence;
using Xunit;

namespace VivaldiHiddenLevers.Application.Tests.Clients.Queries
{
    [Collection("QueryCollection")]
    public class GetClientDetailQueryHandlerTests
    {
        private readonly VivaldiHiddenLeversDbContext _context;
        private readonly IMapper _mapper;

        public GetClientDetailQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetClientDetail()
        {
            var sut = new GetClientDetailQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetClientDetailQuery { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<ClientDetailModel>();
            result.Id.ShouldBe(1);
        }
    }
}
