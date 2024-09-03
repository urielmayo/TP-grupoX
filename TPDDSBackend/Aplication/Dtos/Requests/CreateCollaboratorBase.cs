namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public abstract class CreateCollaboratorBase
    {
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string Password { get; set; }

        public string? Adress { get; set; }

        public string UserName { get; set; }
    }
}
