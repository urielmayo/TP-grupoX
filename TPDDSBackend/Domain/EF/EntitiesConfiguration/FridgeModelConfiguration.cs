using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Entities;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class FridgeModelConfiguration : IEntityTypeConfiguration<FridgeModel>
    {
        public void Configure(EntityTypeBuilder<FridgeModel> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasData(new FridgeModel
            {
                Id = 1,
                Name = "DefaultModel",
                MaxTemperature = 10.0f,
                MinTemperature = -5.0f
            });
        }
    }

}
