using TPDDSBackend.Domain.Entities;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public interface IFridgeIncidentRepository
    {
        Task<List<FridgeIncident>> GetAllByFridge(int fridgeId);
    }
}
