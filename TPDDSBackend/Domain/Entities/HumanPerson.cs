using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Domain.Entitites
{
    public class HumanPerson : Collaborator
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly? BirthDate { get; set; }

    }
}
