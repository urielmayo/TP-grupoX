using AutoMapper;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Mappers
{
    public class TechnicianProfile : Profile
    {
        public TechnicianProfile()
        {
            CreateMap<CreateTechnicianRequest, Technician>();
            //CreateMap<UpdateFridgeRequest, Fridge>();
        }
    }
}

