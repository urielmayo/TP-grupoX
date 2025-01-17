using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entities;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public class TechnicianVisitRepository : GenericRepository<TechnicianVisit>, ITechnicianVisitRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public TechnicianVisitRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TechnicianVisit>?> GetByTechnicianName(string name)=>
             await _dbContext.TechnicianVisits.Where(t => t.Technician.Name == name
            && t.Completed == false).ToListAsync();
        

        public async Task<TechnicianVisit?> GetByUuid(Guid uuid)=>      
            await _dbContext.TechnicianVisits.FirstOrDefaultAsync(e => e.UuidToComplete == uuid);
        
    }
}
