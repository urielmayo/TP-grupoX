using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Enums;

namespace TPDDSBackend.Aplication.Services.Strategies
{
    public interface IFridgeOpeningService
    {
        Task RegisterOpeningForCollaborator(int fridgeId, string collaboratorId, int cardId, OpeningFor openingFor);

        Task RegisterOpeningForVulnerablePerson(int fridgeId, PersonInVulnerableSituation person, int cardId, OpeningFor openingFor);
    }
}
