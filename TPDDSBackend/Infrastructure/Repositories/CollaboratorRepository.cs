using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public class CollaboratorRepository : GenericRepository<Collaborator>
    {
        public CollaboratorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
