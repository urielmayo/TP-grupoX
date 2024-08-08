namespace TPDDSBackend.Domain.Entitites
{
    public class Collaborator : AuditableEntity
    {
        public ContactMediumXPerson ContactMediumXPerson { get; set; }
        public string Address { get; set; }
    }
}
