using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.BackgroundServices.Services
{
    public class VisitRegistrationService
    {
        private readonly ITelegramBotClient _botClient;
        private readonly ITechnicianVisitRepository _technicianVisitRepository;
        private readonly IServer _server;

        public VisitRegistrationService(ITelegramBotClient botClient, 
            ITechnicianVisitRepository technicianVisitRepository,
            IHttpContextAccessor httpContextAccessor,
            IServer server)
        {
            _botClient = botClient;
            _technicianVisitRepository = technicianVisitRepository;
            _server = server;
        }


        public async Task HandlerFindActiveVisit(long chatId, string technicianName)
        {
            var visits = await _technicianVisitRepository.GetByTechnicianName(technicianName);
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
            var fullAddress = _server.Features.Get<IServerAddressesFeature>()?.Addresses.LastOrDefault();
            var uri = new Uri(fullAddress);
            string host = $"{uri.Scheme}://{uri.Host}";
            await _botClient.SendMessage(
                chatId,
                "👷‍♂️ Para completar la visita, haz clic en el siguiente enlace 📎 y carga el formulario: " +
                $"👉 {host}:5173/visit/{uuidToComplete} 📝 (Copia y pega la URL si no funciona)"
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
