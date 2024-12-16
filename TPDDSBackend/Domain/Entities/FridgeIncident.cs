using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.Entities
{
    public class FridgeIncident: AuditableEntity
    {
        public virtual Fridge Fridge { get; set; }

        public int FridgeId { get; set; }

        public DateTime Date { get; set; }

        public string Discriminator { get; set; }
    }
}
