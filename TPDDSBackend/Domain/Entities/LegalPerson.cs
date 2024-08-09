namespace TPDDSBackend.Domain.Entitites
{
    public class LegalPerson : Collaborator
    {
        public string BusinessName { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public virtual OrganizationType Type { get; set; }
        public int OrganizationTypeId { get; set; }
    }
}
