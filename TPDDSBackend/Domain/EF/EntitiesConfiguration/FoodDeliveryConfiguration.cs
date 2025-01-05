using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Enums;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class FoodDeliveryConfiguration : IEntityTypeConfiguration<FoodDelivery>
    {
        public void Configure(EntityTypeBuilder<FoodDelivery> builder)
        {
            builder.HasOne(x => x.OriginFridge)
               .WithMany()
               .HasForeignKey(p => p.OriginFridgeId);

            builder.HasOne(x => x.DestinationFridge)
               .WithMany()
               .HasForeignKey(p => p.DestinationFridgeId);

            builder.HasOne(x => x.DeliveryReason)
               .WithMany()
               .HasForeignKey(p => p.DeliveryReasonId);

            builder.Property(x => x.Status)
            .HasConversion<string>()
            .HasDefaultValue(ContributionStatus.Done);
        }
    }
}
