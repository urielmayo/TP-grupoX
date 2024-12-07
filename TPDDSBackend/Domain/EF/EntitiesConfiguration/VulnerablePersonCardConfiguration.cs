using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class VulnerablePersonCardConfiguration : IEntityTypeConfiguration<VulnerablePersonCard>
    {
        public void Configure(EntityTypeBuilder<VulnerablePersonCard> builder)
        {
            
            builder.HasOne(x => x.Collaborator)
             .WithMany()
             .HasForeignKey(x => x.CollaboratorId);

            builder.HasOne(x => x.Owner)
             .WithOne();

            builder.HasOne(x => x.Card)
                    .WithOne()
                    .IsRequired(true);
        }
    }
}
