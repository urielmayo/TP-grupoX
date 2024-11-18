using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.Entities
{
    public class BenefitExchange: AuditableEntity
    {
        public int BenefitId { get; set; }

        public virtual Benefit Benefit { get; set; }

        public string UserId { get; set; }

        public virtual Collaborator User { get; set; }


    }
}
