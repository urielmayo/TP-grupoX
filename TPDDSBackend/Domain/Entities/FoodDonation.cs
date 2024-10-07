namespace TPDDSBackend.Domain.Entitites
{
    public class FoodDonation : Contribution
    {
        public virtual Food Food { get; set; }
        public int FoodId { get; set; }
        public virtual PersonInVulnerableSituation? Donee { get; set; }
        public int? DoneeId { get; set; }
    }
}
