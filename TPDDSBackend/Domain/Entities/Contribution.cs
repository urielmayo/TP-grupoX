namespace TPDDSBackend.Domain.Entitites
{
    public class Contribution : AuditableEntity
    {
        public DateTime Date { get; set; }
        public virtual Collaborator Collaborator { get; set; }
        public int CollaboratorId { get; set; }
    }
}
