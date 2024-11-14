using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Interfaces;

namespace TPDDSBackend.Aplication.Services.Strategies
{
    public class FoodDeliveryContributionStrategy : IContributionStrategy
    {
        public Dictionary<string, object> GetAttributes(Contribution contribution)
        {
            var donation = (FoodDelivery)contribution;
            return new Dictionary<string, object>
            {
                { "OriginFridge", donation.OriginFridge.Name },
                { "DestinationFridge", donation.DestinationFridge.Name},
                { "Amount", donation.Amount },
                { "DeliveryReason", donation.DeliveryReason.ReasonDescription }
            };
        }
    }
}
