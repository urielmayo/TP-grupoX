using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entities;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class BenefitConfiguration : IEntityTypeConfiguration<Benefit>
    {
        public void Configure(EntityTypeBuilder<Benefit> builder)
        {
            builder.HasOne(x => x.Collaborator)
             .WithMany()
             .HasForeignKey(x => x.CollaboratorId);

            builder.Property(x => x.Image)
                .HasColumnType("BYTEA");
        }
    }
}
