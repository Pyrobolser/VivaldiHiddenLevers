using System;
using VivaldiHiddenLevers.Persistence;

namespace VivaldiHiddenLevers.Application.Tests.Infrastructure
{
    public class CommandTestBase : IDisposable
    {
        protected readonly VivaldiHiddenLeversDbContext _context;

        public CommandTestBase()
        {
            _context = VivaldiHiddenLeversContextFactory.Create();
        }

        public void Dispose()
        {
            VivaldiHiddenLeversContextFactory.Destroy(_context);
        }
    }
}
