using Microsoft.EntityFrameworkCore;
using System;
using VivaldiHiddenLevers.Persistence;

namespace VivaldiHiddenLevers.Application.Tests
{
    public class TestBase
    {
        public VivaldiHiddenLeversDbContext GetDbContext(bool useSqlLite = false)
        {
            var builder = new DbContextOptionsBuilder<VivaldiHiddenLeversDbContext>();
            if (useSqlLite)
            {
                builder.UseSqlite("DataSource=:memory:", x => { });
            }
            else
            {
                builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            }

            var dbContext = new VivaldiHiddenLeversDbContext(builder.Options);
            if(useSqlLite)
            {
                dbContext.Database.OpenConnection();
            }

            dbContext.Database.EnsureCreated();

            return dbContext;
        }
    }
}
