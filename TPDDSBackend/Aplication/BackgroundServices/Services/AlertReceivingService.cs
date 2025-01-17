using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.BackgroundServices.Services
{
    public class AlertReceivingService
    {
        private readonly ITelegramBotClient _botClient;
        private readonly IFridgeIncidentRepository _incidentRepository;
        public AlertReceivingService(ITelegramBotClient botClient,
               IFridgeIncidentRepository fridgeIncidentRepository)
        {
            _botClient = botClient;
            _incidentRepository = fridgeIncidentRepository;
        }

        public async Task HandlerReceivingAlert(long chatId)
        {
            var incidents = await _incidentRepository.GetActiveIncidents();
            if (!incidents.Any())
            {
                await _botClient.SendMessage(
                    chatId,
                    "✅ No hay alertas de heladeras por incidentes"
                );
                return;
            }
            var messageBuilder = new StringBuilder();

            foreach (var incident in incidents)
            {
                
                messageBuilder.AppendLine($"🔴 *Incidente en heladera: {incident.Fridge.Name}");
                messageBuilder.AppendLine($"📍 Dirección: {incident.Fridge.Address}");
                messageBuilder.AppendLine($"📅 Fecha: {incident.Date:dd/MM/yyyy}");
                if (incident.Discriminator == "FridgeAlert")
                {
                    messageBuilder.AppendLine($"ℹ️ Tipo: Alerta Automatica");
                }
                else
                {
                    messageBuilder.AppendLine($"ℹ️ Tipo: Falla Reportada");
                }               
                messageBuilder.AppendLine($"🌍 [Ver en el mapa](https://www.google.com/maps?q={incident.Fridge.Latitud},{incident.Fridge.Longitud})");
                messageBuilder.AppendLine();
            }

            string fullMessage = messageBuilder.ToString();
            var allMessages = SplitMessage(fullMessage, 4000);

            foreach (var partialMessage in allMessages)
            {
                await _botClient.SendTextMessageAsync(
                    chatId,
                    partialMessage
                );
            }

        }

        private List<string> SplitMessage(string message, int maxLength)
        {
            var result = new List<string>();
            while (message.Length > maxLength)
            {
                int splitIndex = message.LastIndexOf("\n", maxLength); // Divide por línea
                if (splitIndex == -1) splitIndex = maxLength;

                result.Add(message.Substring(0, splitIndex));
                message = message.Substring(splitIndex).Trim();
            }

            if (!string.IsNullOrEmpty(message))
                result.Add(message);

            return result;
        }

    }
}
