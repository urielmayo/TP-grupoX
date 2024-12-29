using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public class CreateFridgeSubscriptionRequest
    {
        public int FridgeId { get; set; }

        public int? AvailableFoodsQuantity { get; set; }

        public int? FullFoodsQuantity { get; set; }

        public bool? IncidentSubscription { get; set; }

        public string CommunicationMedia { get; set; }
    }
}
