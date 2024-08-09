using System.Globalization;

namespace TPDDSBackend.Domain.Entitites
{
    public class AuditableEntity
    {
        public int Id { get; set; }
        public DateTime LastModificationAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
