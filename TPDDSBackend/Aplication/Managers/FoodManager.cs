using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Managers
{
    public class FoodManager : BaseManager<Food>, IManager<Food>
    {
        public FoodManager(ApplicationDbContext dbContext) : base (dbContext)
        {}

        public async Task<Food> FindByIdAsync(int Id)
        {
            return await _dbContext.Food.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }
    }
}
