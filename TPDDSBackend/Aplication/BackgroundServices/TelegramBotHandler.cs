using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TPDDSBackend.Aplication.BackgroundServices.Services;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;
using static System.Collections.Specialized.BitVector32;

namespace TPDDSBackend.Aplication.BackgroundServices
{
    public class TelegramBotHandler
    {
        private readonly ITelegramBotClient _botClient;
        private readonly IMemoryCache _memoryCache;
        private readonly IServiceScopeFactory _scopeFactory;
        private const int ExpiredSessionInMinutes = 30;
        private InlineKeyboardMarkup Options = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("⚠️ Alertas", "/alerta"),
                    InlineKeyboardButton.WithCallbackData("📍 Cambiar Zona", "/cambiar-zona"),
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("❄️ Registrar Visitar Heladera", "/registrar-visita"),
                }
            });
        public TelegramBotHandler(ITelegramBotClient botClient,
            IServiceScopeFactory scopeFactory,
            IMemoryCache memoryCache)
        {
            _botClient = botClient;
            _scopeFactory = scopeFactory;
            _memoryCache = memoryCache;
        }

        public async Task StartBotWithGetUpdatesAsync()
        {
            try
            {
                var offset = 0; // Offset inicial

                while (true)
                {
                    var updates = await _botClient.GetUpdatesAsync(offset: offset);

                    foreach (var update in updates)
                    {
                        if (update.Message != null)
                        {
                            var chatId = update.Message.Chat.Id;
                            var messageText = update.Message.Text?.ToLower();

                            // Muestra el mensaje recibido
                            Console.WriteLine($"Mensaje recibido: {messageText} de {chatId}");

                            (Technician? technician, bool isUserAuthenticated) = IsUserAuthenticated(chatId);
                            if (isUserAuthenticated)
                            {
                                await HandleAuthenticatedUserActions(messageText, chatId, technician);                           
                            }
                            else
                            {
                                // Si el usuario no está autenticado, intentar autenticarse
                                if (messageText?.StartsWith("/autenticar") == true)
                                {
                                    await AuthenticateUserAsync(chatId, messageText);
                                }
                                else
                                {
                                    await _botClient.SendMessage(
                                         chatId,
                                         ConstantsMessages.UnauthenticatedUserMessage
                                     );
                                }
                            }
                        }
                        else if (update.CallbackQuery !=null)
                        {
                            string action = update.CallbackQuery.Data.Trim().ToString();
                            var chatId = update.CallbackQuery.Message.Chat.Id;
                            (Technician? technician, bool isUserAuthenticated) = IsUserAuthenticated(chatId);
                            if (isUserAuthenticated)
                            {
                                await HandleAuthenticatedUserActions(action, chatId, technician);
                                
                            }
                            else
                            {
                                await _botClient.SendMessage(chatId, ConstantsMessages.UnauthenticatedUserMessage);
                            }                            
                        }

                        // Actualiza el offset para evitar recibir la misma actualización
                        offset = update.Id + 1;
                    }

                    // Espera un poco antes de realizar la siguiente consulta para no hacer demasiadas solicitudes en corto tiempo
                    await Task.Delay(500); // 1/2 segundo de espera
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al recibir actualizaciones: {ex.Message}");
            }
        }

        // Maneja las acciones de un usuario autenticado
        private async Task HandleAuthenticatedUserActions(string action, long chatId, Technician technician)
        {
            if (action.Contains("/alerta"))
            {
                await SendAlertAsync(chatId);
            }
            else if (action.Contains("/cambiar-zona") ||action.Contains("/select-area"))
            {
                await ChangeWorkZoneAsync(chatId, action, technician);
            }
            else if (action.Contains("/registrar-visita") || action.Contains("/select-fridge"))
            {
                await RegisterFridgeVisitAsync(chatId, action);
            }          
            else
            {
                await ShowOptionsMenuWithActions(chatId);
            }
        }

        // Autenticación del usuario con consulta a la base de datos
        private async Task AuthenticateUserAsync(long chatId, string messageText)
        {
            // Asumimos que el formato de autenticación es /autenticar Nombre NúmeroDeTrabajador
            var parts = messageText.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 3)
            {
                var name = parts[1];
                var workerId = parts[2];

                // Usamos el IServiceScopeFactory para crear un alcance y resolver el repositorio con ciclo de vida Scoped
                using var scope = _scopeFactory.CreateScope();
                var technicianRepository = scope.ServiceProvider.GetRequiredService<ITechnicianRepository>();

                // Consultamos en la base de datos si existe el usuario con el nombre y workerId
                var technician = await technicianRepository.GetByNameAndWorkerNumber(name, workerId);

                if (technician != null)
                {
                    // El usuario existe, lo almacenamos en el caché
                    _memoryCache.Set(chatId, technician, TimeSpan.FromMinutes(ExpiredSessionInMinutes));
                    await _botClient.SendMessage(chatId, $"✅ Usuario {name} autenticado correctamente. ¡Bienvenido! 😊");
                    await _botClient.SendMessage(
                       chatId: chatId,
                       text: "Seleccione alguna de las opcione disponibles👇",
                       replyMarkup: Options
                   );
                }
                else
                {
                    await _botClient.SendMessage(chatId, "❌ No se encontró un usuario con ese nombre y número de trabajador. Por favor, inténtelo nuevamente. 🙁");
                }
            }
            else
            {
                await _botClient.SendMessage(
                   chatId,
                   "⚠️ Formato incorrecto. Por favor, usa el formato:\n\n" +
                   "/autenticar Nombre NúmeroDeTrabajador ✏️\n\n" +
                   "Por ejemplo: /autenticar Juan 12345 🧑‍💼"
               );
            }
        }

        // Acción para enviar una alerta
        private async Task SendAlertAsync(long chatId)
        {
            using var scope = _scopeFactory.CreateScope();
            var alertReceivingService = scope.ServiceProvider.GetRequiredService<AlertReceivingService>();
            await alertReceivingService.HandlerReceivingAlert(chatId);
        }

        // Acción para cambiar la zona de trabajo
        private async Task ChangeWorkZoneAsync(long chatId, string action, Technician technician)
        {
            using var scope = _scopeFactory.CreateScope();
            var changeWorkAreaService = scope.ServiceProvider.GetRequiredService<ChangeWorkAreaService>();
            if (action.Contains("/cambiar-zona"))
            {
                await changeWorkAreaService.ShowWorkAreas(chatId);
                return;
            }
            else if (action.Contains("/select-area"))
            {
                string[] parts = action.Split(' ');
                await changeWorkAreaService.ChangeArea(chatId, parts[1], technician);
                return;
            }
        }

        // Acción para registrar una visita a una heladera
        private async Task RegisterFridgeVisitAsync(long chatId, string action)
        {
            // Aquí agregas la lógica para registrar la visita
            using var scope = _scopeFactory.CreateScope();  
            var visitRegistrationService = scope.ServiceProvider.GetRequiredService<VisitRegistrationService>();
            if (action.Contains("registrar-visita"))
            {
                await visitRegistrationService.HandlerFindActiveVisit(chatId);
                return;
            }
            else if (action.Contains("/select-fridge"))
            {
                string[] parts = action.Split(' ');
                await visitRegistrationService.HandlerCompleteVisit(chatId, parts[1]);
                return;
            }       
        }
      

        private async Task ShowOptionsMenuWithActions(long chatId)
        {  
            await _botClient.SendMessage(
                chatId: chatId,
                text: "Lo siento, no se encontró esa opción. 😔😊\r\nPor favor, seleccione alguna de las opciones👇:",
                replyMarkup: Options
            );
        }

        private (Technician? technician, bool isAuthenticated) IsUserAuthenticated(long chatId)
        {
            var result = _memoryCache.TryGetValue(chatId, out Technician? technician);
            return (technician, result);
        }
    }
  }

