namespace TPDDSBackend.Domain.Entitites
{
    public class PersonInVulnerableSituation : AuditableEntity
    {
        public string Name { get; set; }
        public string? Surname { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateTime RegistratedAt { get; set; }
        public string? Address { get; set; }
        public int MinorsInCare { get; set; }
        public string? DocumentNumber { get; set; }
        public virtual DocumentType? DocumentType { get; set; }
        public int? DocumentTypeId { get; set; }
    }
}
