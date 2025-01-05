using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Enums;
using TPDDSBackend.Infrastructure.Entities;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public class CollaboratorRepository : GenericRepository<Collaborator>, ICollaboratorRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CollaboratorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CollaboratorDonationCountDto>> GetTotalDonatedFoodsByCollaborators(DateTime from, DateTime to)=>
           await _dbContext.HumanPerson
            .Select(collaborator => new CollaboratorDonationCountDto
            {
                CollaboratorId = collaborator.Id,
                CollaboratorName = collaborator.Name,
                TotalDonations = _dbContext.FoodDonations
                    .Where(fd => fd.CollaboratorId == collaborator.Id &&
                                 fd.Status == ContributionStatus.Done &&
                                 fd.CreatedAt >= from &&
                                 fd.CreatedAt <= to)
                    .Count()
            })
            .ToListAsync();

    }
}
