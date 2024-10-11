using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public class FoodStateRepository : GenericRepository<FoodState>, IGenericRepository<FoodState>
    {
        public FoodStateRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
