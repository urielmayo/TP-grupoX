namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public class UpdateFridgeSuscriptionRequest
    {
        public int? AvailableFoodsQuantity { get; set; }

        public int? FullFoodsQuantity { get; set; }

        public bool? IncidentSubscription { get; set; }

        public string CommunicationMedia { get; set; }
    }
}
