using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public class UpdateTechnicianRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int DocumentTypeId { get; set; }
        public string IdNumber { get; set; }
        public string WorkerIdentificationNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int NeighborhoodId { get; set; }
    }
}
