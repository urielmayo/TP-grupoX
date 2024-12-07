using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entities;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class CollaboratorCardConfiguration : IEntityTypeConfiguration<CollaboratorCard>
    {
        public void Configure(EntityTypeBuilder<CollaboratorCard> builder)
        {
            builder.HasKey(x=> x.CardId);

            builder.HasOne(x => x.Card)
               .WithOne();

            builder.HasOne(x => x.Collaborator)
                .WithOne();
        }
    }
}
