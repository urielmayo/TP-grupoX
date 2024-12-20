using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class FoodDonationConfiguration : IEntityTypeConfiguration<FoodDonation>
    {
        public void Configure(EntityTypeBuilder<FoodDonation> builder)
        {
            builder.HasOne(x => x.Food)
            .WithMany()
            .HasForeignKey(x => x.FoodId);

            builder.HasOne(x => x.Donee)
            .WithMany()
            .HasForeignKey(x => x.DoneeId);

            builder.HasOne(x => x.Fridge)
            .WithMany()
            .HasForeignKey(x => x.FridgeId);

            builder.Property(x => x.Status)
            .HasConversion<string>();
        }
    }
}
