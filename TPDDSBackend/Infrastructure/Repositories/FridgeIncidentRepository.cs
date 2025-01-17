using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Entities;

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

        public async Task<List<FridgeIncidentCountDto>> GetTotalIncidentsByFridge(DateTime from, DateTime to)=>
            await _dbContext.Fridge
                    .Select(fridge => new FridgeIncidentCountDto
                    {
                        FridgeId = fridge.Id,
                        FridgeName = fridge.Name,
                        TotalIncidents = _dbContext.FridgeIncidents
                            .Where(incident => incident.FridgeId == fridge.Id && incident.CreatedAt >= from && incident.CreatedAt <= to)
                            .Count()
                    })
                    .ToListAsync();

        public async Task<List<FridgeIncident>> GetActiveIncidents()=>
            await _dbContext.FridgeIncidents
                .Include(incident => incident.Fridge) 
                .Where(incident => !incident.Fridge.Active)
                .ToListAsync();

    }
}
