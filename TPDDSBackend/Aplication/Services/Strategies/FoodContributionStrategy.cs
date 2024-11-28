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
                { "description", donation.Food.Description },
                { "expiration_date", donation.Food.ExpirationDate},
                { "calories", donation.Food.Calories},
                { "Donee", donation.Collaborator.UserName }
            };
        }

        public decimal GetPoints(Contribution contribution)
        {
            return 1.5m;
        }
    }
}
