
namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public class PersonRegistrationContributionRequest
    {
        public string Name { get; set; }

        public string? Surname { get; set; }

        public DateOnly BirthDate { get; set; }

        public string? Addres { get; set; }

        public string? DocumentType { get; set; }

        public string? DocumentNumber { get; set; }

        public int MinorsInCare { get; set; }

        public string CardCode { get; set; }
    }
}
