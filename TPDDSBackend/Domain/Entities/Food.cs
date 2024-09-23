using System.ComponentModel.DataAnnotations.Schema;

namespace TPDDSBackend.Domain.Entitites
{
    public class Food : AuditableEntity
    {
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime DonationDate { get; set; }
        public virtual FoodState State { get; set; }
        public int StateId { get; set; }
        public virtual PersonInVulnerableSituation? Donee { get; set; }
        public int DoneeId { get; set; }
        public int FridgeId { get; set; }
        public virtual Fridge Fridge { get; set; }
        public decimal Calories { get; set; }
        public decimal Weight { get; set; }
    }
}
