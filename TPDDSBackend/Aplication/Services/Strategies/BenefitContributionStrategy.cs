using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Interfaces;

namespace TPDDSBackend.Aplication.Services.Strategies
{
    public class BenefitContributionStrategy : IContributionStrategy
    {
        public Dictionary<string, object> GetAttributes(Contribution contribution)
        {
            var donation = (Benefit)contribution;
            return new Dictionary<string, object>
            {
                { "Description", donation.Description},
                { "RequiredPoints", donation.RequiredPoints },
                { "Category", donation.Category }

            };
        }

        public decimal GetPoints(Contribution contribution)
        {
            return 0;
        }
    }
}
