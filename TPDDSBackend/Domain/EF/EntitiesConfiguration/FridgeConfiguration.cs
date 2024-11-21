using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class FridgeConfiguration : IEntityTypeConfiguration<Fridge>
    {
        public void Configure(EntityTypeBuilder<Fridge> builder)
        {
            builder.HasKey(f => f.Id); 
            
            builder.Property(f => f.Active)
                .HasDefaultValue(true);

            builder.Property(f => f.FridgeModelId)
                .HasDefaultValue(1);

            builder.HasOne(x => x.Model)
               .WithMany()
               .HasForeignKey(p => p.FridgeModelId);
        }
    }

}
