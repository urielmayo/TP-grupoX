namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public class CreateLegalPersonRequest: CreateCollaboratorBase
    {
        public string BusinessName { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
    }
}
