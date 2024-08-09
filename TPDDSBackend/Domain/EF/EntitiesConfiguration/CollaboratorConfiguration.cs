using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class CollaboratorConfiguration : IEntityTypeConfiguration<Collaborator>
    {
        public void Configure(EntityTypeBuilder<Collaborator> builder)
        {
            builder.HasKey(c => c.Id);

            // Configura la relación uno a uno con ContactMediumXPerson
            builder.HasOne(c => c.ContactMediumXPerson)
                   .WithOne(cmp => cmp.Collaborator)
                   .HasForeignKey<ContactMediumXPerson>(cmp => cmp.CollaboratorId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
