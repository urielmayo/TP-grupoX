namespace TPDDSBackend.Infrastructure.Entities
{
    public class FridgeFoodStatsDto
    {
        public int FridgeId { get; set; }
        public string FridgeName { get; set; }
        public int FoodsPutIn { get; set; }
        public int FoodsTakenOut { get; set; }
    }
}
