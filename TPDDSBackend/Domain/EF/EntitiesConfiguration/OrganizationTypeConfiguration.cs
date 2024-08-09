using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class OrganizationTypeConfiguration : IEntityTypeConfiguration<OrganizationType>
    {
        public void Configure(EntityTypeBuilder<OrganizationType> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
