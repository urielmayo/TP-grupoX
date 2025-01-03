using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Constans;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public class FridgeRepository : GenericRepository<Fridge>, IGenericRepository<Fridge>, IFridgeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public FridgeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GetTotalFoodAvailable(int fridgeId) 
        {
           return await _dbContext.Fridge
             .Where(f => f.Id == fridgeId)
             .Select(f => new
             {
                 FridgeCapacity = f.MaxFoodCapacity, 
                 AvailableFoodCount = _dbContext.Food 
                     .Count(food => food.FridgeId == fridgeId
                                 && food.State.Description == ServiceConstans.StateFoodAvailable)
             })
             .Select(data => data.FridgeCapacity - data.AvailableFoodCount)
             .FirstOrDefaultAsync();
        }

        public async Task<List<Food>> GetFoodsByFridge(int fridgeId)
        {
            return await _dbContext.Food.
                Where(f => f.FridgeId == fridgeId)
                .ToListAsync();           
        }

        public async Task<List<FridgeOpening>> GetOpeningsByFridge(int fridgeId)
        {
            return await _dbContext.FridgeOpenings 
                .Where(f => f.FridgeId == fridgeId)
                .ToListAsync();
        }
    }
}
