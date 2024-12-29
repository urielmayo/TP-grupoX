using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.Entities
{
    public class FridgeSubscription: AuditableEntity
    {
        public string CollaboratorId { get; set; }

        public virtual Collaborator Collaborator { get; set; }

        public int FridgeId { get; set; }

        public virtual Fridge Fridge { get; set; }

        public int? AvailableFoodsQuantity { get; set; }

        public int? FullFoodsQuantity { get; set; }

        public bool? IncidentSubscription {  get; set; }

        public int CommunicationMediaId { get; set; }

        public virtual CommunicationMedia CommunicationMediaDesired { get; set; }
    }
}
