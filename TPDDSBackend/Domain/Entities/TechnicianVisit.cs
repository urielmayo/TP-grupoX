using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.Entities
{
    public class TechnicianVisit: AuditableEntity
    {
        public virtual Technician Technician { get; set; }

        public int TechnicianId { get; set; }

        public virtual Fridge Fridge {  get; set; }
        
        public int FridgeId { get; set; }

        public bool FridgeRepaired { get; set; }

        public string? Comment { get; set; }

        public string? ImagePath { get; set; }
    }
}
