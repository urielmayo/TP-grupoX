using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public class FridgeRepository : GenericRepository<Fridge>, IGenericRepository<Fridge>
    {
        public FridgeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
