using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class PersonInVulnerableSituationConfiguration : IEntityTypeConfiguration<PersonInVulnerableSituation>
    {
        public void Configure(EntityTypeBuilder<PersonInVulnerableSituation> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(x => x.DocumentType)
               .WithMany()
               .HasForeignKey(p => p.DocumentTypeId);
        }
    }
}
