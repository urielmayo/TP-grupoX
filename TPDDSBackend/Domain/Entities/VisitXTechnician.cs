using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.Entities
{
    public class VisitXTechnician: AuditableEntity
    {
        public virtual Technician Technician { get; set; }

        public int TechnicianId { get; set; }

        public virtual TechnicianVisit TechnicianVisit { get; set; }

        public int TechnicianVisitId { get; set; }
    }
}
