using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using VivaldiHiddenLevers.Domain.Entities;

namespace VivaldiHiddenLevers.Persistence.Configurations
{
    public class RiskProfileConfiguration : IEntityTypeConfiguration<RiskProfile>
    {
        public void Configure(EntityTypeBuilder<RiskProfile> builder)
        {
            builder.HasKey(rp => rp.Id);

            builder.HasOne(rp => rp.Client)
                .WithMany(c => c.RiskProfiles)
                .HasForeignKey(rp => rp.ClientId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_RiskProfile_Client");

            builder.Property(rp => rp.Result)
                .IsRequired()
                .HasConversion(
                    r => JsonConvert.SerializeObject(r, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    r => JsonConvert.DeserializeObject<RiskProfileResult>(r, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }
                ));
        }
    }
}
