using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class ContactMediumXPersonConfiguration : IEntityTypeConfiguration<ContactMediumXPerson>
    {
        public void Configure(EntityTypeBuilder<ContactMediumXPerson> builder)
        {
            // Configura la relación uno a uno con Collaborator
            builder.HasOne(cmp => cmp.Collaborator)
                   .WithOne(c => c.ContactMediumXPerson)
                   .HasForeignKey<ContactMediumXPerson>(cmp => cmp.CollaboratorId) // Usa CollaboratorId como clave foránea
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
