namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public class CreateHumanPersonRequest
    {
        public string Name { get; set; }

        public string UserName { get; set; }
        public string SurName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string Password { get; set; }

        public DateOnly? BirthDate { get; set; }

        public string? Address { get; set; }
    }
}
