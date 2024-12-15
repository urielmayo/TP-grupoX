namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public class CreateFridgeFailureRequest
    {
        public int FridgeId { get; set; }

        public required string Description { get; set; }

        public string? ImagePath { get; set; }
    }
}
