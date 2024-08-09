namespace TPDDSBackend.Domain.Entitites
{
    public class FoodDonation : Contribution
    {
        public virtual Food Food { get; set; }
        public int FoodId { get; set; }
    }
}
