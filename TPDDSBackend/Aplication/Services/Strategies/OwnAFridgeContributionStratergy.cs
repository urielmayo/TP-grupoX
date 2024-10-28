using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Interfaces;


namespace TPDDSBackend.Aplication.Services.Strategies
{
    public class OwnAFridgeContributionStratergy : IContributionStrategy
    {
        public Dictionary<string, object> GetAttributes(Contribution contribution)
        {
            var donation = (FridgeOwner)contribution;
            return new Dictionary<string, object>
            {
                { "FridgeId", donation.FridgeId }
            };
        }
    }
}
