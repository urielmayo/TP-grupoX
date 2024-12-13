using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Entities;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class FridgeAlertConfiguration : IEntityTypeConfiguration<FridgeAlert>
    {
        public void Configure(EntityTypeBuilder<FridgeAlert> builder)
        {

            builder.Property(a => a.Type)
                .HasConversion<string>();
        }
    }

}
