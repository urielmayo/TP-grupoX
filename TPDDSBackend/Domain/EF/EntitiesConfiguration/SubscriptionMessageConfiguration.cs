using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Entities;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class SubscriptionMessageConfiguration : IEntityTypeConfiguration<SubscriptionMessage>
    {
        public void Configure(EntityTypeBuilder<SubscriptionMessage> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasOne(x => x.CommunicationMedia)
                .WithMany()
                .HasForeignKey(x => x.CommunicationMediaId);

        }
    }

}
