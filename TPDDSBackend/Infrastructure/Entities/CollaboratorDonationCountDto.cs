namespace TPDDSBackend.Infrastructure.Entities
{
    public class CollaboratorDonationCountDto
    {
        public required string CollaboratorId { get; set; }

        public string CollaboratorName { get; set; }

        public int TotalDonations {  get; set; }
    }
}
