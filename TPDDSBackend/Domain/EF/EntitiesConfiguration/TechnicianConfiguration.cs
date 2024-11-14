using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class TechnicianConfiguration : IEntityTypeConfiguration<Technician>
    {
        public void Configure(EntityTypeBuilder<Technician> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(x => x.DocumentType)
               .WithMany()
               .HasForeignKey(t => t.DocumentTypeId);

            builder.HasOne(x => x.Neighborhood)
                .WithMany()
                .HasForeignKey(t => t.NeighborhoodId);

            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Surname).IsRequired();
            builder.Property(c => c.IdNumber).IsRequired();
            builder.Property(c => c.WorkerIdentificationNumber).IsRequired();
        }
    }
}
