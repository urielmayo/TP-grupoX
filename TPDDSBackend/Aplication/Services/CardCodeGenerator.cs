using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Services
{
    public class CardCodeGenerator : ICardCodeGenerator
    {
        private readonly ICardRepository _cardRepository;

        public CardCodeGenerator(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }
        public async Task<string> GenerateUniqueCardCode()
        {
            string cardCode;
            var random = new Random();
            do
            {
                cardCode = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 11)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            } while (await _cardRepository.ExistsAsync(cardCode));
            return cardCode;
        }
    }
}
