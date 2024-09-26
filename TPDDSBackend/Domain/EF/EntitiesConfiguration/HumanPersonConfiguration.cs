using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.EF.EntitiesConfiguration
{
    public class HumanPersonConfiguration : IEntityTypeConfiguration<HumanPerson>
    {
        public void Configure(EntityTypeBuilder<HumanPerson> builder)
        {

        }
    }
}
