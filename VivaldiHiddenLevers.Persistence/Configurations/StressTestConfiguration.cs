using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;
using VivaldiHiddenLevers.Domain.Entities;

namespace VivaldiHiddenLevers.Persistence.Configurations
{
    public class StressTestConfiguration : IEntityTypeConfiguration<StressTest>
    {
        public void Configure(EntityTypeBuilder<StressTest> builder)
        {
            builder.HasKey(st => st.Id);

            builder.HasOne(st => st.Client)
                .WithMany(c => c.StressTests)
                .HasForeignKey(st => st.ClientId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_StressTest_Client");

            builder.Property(st => st.Results)
                .IsRequired()
                .HasConversion(
                    r => JsonConvert.SerializeObject(r, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    r => JsonConvert.DeserializeObject<ICollection<StressTestResult>>(r, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }
                ));
        }
    }
}
