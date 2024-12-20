using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Enums;

namespace TPDDSBackend.Domain.Entities
{
    public class FridgeOpening: AuditableEntity
    {
        public virtual Fridge Fridge { get; set; }

        public int FridgeId { get; set; }

        public virtual Card Card { get; set; }

        public int CardId { get; set; }

        public OpeningFor OpeningFor {  get; set; }
    }
}
