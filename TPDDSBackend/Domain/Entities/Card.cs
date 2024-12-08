using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.Entities
{
    public class Card: AuditableEntity
    {
       public string Code { get; set; }
    }
}
