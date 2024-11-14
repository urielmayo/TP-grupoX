namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public class FoodContributionRequest
    {
        public string Description { get; set; }
        public string ExpirationDate { get; set; }
        public int FridgeId { get; set; }
        public decimal Calories { get; set; }
        public decimal Weight { get; set; }
        public int? DoneeId { get; set; }
    }
}
