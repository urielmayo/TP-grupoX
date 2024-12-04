namespace TPDDSBackend.Aplication.Dtos.Responses
{
    public class GetAllTechniciansResponse
    {
        public GetAllTechniciansResponse(IList<GetTechnicianResponse> technicians)
        {
            Technicians = technicians;
        }
        public IList<GetTechnicianResponse> Technicians { get; set; }
    }
}