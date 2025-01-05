using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Enums;
using TPDDSBackend.Infrastructure.Entities;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public class ContributionRepository : GenericRepository<Contribution>, IContributionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ContributionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Contribution>> GetAllByCollaborador(string collaboradorId)=>
             await _dbContext.Contributions.Where(x => x.CollaboratorId == collaboradorId).ToListAsync();

        public async Task<Contribution?> GetRequestedContribution(string collaboradorId, int fridgeId)
        {
            var food = await _dbContext.FoodDonations.Where(x => x.CollaboratorId == collaboradorId
            && x.Food.Fridge.Id == fridgeId && x.Status == ContributionStatus.Requested).FirstOrDefaultAsync();

            return food is null ? await _dbContext.FoodDeliveries.Where(x => x.CollaboratorId == collaboradorId
            && x.DestinationFridgeId == fridgeId && x.Status == ContributionStatus.Requested).FirstOrDefaultAsync() 
            : food;
        }

        public  async Task<List<FridgeFoodStatsDto>> GetTotalFoodsInOutByFridge(DateTime from, DateTime to)
        {
            var stats = await _dbContext.Fridge
               .Select(fridge => new FridgeFoodStatsDto
               {
                   FridgeId = fridge.Id,
                   FridgeName = fridge.Name,
                   FoodsPutIn = _dbContext.FoodDonations
                       .Where(fd => fd.FridgeId == fridge.Id && fd.Status == ContributionStatus.Done && fd.CreatedAt >= from && fd.CreatedAt <= to)
                       .Count() +
                       _dbContext.FoodDeliveries
                       .Where(fd => fd.DestinationFridgeId == fridge.Id && fd.Status == ContributionStatus.Done && fd.CreatedAt >= from && fd.CreatedAt <= to)
                       .Sum(fd => fd.Amount),

                   FoodsTakenOut = _dbContext.FoodDeliveries
                       .Where(fd => fd.OriginFridgeId == fridge.Id && fd.Status == ContributionStatus.Done && fd.CreatedAt >= from && fd.CreatedAt <= to)
                       .Sum(fd => fd.Amount) +
                       _dbContext.FoodDonations
                       .Where(fd => fd.FridgeId == fridge.Id && fd.DoneeId != null && fd.Status == ContributionStatus.Done && fd.CreatedAt >= from && fd.CreatedAt <= to)
                       .Count()
               })
               .ToListAsync();

            return stats;
        }

        public async Task<int> GetTotalFoodsPutInFridge(int fridgeId, DateTime from, DateTime to)
        {
            var foodDonationsCount = await _dbContext.FoodDonations
                 .Where(fd => fd.FridgeId == fridgeId && fd.Status == ContributionStatus.Done && fd.CreatedAt >= from && fd.CreatedAt <= to)
                 .CountAsync();

            var foodDeliveriesCount = await _dbContext.FoodDeliveries
                .Where(fd => fd.DestinationFridgeId == fridgeId && fd.Status == ContributionStatus.Done && fd.CreatedAt >= from && fd.CreatedAt <= to)
                .SumAsync(fd => fd.Amount);

            return foodDonationsCount + foodDeliveriesCount;
        }

        public async Task<int> GetTotalFoodsTakeOutOfFridge(int fridgeId, DateTime from, DateTime to)
        {
            var foodDeliveriesCount = await _dbContext.FoodDeliveries
                .Where(fd => fd.OriginFridgeId == fridgeId && fd.Status == ContributionStatus.Done && fd.CreatedAt >= from && fd.CreatedAt <= to)
                .SumAsync(fd => fd.Amount);

            var foodDonationsCount = await _dbContext.FoodDonations
                .Where(fd => fd.FridgeId == fridgeId && fd.DoneeId != null && fd.Status == ContributionStatus.Done && fd.CreatedAt >= from && fd.CreatedAt <= to)
                .CountAsync();

            return foodDonationsCount + foodDeliveriesCount;
        }
        
    }
}
