using Microsoft.EntityFrameworkCore;
using System;
using VivaldiHiddenLevers.Domain.Entities;
using VivaldiHiddenLevers.Persistence;

namespace VivaldiHiddenLevers.Application.Tests.Infrastructure
{
    public class VivaldiHiddenLeversContextFactory
    {
        public static VivaldiHiddenLeversDbContext Create()
        {
            var options = new DbContextOptionsBuilder<VivaldiHiddenLeversDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new VivaldiHiddenLeversDbContext(options);

            context.Clients.AddRange(new[]
            {
                new Client { Id = 1, AdvisorEmail = "jpilson@vivaldicap.com-hl", Email = "francois.blondel@outlook.com", HiddenLeverId=12345, Name="Francois Blondel", Phone="123-456-7890", Url = "http://hiddenleversexampleurl.com" },
                new Client { Id = 2, AdvisorEmail = "jpilson@vivaldicap.com-hl", Email = "john.doe@outlook.com", HiddenLeverId=67890, Name="John Doe", Phone="888-999-0909", Url = "http://hiddenleversexampleurl.com" }
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(VivaldiHiddenLeversDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
