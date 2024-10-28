using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Interfaces;

namespace TPDDSBackend.Aplication.Services.Strategies
{
    public class FoodContributionStrategy : IContributionStrategy
    {
        public Dictionary<string, object> GetAttributes(Contribution contribution)
        {
            var donation = (FoodDonation)contribution;
            return new Dictionary<string, object>
            {
                { "FoodId", donation.FoodId },
                { "DoneeId", donation.DoneeId }
            };
        }
    }
}
