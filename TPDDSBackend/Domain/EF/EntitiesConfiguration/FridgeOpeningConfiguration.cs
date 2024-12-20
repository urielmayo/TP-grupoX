using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Entities;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class FridgeOpeningConfiguration : IEntityTypeConfiguration<FridgeOpening>
    {
        public void Configure(EntityTypeBuilder<FridgeOpening> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasOne(x => x.Fridge)
               .WithMany()
               .HasForeignKey(x => x.FridgeId);

            builder.HasOne(x => x.Card)
               .WithMany()
               .HasForeignKey(x => x.CardId);

            builder.Property(c => c.OpeningFor)
                .HasConversion<int>();
        }
    }

}
