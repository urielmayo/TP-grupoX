namespace TPDDSBackend.Aplication.Dtos.Responses
{
    public class ContributionResponse
    {
        public int Id { get; set; }
        public required string Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public required Dictionary<string, object> Attributes { get; set; }
    }
}
