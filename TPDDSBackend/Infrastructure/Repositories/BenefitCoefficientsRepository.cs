using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public class BenefitCoefficientsRepository : GenericRepository<BenefitCoefficients>, IBenefitCoefficientsRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public BenefitCoefficientsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BenefitCoefficients?> GetValidCoeficients()
        {
           var now = DateTime.UtcNow;
            return await _dbContext.BenefitCoefficients.Where(x => x.ValidFrom < now &&
            now < x.ValidUntil).FirstOrDefaultAsync();
        }
        public async Task<BenefitCoefficients> Insert(BenefitCoefficients coefficients)
        {
            var inserted = await _dbContext.BenefitCoefficients.AddAsync(coefficients);
            await _dbContext.SaveChangesAsync();
            return inserted.Entity;
        }
    }
}
