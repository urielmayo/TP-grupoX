using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class FoodXDeliveryConfiguration : IEntityTypeConfiguration<FoodXDelivery>
    {
        public void Configure(EntityTypeBuilder<FoodXDelivery> builder)
        {
            builder.HasKey(fd => new { fd.FoodId, fd.DeliveryId });

            builder.HasOne(fd => fd.Delivery)
                .WithMany()
                .HasForeignKey(fd => fd.DeliveryId);

            builder.HasOne(fd => fd.Food)
                .WithMany()
                .HasForeignKey(fd => fd.FoodId);
        }
    }
}
