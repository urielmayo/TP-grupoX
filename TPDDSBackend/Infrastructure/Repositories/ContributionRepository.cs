using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Enums;

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
           

    }
}
