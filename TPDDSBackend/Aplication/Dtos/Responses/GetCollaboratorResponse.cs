namespace TPDDSBackend.Aplication.Dtos.Responses
{
    public class GetCollaboratorResponse
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string? Rol { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string Type { get; set; }

       public IList<ContributionByCollaboratorResponse> Contributions { get; set; }
    }
}
