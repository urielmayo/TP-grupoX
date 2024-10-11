using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Dtos.Responses
{
    public class GetTechnicianResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int IdType { get; set; }
        public string IdNumber { get; set; }
        public string WorkerIdentificationNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
