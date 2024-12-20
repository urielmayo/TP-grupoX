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

        public async Task<TechnicianVisit?> GetByUuid(Guid uuid)=>      
            await _dbContext.TechnicianVisits.FirstOrDefaultAsync(e => e.UuidToComplete == uuid);
        
    }
}
