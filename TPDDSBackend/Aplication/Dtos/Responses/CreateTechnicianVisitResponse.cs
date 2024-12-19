using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Dtos.Responses
{
    public class CreateTechnicianVisitResponse
    {
        public int Id { get; set; }
        
        public bool FridgeRepaired { get; set; }

        public string? Comment { get; set; }

        public string? ImagePath { get; set; }

        public string LinkToUpload { get; set; }
    }
}
