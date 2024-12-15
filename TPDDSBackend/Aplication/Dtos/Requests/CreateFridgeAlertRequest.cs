namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public class CreateFridgeAlertRequest
    {
        public int FridgeId { get; set; }

        public required string Type { get; set; }
    }
}
