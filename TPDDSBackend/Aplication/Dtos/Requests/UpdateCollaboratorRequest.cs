namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public class UpdateCollaboratorRequest
    {

        public string? UserName { get; set; }
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }
    }
}
