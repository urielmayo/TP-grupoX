namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public abstract class CreateCollaboratorBase
    {
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string Password { get; set; }

        public string? Address { get; set; }

        public string UserName { get; set; }
    }
}
