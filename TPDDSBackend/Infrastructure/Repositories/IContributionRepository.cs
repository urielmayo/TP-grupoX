using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public interface IContributionRepository
    {
        Task<List<Contribution>> GetAllByCollaborador(string collaboradorId);
    }
}
