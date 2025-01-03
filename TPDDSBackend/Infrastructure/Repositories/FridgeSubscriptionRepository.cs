using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entities;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public class FridgeSubscriptionRepository : GenericRepository<FridgeSubscription>, IFridgeSubscriptionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public FridgeSubscriptionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FridgeSubscription?> GetByFridgeAndCollaboratorAsync(int fridgeId, string collaboratorId) =>
            await _dbContext.FridgeSubscriptions.Where(s => s.FridgeId == fridgeId
             && s.CollaboratorId == collaboratorId).FirstOrDefaultAsync();

    }
}