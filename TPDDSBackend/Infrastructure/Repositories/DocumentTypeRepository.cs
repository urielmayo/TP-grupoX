using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public class DocumentTypeRepository : GenericRepository<DocumentType>, IDocumentTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public DocumentTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DocumentType> GetByDescription(string description) => 
            await _dbContext.DocumentTypes.Where(t => t.Description == description.ToUpper()).FirstAsync();
    }
}
