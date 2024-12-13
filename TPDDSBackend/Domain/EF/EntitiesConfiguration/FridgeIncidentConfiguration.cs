using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Entities;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class FridgeIncidentConfiguration : IEntityTypeConfiguration<FridgeIncident>
    {
        public void Configure(EntityTypeBuilder<FridgeIncident> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasOne(x => x.Fridge)
               .WithOne();
        }
    }

}
