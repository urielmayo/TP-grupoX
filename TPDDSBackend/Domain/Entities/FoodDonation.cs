using TPDDSBackend.Domain.Enums;

namespace TPDDSBackend.Domain.Entitites
{
    public class FoodDonation : Contribution
    {
        public virtual Food Food { get; set; }
        public int FoodId { get; set; }
        public virtual PersonInVulnerableSituation? Donee { get; set; }
        public int? DoneeId { get; set; }
        public virtual Fridge Fridge { get; set; }

        public int FridgeId { get; set; }

        public ContributionStatus Status { get; set; }
    }
}
