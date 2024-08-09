using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne<Fridge>()
               .WithMany()
               .HasForeignKey(p => p.FridgeId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
