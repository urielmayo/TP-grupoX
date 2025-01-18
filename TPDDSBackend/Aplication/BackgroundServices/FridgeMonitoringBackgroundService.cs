namespace TPDDSBackend.Aplication.BackgroundServices
{
    using System;
    using System.Net.Http;
    using System.Text.Json;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using TPDDSBackend.Aplication.Dtos.Requests;
    using TPDDSBackend.Aplication.Dtos.Responses;
    using TPDDSBackend.Domain.Enums;

    public class FridgeMonitoringBackgroundService : BackgroundService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<FridgeMonitoringBackgroundService> _logger;
        private readonly TimeSpan _updateTemperatureInterval = TimeSpan.FromMinutes(5);
        private readonly TimeSpan _generateAlertInterval = TimeSpan.FromMinutes(30);

        public FridgeMonitoringBackgroundService(
            HttpClient httpClient,
            ILogger<FridgeMonitoringBackgroundService> logger)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7017");
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("FridgeMonitoringBackgroundService is running.");

            var updateTemperatureTask = RunPeriodicTask(
                UpdateTemperaturesAsync,
                _updateTemperatureInterval,
                stoppingToken
            );

            var generateAlertTask = RunPeriodicTask(
                GenerateAlertsAsync,
                _generateAlertInterval,
                stoppingToken
            );

            await Task.WhenAll(updateTemperatureTask, generateAlertTask);
        }

        private async Task RunPeriodicTask(Func<CancellationToken, Task> task, TimeSpan interval, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await task(cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred during periodic task execution.");
                }

                await Task.Delay(interval, cancellationToken);
            }
        }

        private async Task UpdateTemperaturesAsync(CancellationToken cancellationToken)
        {
            try
            {
                var fridgesResponse = await _httpClient.GetAsync("/fridge", cancellationToken);
                fridgesResponse.EnsureSuccessStatusCode();
                var fridges = await fridgesResponse.Content.ReadFromJsonAsync<CustomResponse<GetAllFridgesResponse>>(cancellationToken);
                foreach (var fridge in fridges.Data.Fridges)
                {
                    var request = new RegisterTemperatureRequest()
                    {
                        Temperature = GenerateRandomTemperature()
                    };
                    string jsonBody = JsonSerializer.Serialize(request);
                    var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PostAsync($"/fridge/{fridge.Id}/temperature", content, cancellationToken);
                    if (!response.IsSuccessStatusCode)
                    {
                        _logger.LogWarning("Failed to update temperature for fridge {FridgeId}. Status Code: {StatusCode}", fridge.Id, response.StatusCode);
                    }
                }

                _logger.LogInformation("Successfully updated temperatures for all fridges.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating temperatures.");
            }
        }

        private async Task GenerateAlertsAsync(CancellationToken cancellationToken)
        {
            try
            {
                var fridgesResponse = await _httpClient.GetAsync("/fridge", cancellationToken);
                fridgesResponse.EnsureSuccessStatusCode();
                var responseGet = await fridgesResponse.Content.ReadFromJsonAsync<CustomResponse<GetAllFridgesResponse>>(cancellationToken);
                var firstFridge = responseGet.Data.Fridges.FirstOrDefault();

                var request = new CreateFridgeAlertRequest();
                request.FridgeId = firstFridge.Id;
                request.Type = GetRandomTypeAlert().ToString();
                string jsonBody = JsonSerializer.Serialize(request);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"/fridge-incident/alert", content, cancellationToken);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Failed to generate alert for fridge {FridgeId}. Status Code: {StatusCode}", firstFridge.Id, response.StatusCode);
                }
              
                _logger.LogInformation($"Successfully generated alert of {request.Type.ToString()} for fridge {firstFridge.Name}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while generating alerts.");
            }
        }

        public float GenerateRandomTemperature()
        {
            Random random = new Random();
            double minValue = -10.0;
            double maxValue = 5.0;

            // Generate a random double between minValue and maxValue
            double randomDouble = random.NextDouble() * (maxValue - minValue) + minValue;

            // Convert to float and return
            return (float)randomDouble;
        }

        private TypeFridgeAlert GetRandomTypeAlert()
        {
            Array values = Enum.GetValues(typeof(TypeFridgeAlert));
            Random random = new Random();
            return (TypeFridgeAlert)values.GetValue(random.Next(values.Length));
        }
    }


}
