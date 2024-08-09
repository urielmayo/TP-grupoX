namespace TPDDSBackend.Domain.Entitites
{
    public class MeanOfContact: AuditableEntity
    {
        public virtual Collaborator Collaborator { get; set; }
        public string CollaboratorId { get; set; }
        public virtual ContactMediaType Type { get; set; }
        public int ContactMediaTypeId { get; set; }
        public int Value { get; set; }
    }
}
