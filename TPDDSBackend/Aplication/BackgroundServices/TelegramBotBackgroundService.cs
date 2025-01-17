using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace TPDDSBackend.Aplication.BackgroundServices
{
    public class TelegramBotBackgroundService : BackgroundService
    {
        private readonly TelegramBotHandler _botHandler;
        public TelegramBotBackgroundService(TelegramBotHandler botHandler)
        {
            _botHandler = botHandler;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await _botHandler.StartBotWithGetUpdatesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en TelegramBotBackgroundService: {ex.Message}");
                    await Task.Delay(5000, stoppingToken);
                }
            }
        }
    }
}
