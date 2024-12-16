using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entities;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public class FridgeIncidentRepository : GenericRepository<FridgeIncident>, IFridgeIncidentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public FridgeIncidentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FridgeIncident>> GetAllByFridge(int fridgeId) 
        {
            return await _dbContext.FridgeIncidents.Where(x => x.FridgeId == fridgeId).ToListAsync();
        }
    }
}
