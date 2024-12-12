namespace TPDDSBackend.Aplication.Dtos.Responses
{
    public class GetAllNeighborhoodResponse
    {
        public GetAllNeighborhoodResponse(IList<GetNeighborhoodResponse> neighborhoods)
        {
            Neighborhoods = neighborhoods;
        }
        public IList<GetNeighborhoodResponse> Neighborhoods { get; set; }
    }
}
