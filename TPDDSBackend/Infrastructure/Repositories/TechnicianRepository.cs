using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public class TechnicianRepository : GenericRepository<Technician>, IGenericRepository<Technician>
    {
        public TechnicianRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
