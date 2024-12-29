using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.Entities
{
    public class SubscriptionMessage: AuditableEntity
    {
        public string Message { get; set; }

        public int CommunicationMediaId { get; set; }

        public virtual CommunicationMedia CommunicationMedia { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidUntil { get; set; }
    }
}
