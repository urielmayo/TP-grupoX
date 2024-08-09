using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class CollaboratorConfiguration : IEntityTypeConfiguration<Collaborator>
    {
        public void Configure(EntityTypeBuilder<Collaborator> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.MeansOfContact)
                   .WithOne(cmp => cmp.Collaborator)
                   .HasForeignKey(cmp => cmp.CollaboratorId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
