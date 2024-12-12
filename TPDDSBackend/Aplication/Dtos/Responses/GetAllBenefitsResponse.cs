namespace TPDDSBackend.Aplication.Dtos.Responses
{
    public class GetAllBenefitsResponse
    {
        public GetAllBenefitsResponse(IList<GetBenefitResponse> benefits)
        {
            Benefits = benefits;
        }
        public IList<GetBenefitResponse> Benefits { get; set; }
    }
}
