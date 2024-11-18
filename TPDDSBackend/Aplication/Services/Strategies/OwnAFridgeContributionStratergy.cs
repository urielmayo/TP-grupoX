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
                { "Fridge", donation.Fridge.Name }
            };
        }

        public decimal GetPoints(Contribution contribution)
        {
            var donation = (FridgeOwner)contribution;
            return donation.Fridge.Active ? GetPointsByFridge(donation.Fridge) : 0m;
        }

        private decimal GetPointsByFridge(Fridge fridge) 
        {
            int activeMounths = ((DateTime.Now.Year - fridge.SetUpAt.Year) * 12) + (DateTime.Now.Month - fridge.SetUpAt.Month);

            return activeMounths * 5.0m;
        }
    }
}
