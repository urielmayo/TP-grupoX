using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Enums;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public class CommunicationMediaRepository : GenericRepository<DocumentType>, ICommunicationMediaRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CommunicationMediaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CommunicationMedia> GetByName(CommunicationMediaName name)=>       
            await _dbContext.CommunicationMedias.FirstAsync(c => c.Name == name);
        
    }
}
