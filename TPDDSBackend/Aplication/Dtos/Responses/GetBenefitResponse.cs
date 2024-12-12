namespace TPDDSBackend.Aplication.Dtos.Responses
{
    public class GetBenefitResponse
    {
        public string Description { get; set; }

        public string Category { get; set; }

        public int RequiredPoints { get; set; }

        public string ImagePath { get; set; }

        public string CollaboratorId { get; set; }
    }
}
