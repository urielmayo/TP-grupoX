using TPDDSBackend.Domain.Entities;
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
                { "origin_fridge_name", donation.OriginFridge.Name },
                { "destination_fridge_name", donation.DestinationFridge.Name},
                { "amount", donation.Amount },
                { "delivery_reason", donation.DeliveryReason.ReasonDescription }
            };
        }

        public decimal GetPoints(Contribution contribution, BenefitCoefficients coefficients)
        {
            var donation = (FoodDelivery)contribution;

            return donation.Amount * coefficients.DeliveredFoods;
        }
    }
}
