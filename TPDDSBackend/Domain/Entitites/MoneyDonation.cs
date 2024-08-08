namespace TPDDSBackend.Domain.Entitites
{
    public class MoneyDonation : Contribution
    {
        public decimal Amount { get; set; }
        public int Frequency { get; set; }
    }
}
