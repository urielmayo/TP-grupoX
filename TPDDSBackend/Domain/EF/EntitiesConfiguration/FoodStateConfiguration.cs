using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class FoodStateConfiguration : IEntityTypeConfiguration<FoodState>
    {
        public void Configure(EntityTypeBuilder<FoodState> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
