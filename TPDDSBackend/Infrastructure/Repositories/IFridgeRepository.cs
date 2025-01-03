using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public interface IFridgeRepository
    {
        Task<int> GetTotalFoodAvailable(int fridgeId);

        Task<Fridge?> GetById(int id);

        Task<List<Food>> GetFoodsByFridge(int fridgeId);

        Task<List<FridgeOpening>> GetOpeningsByFridge(int fridgeId);
    }
}
