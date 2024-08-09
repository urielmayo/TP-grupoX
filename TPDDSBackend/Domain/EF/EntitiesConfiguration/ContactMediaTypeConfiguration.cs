using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class ContactMediaTypeConfiguration : IEntityTypeConfiguration<ContactMediaType>
    {
        public void Configure(EntityTypeBuilder<ContactMediaType> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
