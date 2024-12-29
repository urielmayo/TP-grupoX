using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Entities;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class CommunicationMediaConfiguration : IEntityTypeConfiguration<CommunicationMedia>
    {
        public void Configure(EntityTypeBuilder<CommunicationMedia> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(c => c.Name)
                .HasConversion<string>();
        }
    }

}
