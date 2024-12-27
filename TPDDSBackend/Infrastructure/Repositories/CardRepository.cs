using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public class CardRepository : GenericRepository<Card>, ICardRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CardRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Card?> GetCollaboratorCard(string collaboratorId)
        {
          var collaboratorCard =  await _dbContext.CollaboratorCards.FirstOrDefaultAsync(c => c.CollaboratorId == collaboratorId);
            return collaboratorCard?.Card;
        }

        public async Task<Card?> GetPersonCard(int personId)
        {
            var personCard = await _dbContext.PersonCards.FirstOrDefaultAsync(p => p.PersonInVulnerableSituationId == personId);
            return personCard?.Card;
        }

        public async Task<int> GetNumberOfOpeningsForCurrentDay(int cardId)
        {
            var today = DateTime.UtcNow.Date;

            int count = await _dbContext.FridgeOpenings
                .Where(o => o.CardId == cardId && o.CreatedAt.Date.Equals(today))
                .CountAsync();

            return count;
        }
    }
}
