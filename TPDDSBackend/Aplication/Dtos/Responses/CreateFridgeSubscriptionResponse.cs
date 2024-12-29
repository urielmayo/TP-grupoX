using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Dtos.Responses
{
    public class CreateFridgeSubscriptionResponse
    {
        public int Id { get; set; }

        public int FridgeId { get; set; }

        public int? AvailableFoodsQuantity { get; set; }

        public int? FullFoodsQuantity { get; set; }

        public bool? IncidentSubscription { get; set; }

        public string CommunicationMedia { get; set; }
    }
}
