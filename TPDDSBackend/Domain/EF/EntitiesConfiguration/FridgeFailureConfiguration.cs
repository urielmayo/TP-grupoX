using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.Entities;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class FridgeFailureConfiguration : IEntityTypeConfiguration<FridgeFailure>
    {
        public void Configure(EntityTypeBuilder<FridgeFailure> builder)
        {
            builder.HasOne(x => x.Collaborator)
               .WithOne();
        }
    }

}
