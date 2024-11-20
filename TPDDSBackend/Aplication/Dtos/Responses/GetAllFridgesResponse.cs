namespace TPDDSBackend.Aplication.Dtos.Responses
{
    public class GetAllFridgesResponse
    {
        public GetAllFridgesResponse(IList<GetFridgeResponse> fridges)
        {
            Fridges = fridges;
        }
        public IList<GetFridgeResponse> Fridges { get; set; }
    }
}
