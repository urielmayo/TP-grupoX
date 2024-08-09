namespace TPDDSBackend.Domain.Entitites
{
    public class LegalPerson : Collaborator
    {
        public string BusinessName { get; set; }
        public Category Category { get; set; }
        public BusinessType Type { get; set; }
    }
}
