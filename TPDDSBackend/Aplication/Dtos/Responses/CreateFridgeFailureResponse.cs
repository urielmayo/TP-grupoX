namespace TPDDSBackend.Aplication.Dtos.Responses
{
    public class CreateFridgeFailureResponse
    {
        public required string CollaboratorId { get; set; }

        public string FridgeName { get; set; }

        public required string Description { get; set; }
    }
}
