using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Interfaces;

namespace TPDDSBackend.Aplication.Services.Strategies
{
    public class MoneyDonationStrategy : IContributionStrategy
    {
        public Dictionary<string, object> GetAttributes(Contribution contribution)
        {
            var donation = (MoneyDonation)contribution;
            return new Dictionary<string, object>
            {
                { "Amount", donation.Amount },
                { "Frequency", donation.Frequency.ToString() }
            };
        }
    }
}
