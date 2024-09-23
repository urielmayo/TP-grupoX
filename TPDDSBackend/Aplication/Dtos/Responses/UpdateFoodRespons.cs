namespace TPDDSBackend.Aplication.Dtos.Responses
{
    public class UpdateFoodResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Calories { get; set; }
        public decimal Weight { get; set; }
    }
}
