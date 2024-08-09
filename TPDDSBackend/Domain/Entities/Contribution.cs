namespace TPDDSBackend.Domain.Entitites
{
    public class Contribution : AuditableEntity
    {
        public DateTime Date { get; set; }
        public Collaborator Collaborator { get; set; }
    }
}
