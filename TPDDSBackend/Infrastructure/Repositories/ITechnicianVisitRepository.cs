using TPDDSBackend.Domain.Entities;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public interface ITechnicianVisitRepository
    {
        Task<TechnicianVisit?> GetByUuid(Guid uuid);

        void Update(TechnicianVisit technicianVisit);
    }
}
