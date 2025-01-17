using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.BackgroundServices.Services
{
    public class ChangeWorkAreaService
    {
        private readonly ITelegramBotClient _botClient;
        private readonly IGenericRepository<Neighborhood> _neighborhoodRepository;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMemoryCache _memoryCache;

        public ChangeWorkAreaService(ITelegramBotClient botClient,
            IGenericRepository<Neighborhood> neighborhoodRepository,
            ApplicationDbContext applicationDbContext,
            IMemoryCache memoryCache)
        {
            _botClient = botClient;
            _neighborhoodRepository = neighborhoodRepository;
           _applicationDbContext = applicationDbContext;
            _memoryCache = memoryCache;
        }

        public async Task ShowWorkAreas(long chatId)
        {
            var neighborhoods = _neighborhoodRepository.GetAll().ToList();
            var buttons = CreateInlineKeyboard(neighborhoods);
            await _botClient.SendMessage(
               chatId,
               "Seleccione una zona para continuar😊",
               replyMarkup: buttons
           );
            return;
        }

        public async Task ChangeArea(long chatId, string areaId, Technician technician)
        {
            int areaIdInt = int.Parse(areaId);
            technician.NeighborhoodId = areaIdInt;
            _applicationDbContext.Entry(technician).State = EntityState.Modified;
            _applicationDbContext.Technicians.Update(technician);
            _applicationDbContext.SaveChanges();
            _memoryCache.Set(chatId, technician);
            var areaUpdated = await _applicationDbContext.Neighborhoods.FirstAsync(n => n.Id == areaIdInt);
            await _botClient.SendMessage(
               chatId,
               $"Se ha actualizado tu zona a {areaUpdated.Name}😊"
           );
            return;
        }

        private InlineKeyboardMarkup CreateInlineKeyboard(List<Neighborhood> items)
        {
            // Crear una lista de filas de botones
            var buttons = new List<InlineKeyboardButton[]>();

            foreach (var item in items)
            {
                // Crear un botón por cada objeto
                var button = InlineKeyboardButton.WithCallbackData(
                    text: item.Name,    // Texto que verá el usuario
                    callbackData: $"/select-area {item.Id.ToString()}" // ID u otra información para identificar la opción
                );

                // Agregar el botón como una fila (puedes agregar más de uno si es necesario)
                buttons.Add(new[] { button });
            }

            return new InlineKeyboardMarkup(buttons);
        }
    }
}
