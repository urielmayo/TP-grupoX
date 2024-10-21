using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasOne(x => x.Collaborator)
             .WithMany()
             .HasForeignKey(x => x.CollaboratorId);

            builder.HasOne(x => x.Owner)
             .WithMany()
             .HasForeignKey(x => x.PersonInVulnerableSituationId);
        }
    }
}
