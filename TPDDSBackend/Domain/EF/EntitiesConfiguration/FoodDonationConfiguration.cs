using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class FoodDonationConfiguration : IEntityTypeConfiguration<FoodDonation>
    {
        public void Configure(EntityTypeBuilder<FoodDonation> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(x => x.Food)
            .WithMany()
            .HasForeignKey(x => x.FoodId);
        }
    }
}
