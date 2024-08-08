namespace TPDDSBackend.Domain.Entitites
{
    public class ContactMediumXPerson : AuditableEntity
    {
        public Collaborator Collaborator { get; set; }
        public ContactMedium ContactMedium { get; set; }
        public int Value { get; set; }
    }
}
