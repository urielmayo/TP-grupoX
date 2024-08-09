using TPDDSBackend.Domain.Enums;

namespace TPDDSBackend.Domain.Entitites
{
    public class MoneyDonation : Contribution
    {
        public decimal Amount { get; set; }
        public DonationFrequency Frequency { get; set; }
    }
}
