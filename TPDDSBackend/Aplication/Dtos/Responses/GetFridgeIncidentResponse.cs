using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Dtos.Responses
{
    public class GetFridgeIncidentResponse
    { 
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }

        public string? Description { get; set; }
    }
}
