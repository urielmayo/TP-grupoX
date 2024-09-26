using System.Reflection.Metadata.Ecma335;

namespace TPDDSBackend.Domain.Entitites
{
    public class DocumentType : AuditableEntity
    {
        public string Description { get; set; }
    }
}
