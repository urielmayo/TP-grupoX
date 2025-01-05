using TPDDSBackend.Infrastructure.Entities;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public interface ICollaboratorRepository
    {
        Task<List<CollaboratorDonationCountDto>> GetTotalDonatedFoodsByCollaborators(DateTime from, DateTime to);
    }
}
