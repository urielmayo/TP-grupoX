using AutoMapper;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Mappers
{
    public class FridgeProfile : Profile
    {
        public FridgeProfile()
        {
            CreateMap<CreateFridgeRequest, Fridge>();
            CreateMap<UpdateFridgeRequest, Fridge>();
            CreateMap<Fridge, GetFridgeResponse>();

            CreateMap<FridgeModel, SetupTemperaturesResponse>()
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Name));
        }
    }
}

