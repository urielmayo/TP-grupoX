using TPDDSBackend.Domain.Entities;
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
                { "fridgeId", donation.Fridge.Id},
                { "name", donation.Fridge.Name },
                { "address", donation.Fridge.Address },
                { "setup_date", donation.Fridge.Address },
                { "capacity", donation.Fridge.MaxFoodCapacity },
            };
        }

        public decimal GetPoints(Contribution contribution, BenefitCoefficients coefficients)
        {
            var donation = (FridgeOwner)contribution;
            return donation.Fridge.Active ? GetPointsByFridge(donation.Fridge, coefficients.ActiveFridges) : 0m;
        }

        private decimal GetPointsByFridge(Fridge fridge, decimal coefficient)
        {
            int activeMounths = ((DateTime.Now.Year - fridge.SetUpAt.Year) * 12) + (DateTime.Now.Month - fridge.SetUpAt.Month);

            return activeMounths * coefficient;
        }
    }
}
