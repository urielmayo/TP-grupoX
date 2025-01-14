using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public class TechnicianRepository : GenericRepository<Technician>, IGenericRepository<Technician>, ITechnicianRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public TechnicianRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Technician?> GetByNameAndWorkerNumber(string name, string workerNumber)=>
            await _dbContext.Technicians.FirstOrDefaultAsync(t => t.IdNumber == workerNumber && t.Name == name);
        
    }
}
