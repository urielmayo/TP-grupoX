using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class FridgeOwnerConfiguration : IEntityTypeConfiguration<FridgeOwner>
    {
        public void Configure(EntityTypeBuilder<FridgeOwner> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasOne(x => x.Fridge)
               .WithMany()
               .HasForeignKey(p => p.FridgeId);
        }
    }
}
