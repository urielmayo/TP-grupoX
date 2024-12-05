namespace TPDDSBackend.Aplication.Dtos.Responses
{
    public class GetAllCoefficientsResponse
    {
        public GetAllCoefficientsResponse(IList<CoefficientsResponse> coefficients)
        {
            Coefficients = coefficients;
        }
        public IList<CoefficientsResponse> Coefficients { get; set; }
    }
}
