using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class FoodDeliveryConfiguration : IEntityTypeConfiguration<FoodDelivery>
    {
        public void Configure(EntityTypeBuilder<FoodDelivery> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(x => x.OriginFridge)
               .WithMany()
               .HasForeignKey(p => p.OriginFridgeId);

            builder.HasOne(x => x.DestinationFridge)
               .WithMany()
               .HasForeignKey(p => p.DestinationFridgeId);

            builder.HasOne(x => x.DeliveryReason)
               .WithMany()
               .HasForeignKey(p => p.DeliveryReasonId);
        }
    }
}
