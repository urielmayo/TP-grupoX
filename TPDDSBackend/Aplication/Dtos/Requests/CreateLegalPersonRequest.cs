namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public class CreateLegalPersonRequest
    {
        public string BusinessName { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; }
        public string? Adresss { get; set; }
    }
}
