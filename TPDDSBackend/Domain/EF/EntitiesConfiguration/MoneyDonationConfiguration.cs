using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Enums;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class MoneyDonationConfiguration : IEntityTypeConfiguration<MoneyDonation>
    {
        public void Configure(EntityTypeBuilder<MoneyDonation> builder)
        {          
            builder.Property(c => c.Frequency)
                .HasConversion<string>(); 
        }
    }
}
