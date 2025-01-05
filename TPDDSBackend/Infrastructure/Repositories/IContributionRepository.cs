using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Entities;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public interface IContributionRepository
    {
        Task<List<Contribution>> GetAllByCollaborador(string collaboradorId);

        Task<Contribution?> GetRequestedContribution(string collaboradorId, int fridgeId);

        Task<int> GetTotalFoodsPutInFridge(int fridgeId, DateTime from, DateTime to);

        Task<int> GetTotalFoodsTakeOutOfFridge(int fridgeId, DateTime from, DateTime to);

        Task<List<FridgeFoodStatsDto>> GetTotalFoodsInOutByFridge(DateTime from, DateTime to);

    }
}
