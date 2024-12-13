namespace TPDDSBackend.Aplication.Dtos.Responses
{
    public class CreateFridgeFailureResponse
    {
        public required string CollaboratorId { get; set; }

        public int FridgeName { get; set; }

        public required string Description { get; set; }

        public string? ImagePath { get; set; }
    }
}
