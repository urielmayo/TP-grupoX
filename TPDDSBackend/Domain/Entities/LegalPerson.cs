namespace TPDDSBackend.Domain.Entitites
{
    public class LegalPerson : Collaborator
    {
        public string BusinessName { get; set; }
        public string Category { get; set; }
        public string  OrganizationType  { get; set; }
    }
}
