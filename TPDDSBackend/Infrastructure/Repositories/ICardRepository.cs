using TPDDSBackend.Domain.Entities;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public interface ICardRepository
    {
        Task<Card?> GetCollaboratorCard(string collaboratorId);
        Task<int> GetNumberOfOpeningsForCurrentDay(int cardId);
        Task<Card?> GetPersonCard(int personId);
    }
}
