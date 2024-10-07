using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public class FoodRepository : GenericRepository<Food>, IGenericRepository<Food>
    {
        public FoodRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
