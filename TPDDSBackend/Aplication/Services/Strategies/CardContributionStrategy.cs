using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Interfaces;

namespace TPDDSBackend.Aplication.Services.Strategies
{
    public class CardContributionStrategy : IContributionStrategy
    {
        public Dictionary<string, object> GetAttributes(Contribution contribution)
        {
            var donation = (Card)contribution;
            return new Dictionary<string, object>
            {
                { "PersonInVulnerableSituationName", donation.Owner.Name },
                { "CardCode", donation.Code }
            };
        }
    }
}
