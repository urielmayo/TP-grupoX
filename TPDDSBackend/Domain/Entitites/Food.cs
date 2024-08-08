using System.ComponentModel.DataAnnotations.Schema;

namespace TPDDSBackend.Domain.Entitites
{
    public class Food : AuditableEntity
    {
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime DonationDate { get; set; }
        public State State { get; set; }
        public int Collaborator { get; set; }
        public Fridge Fridge { get; set; }
        public decimal Calories { get; set; }
        public decimal Weight { get; set; }
    }
}
