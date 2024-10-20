namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public class MoneyDonationRequest
    {
        public decimal Amount { get; set; }

        public string Date { get; set; }

        public string Frequency { get; set; }
    }
}
