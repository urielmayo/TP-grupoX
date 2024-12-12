using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public class BenefitExchangesRepository : GenericRepository<BenefitExchange>, IBenefitExchangesRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public BenefitExchangesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<decimal> GetTotalAmountSpent(string collaboratorId) =>
             await _dbContext.BenefitExchanges
             .Where(be => be.UserId == collaboratorId) 
             .SumAsync(be => be.Benefit.RequiredPoints); 
        
    }
}
