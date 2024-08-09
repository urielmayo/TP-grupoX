namespace TPDDSBackend.Domain.Entitites
{
    public class ContactMediumXPerson : AuditableEntity
    {
        public virtual Collaborator Collaborator { get; set; }
        public string CollaboratorId { get; set; }
        public ContactMedium ContactMedium { get; set; }
        public int Value { get; set; }
    }
}
