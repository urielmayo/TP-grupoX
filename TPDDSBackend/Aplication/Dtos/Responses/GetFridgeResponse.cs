namespace TPDDSBackend.Aplication.Dtos.Responses
{
    public class GetFridgeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Longitud { get; set; }
        public decimal Latitud { get; set; }
        public int MaxFoodCapacity { get; set; }
    }
}
