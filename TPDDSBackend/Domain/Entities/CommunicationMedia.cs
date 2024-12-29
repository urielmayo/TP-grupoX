using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Enums;

namespace TPDDSBackend.Domain.Entities
{
    public class CommunicationMedia: AuditableEntity
    {
        public CommunicationMediaName Name { get; set; }
    }
}
