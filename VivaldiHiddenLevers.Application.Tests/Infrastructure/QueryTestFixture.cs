using AutoMapper;
using System;
using VivaldiHiddenLevers.Persistence;
using Xunit;

namespace VivaldiHiddenLevers.Application.Tests.Infrastructure
{
    public class QueryTestFixture : IDisposable
    {
        public VivaldiHiddenLeversDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Context = VivaldiHiddenLeversContextFactory.Create();
            Mapper = AutoMapperFactory.Create();
        }

        public void Dispose()
        {
            VivaldiHiddenLeversContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
