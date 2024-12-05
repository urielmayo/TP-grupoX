using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entities;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class BenefitCoefficientsConfiguration : IEntityTypeConfiguration<BenefitCoefficients>
    {
        public void Configure(EntityTypeBuilder<BenefitCoefficients> builder)
        {
        }
    }
}
