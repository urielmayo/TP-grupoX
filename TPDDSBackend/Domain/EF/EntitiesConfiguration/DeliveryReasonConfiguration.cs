using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class DeliveryReasonConfiguration : IEntityTypeConfiguration<DeliveryReason>
    {
        public void Configure(EntityTypeBuilder<DeliveryReason> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
