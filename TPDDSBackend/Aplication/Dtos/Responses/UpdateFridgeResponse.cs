namespace TPDDSBackend.Aplication.Dtos.Responses
{
    public class UpdateFridgeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
        public decimal Longitud { get; set; }
        public decimal Latitud { get; set; }
        public DateTime SetUpAt { get; set; }
        public int MaxFoodCapacity { get; set; }
    }
}
