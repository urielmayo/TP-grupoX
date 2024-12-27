namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public class OpeningRequest
    {
        public int FridgeId { get; set; }

        public string OpeningFor {  get; set; }

        public int? PersonInVulnerableSituationId { get; set; }
    }
}
