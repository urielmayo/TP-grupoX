using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Entities;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class FridgeSubscriptionConfiguration : IEntityTypeConfiguration<FridgeSubscription>
    {
        public void Configure(EntityTypeBuilder<FridgeSubscription> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasOne(x => x.Fridge)
               .WithMany()
               .HasForeignKey(x => x.FridgeId);

            builder.HasOne(x => x.CommunicationMediaDesired)
                .WithMany()
                .HasForeignKey(x => x.CommunicationMediaId);

            builder.HasOne(x => x.Collaborator)
                .WithMany()
                .HasForeignKey(x => x.CollaboratorId);

        }
    }

}
