using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.Entities
{
    public class BenefitCoefficients: AuditableEntity
    {
        public decimal DonatedPesos { get; set; }

        public decimal DonatedFoods { get; set; }

        public decimal DeliveredFoods { get; set; }

        public decimal DeliveredCards { get; set; }

        public decimal ActiveFridges { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidUntil { get; set; }
    }
}
