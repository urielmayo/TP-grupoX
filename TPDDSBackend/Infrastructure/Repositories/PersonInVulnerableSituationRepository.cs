using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public class PersonInVulnerableSituationRepository : GenericRepository<PersonInVulnerableSituation>
    {
        public PersonInVulnerableSituationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
