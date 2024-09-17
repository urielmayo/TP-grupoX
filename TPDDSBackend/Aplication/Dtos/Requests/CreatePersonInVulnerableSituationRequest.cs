namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public class CreatePersonInVulnerableSituationRequest
    {
        public string Name { get; set; }

        public DateOnly BirthDate { get; set; }

        public string? Addres { get; set; }

        public string? DocumentType { get; set; }

        public string? DocumentNumber { get; set; }

        public int MinorsInCare { get; set; }
    }
}
