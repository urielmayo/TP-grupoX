namespace TPDDSBackend.Aplication.Dtos.Requests
{
    public class SuggestFridgeLocationsRequest
    {
        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public int RadiusInKm { get; set; }

        public int NumberOfPoints { get; set; }
    }
}
