using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;

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

    }
}
