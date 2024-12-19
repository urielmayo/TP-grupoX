namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public class UpdateFridgeRequest
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public bool? Active { get; set; }
        public decimal? Longitud { get; set; }
        public decimal? Latitud { get; set; }
        public DateTime? SetUpAt { get; set; }
        public int? MaxFoodCapacity { get; set; }
    }
}
