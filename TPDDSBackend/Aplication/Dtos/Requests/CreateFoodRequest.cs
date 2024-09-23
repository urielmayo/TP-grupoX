using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public class CreateFoodRequest
    {
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime DonationDate { get; set; }
        public int StateId { get; set; }
        public int DoneeId { get; set; }
        public int FridgeId { get; set; }
        public decimal Calories { get; set; }
        public decimal Weight { get; set; }
    }
}
