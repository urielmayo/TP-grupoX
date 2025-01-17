using Microsoft.Extensions.Caching.Memory;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.BackgroundServices.Services
{
    public class VisitRegistrationService
    {
        private readonly ITelegramBotClient _botClient;
        private readonly IMemoryCache _memoryCache;
        private readonly ITechnicianVisitRepository _technicianVisitRepository;

        public VisitRegistrationService(ITelegramBotClient botClient, 
            IMemoryCache memoryCache,
            ITechnicianVisitRepository technicianVisitRepository)
        {
            _botClient = botClient;
            _memoryCache = memoryCache;
            _technicianVisitRepository = technicianVisitRepository;
        }


        public async Task HandlerFindActiveVisit(long chatId)
        {
            var result = _memoryCache.TryGetValue(chatId, out string? username);
            var visits = await _technicianVisitRepository.GetByTechnicianName(username);
            if (visits?.Count == 0)
            {
                await _botClient.SendMessage(chatId, "No tienes visitas pendientes disponibles. 😔");
                return;
            }

            // Crear el teclado
            var inlineKeyboard = CreateInlineKeyboard(visits);

            // Enviar mensaje con los botones
            await _botClient.SendMessage(
                chatId,
                "Seleccione una heladera:",
                replyMarkup: inlineKeyboard
            );
            return;
        }

        public async Task HandlerCompleteVisit(long chatId, string uuidToComplete)
        {

            await _botClient.SendMessage(
                chatId,
                "👷‍♂️ Para completar la visita, haz clic en el siguiente enlace 📎 y carga el formulario: " +
                $"👉 http://localhost:5173/visit/{uuidToComplete} 📝 (Copia y pega la URL si no funciona)"
            );
            return;
        }

        private InlineKeyboardMarkup CreateInlineKeyboard(List<TechnicianVisit> items)
        {
            // Crear una lista de filas de botones
            var buttons = new List<InlineKeyboardButton[]>();

            foreach (var item in items)
            {
                // Crear un botón por cada objeto
                var button = InlineKeyboardButton.WithCallbackData(
                    text: item.Fridge.Name,    // Texto que verá el usuario
                    callbackData: $"/select-fridge {item.UuidToComplete.ToString()}" // ID u otra información para identificar la opción
                );

                // Agregar el botón como una fila (puedes agregar más de uno si es necesario)
                buttons.Add(new[] { button });
            }

            return new InlineKeyboardMarkup(buttons);
        }
    }
}
