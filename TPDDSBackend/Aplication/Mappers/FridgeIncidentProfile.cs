using AutoMapper;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Mappers
{
    public class FridgeIncidentProfile : Profile
    {
        public FridgeIncidentProfile()
        {

            CreateMap<CreateFridgeFailureRequest, FridgeFailure>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.UtcNow));


            CreateMap<FridgeFailure, CreateFridgeFailureResponse>()
                .ForMember(dest => dest.FridgeName, opt => opt.MapFrom(src => src.Fridge.Name));
        }
    }
}

