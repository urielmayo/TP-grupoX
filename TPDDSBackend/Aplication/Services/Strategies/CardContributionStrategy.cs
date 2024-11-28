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
                { "vulnerable_person_name", donation.Owner.Name },
                { "card_code", donation.Code }
            };
        }

        public decimal GetPoints(Contribution contribution)
        {
            return 2.0m;
        }
    }
}
