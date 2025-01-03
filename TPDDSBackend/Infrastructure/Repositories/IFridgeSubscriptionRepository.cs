using TPDDSBackend.Domain.Entities;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public interface IFridgeSubscriptionRepository
    {
        Task<FridgeSubscription?> GetByFridgeAndCollaboratorAsync(int fridgeId, string collaboratorId);
    }
}
