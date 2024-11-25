using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public interface IDocumentTypeRepository
    {
        Task<DocumentType> GetByDescription(string description);
    }
}
