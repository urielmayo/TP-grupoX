using AutoMapper;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using TPDDSBackend.Domain.Enums;

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
            CreateMap<OpeningRequest, FridgeOpening>()
                .ForMember(dest => dest.OpeningFor, opt => opt.MapFrom(src => (OpeningFor)Enum.Parse(typeof(OpeningFor), src.OpeningFor)));

            CreateMap<CreateFridgeSubscriptionRequest, FridgeSubscription>()
                 .ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<FridgeSubscription, CreateFridgeSubscriptionResponse>()
                .ForMember(dest => dest.CommunicationMedia, opt => opt.MapFrom(src => src.CommunicationMediaDesired.Name));
        }
    }
}

