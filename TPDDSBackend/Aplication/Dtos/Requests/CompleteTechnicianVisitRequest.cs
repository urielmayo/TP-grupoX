namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public class CompleteTechnicianVisitRequest
    {
        public bool? FridgeRepaired { get; set; }

        public string? Comment { get; set; }

        public IFormFile? Image { get; set; }
    }
}
