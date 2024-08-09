using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class LegalPersonConfiguration : IEntityTypeConfiguration<LegalPerson>
    {
        public void Configure(EntityTypeBuilder<LegalPerson> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(x => x.Category)
            .WithMany()
            .HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.Type)
                .WithMany()
                .HasForeignKey(x => x.OrganizationTypeId);
        }
    }
}
