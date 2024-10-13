using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public class FoodDeliveryContributionRequest
    {
        public int OriginFridgeId { get; set; }
        public int DestinationFridgeId { get; set; }
        public int Amount { get; set; }
        public int DeliveryReasonId { get; set; }
    }
}
