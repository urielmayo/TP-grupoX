using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class TechnicianVisitConfiguration : IEntityTypeConfiguration<TechnicianVisit>
    {
        public void Configure(EntityTypeBuilder<TechnicianVisit> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(x => x.Fridge)
              .WithMany()
              .HasForeignKey(p => p.FridgeId);

            builder.HasOne(x => x.Technician)
              .WithMany()
              .HasForeignKey(p => p.TechnicianId);

            builder.Property(t => t.FridgeRepaired)
                .HasDefaultValue(false);

            builder.Property(t => t.UuidToComplete)
                .IsRequired();

            builder.HasIndex(e => e.UuidToComplete)
               .IsUnique();
        }
    }
}
