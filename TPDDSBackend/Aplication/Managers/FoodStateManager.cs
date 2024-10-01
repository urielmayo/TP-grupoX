using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Managers
{
    public class FoodStateManager : BaseManager<FoodState>, IManager<FoodState>
    {
        public FoodStateManager(ApplicationDbContext dbContext) : base (dbContext)
        {}

        public async Task<FoodState> FindByIdAsync(int Id)
        {
            return await _dbContext.FoodState.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }
    }
}
