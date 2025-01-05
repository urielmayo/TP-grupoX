using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Infrastructure.Entities;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public interface IFridgeIncidentRepository
    {
        Task<List<FridgeIncident>> GetAllByFridge(int fridgeId);

        Task<List<FridgeIncidentCountDto>> GetTotalIncidentsByFridge(DateTime from, DateTime to);
    }
}
