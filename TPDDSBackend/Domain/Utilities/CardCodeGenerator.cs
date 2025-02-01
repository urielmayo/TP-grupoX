using TPDDSBackend.Infrastructure.Repositories; // Asegúrate de incluir el espacio de nombres
using System.Threading.Tasks;

namespace TPDDSBackend.Domain.Utilities
{
    public static class CardCodeGenerator
    {
        public static async Task<string> GenerateUniqueCardCode(ICardRepository cardRepository)
        {
            string cardCode;
            var random = new Random();
            do
            {
                cardCode = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 11)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            } while (await cardRepository.ExistsAsync(cardCode)); // Verifica si el código ya existe

            return cardCode;
        }
    }
}