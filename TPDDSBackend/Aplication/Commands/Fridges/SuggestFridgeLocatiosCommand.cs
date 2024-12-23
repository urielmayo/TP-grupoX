using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Commands.Fridges
{
    public class SuggestFridgeLocatiosCommand : IRequest<CustomResponse<SuggestFridgeLocationsResponse>>
    {
        public SuggestFridgeLocationsRequest Request { get; set; }
        public SuggestFridgeLocatiosCommand(SuggestFridgeLocationsRequest request)
        {
           Request = request;
        }
    }

    public class SuggestFridgeLocatiosCommandHandler : IRequestHandler<SuggestFridgeLocatiosCommand, CustomResponse<SuggestFridgeLocationsResponse>>
    {
        private readonly IMapper _Mapper;


        public SuggestFridgeLocatiosCommandHandler(IMapper mapper)
        {
            _Mapper = mapper;
        }

        public async Task<CustomResponse<SuggestFridgeLocationsResponse>> Handle(SuggestFridgeLocatiosCommand command, CancellationToken ct)
        {
            var random = new Random();
            var suggestedLocations = new List<FridgeLocationsResponse>();
            double minDistanceBetweenPoints = command.Request.RadiusInKm / Math.Sqrt(command.Request.NumberOfPoints);

            for (int i = 0; i < command.Request.NumberOfPoints; i++)
            {
                FridgeLocationsResponse newPoint;
                bool isValidPoint;

                do
                {
                    var randomPoint = GenerateRandomPoint(
                        command.Request.Latitude,
                        command.Request.Longitude,
                        command.Request.RadiusInKm,
                        random);

                    newPoint = new FridgeLocationsResponse
                    {
                        Latitude = (decimal)randomPoint.lat,
                        Longitude = (decimal)randomPoint.lon
                    };

                    // Verificar si el nuevo punto está suficientemente lejos de los puntos existentes
                    isValidPoint = suggestedLocations.All(existingPoint =>
                        HaversineDistance((double)newPoint.Latitude, (double)newPoint.Longitude,
                                          (double)existingPoint.Latitude, (double)existingPoint.Longitude) >= minDistanceBetweenPoints);
                }
                while (!isValidPoint);

                suggestedLocations.Add(newPoint);
            }

            return new CustomResponse<SuggestFridgeLocationsResponse>(
                "Se sugieren los siguientes puntos de ubicación",
                new SuggestFridgeLocationsResponse(suggestedLocations));
        }
        

        private (double lat, double lon) GenerateRandomPoint(decimal centerLat, decimal centerLon, double radiusInKm, Random random)
        {
            const double earthRadiusKm = 6371.0;

            // Generar un ángulo aleatorio en radianes
            double angle = random.NextDouble() * Math.PI * 2;

            // Generar un desplazamiento aleatorio dentro del radio
            double distance = Math.Sqrt(random.NextDouble()) * radiusInKm;

            // Convertir el radio en kilómetros a grados angulares
            double distanceInRadians = distance / earthRadiusKm;

            double centerLatRad = (double)centerLat * Math.PI / 180.0;
            double centerLonRad = (double)centerLon * Math.PI / 180.0;

            double newLat = Math.Asin(Math.Sin(centerLatRad) * Math.Cos(distanceInRadians) +
                                      Math.Cos(centerLatRad) * Math.Sin(distanceInRadians) * Math.Cos(angle));
            double newLon = centerLonRad + Math.Atan2(Math.Sin(angle) * Math.Sin(distanceInRadians) * Math.Cos(centerLatRad),
                                                      Math.Cos(distanceInRadians) - Math.Sin(centerLatRad) * Math.Sin(newLat));

            // Convertir de radianes a grados
            return (newLat * 180.0 / Math.PI, newLon * 180.0 / Math.PI);
        }

        private double HaversineDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double EarthRadiusKm = 6371.0;

            double dLat = DegreesToRadians(lat2 - lat1);
            double dLon = DegreesToRadians(lon2 - lon1);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(DegreesToRadians(lat1)) * Math.Cos(DegreesToRadians(lat2)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return EarthRadiusKm * c;
        }

        private double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
    }
}


