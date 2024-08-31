namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public class CreateLegalPersonRequest: CreateCollaboratorBase
    {
        public string BusinessName { get; set; }
        public string OrganizationType { get; set; }
        public string Category { get; set; }
    }
}
