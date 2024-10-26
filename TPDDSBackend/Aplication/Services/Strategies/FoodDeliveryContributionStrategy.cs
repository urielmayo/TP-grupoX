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
                { "OriginFridgeId", donation.OriginFridgeId },
                { "DestinationFridge", donation.DestinationFridgeId },
                { "Amount", donation.Amount },
                { "DeliveryReasonId", donation.DeliveryReasonId }
            };
        }
    }
}
