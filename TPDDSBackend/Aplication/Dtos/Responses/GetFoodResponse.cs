using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Dtos.Responses
{
    public class GetFoodResponse
    {
        public int Id { get; set; }
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
