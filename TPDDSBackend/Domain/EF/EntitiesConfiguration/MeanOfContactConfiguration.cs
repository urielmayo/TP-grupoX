using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class MeanOfContactConfiguration : IEntityTypeConfiguration<MeanOfContact>
    {
        public void Configure(EntityTypeBuilder<MeanOfContact> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(cmp => cmp.Type)
                .WithMany()
                .HasForeignKey(cmp => cmp.ContactMediaTypeId);

            builder.HasOne(cmp => cmp.Collaborator)
                   .WithMany(c => c.MeansOfContact)
                   .HasForeignKey(cmp => cmp.CollaboratorId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
