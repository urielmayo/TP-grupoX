namespace TPDDSBackend.Aplication.Dtos.Responses
{
    public class SuggestFridgeLocationsResponse
    {
        public List<FridgeLocationsResponse> Locations { get; set; }
        public SuggestFridgeLocationsResponse(List<FridgeLocationsResponse> locations)
        {
            Locations = locations;
        }
    }
}
