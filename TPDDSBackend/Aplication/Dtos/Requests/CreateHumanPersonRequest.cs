namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public class CreateHumanPersonRequest: CreateCollaboratorBase
    {
        public string Name { get; set; }

        public string UserName { get; set; }
        public string SurName { get; set; }
        public DateOnly? BirthDate { get; set; }
    }
}
