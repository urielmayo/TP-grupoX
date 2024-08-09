using System.Reflection.Metadata.Ecma335;

namespace TPDDSBackend.Domain.Entitites
{
    public class Category : AuditableEntity
    {
        public string Description { get; set; }
    }
}
