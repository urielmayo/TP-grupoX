using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entities;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class BenefitExchangeConfiguration : IEntityTypeConfiguration<BenefitExchange>
    {
        public void Configure(EntityTypeBuilder<BenefitExchange> builder)
        {
            builder.HasOne(x => x.User)
             .WithMany()
             .HasForeignKey(x => x.UserId);
        }
    }
}
