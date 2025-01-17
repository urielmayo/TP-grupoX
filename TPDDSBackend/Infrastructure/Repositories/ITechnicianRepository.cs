using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public interface ITechnicianRepository
    {
        Task<Technician?> GetByNameAndWorkerNumber(string name, string workerNumber);
    }
}
