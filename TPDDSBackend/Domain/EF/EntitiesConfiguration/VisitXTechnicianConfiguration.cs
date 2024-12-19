using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class VisitXTechnicianConfiguration : IEntityTypeConfiguration<VisitXTechnician>
    {
        public void Configure(EntityTypeBuilder<VisitXTechnician> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(x => x.TechnicianVisit)
              .WithMany()
              .HasForeignKey(p => p.TechnicianVisitId);

            builder.HasOne(x => x.Technician)
              .WithMany()
              .HasForeignKey(p => p.TechnicianId);
        }
    }
}
