using AutoMapper;
using System.Globalization;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Domain.Entitites;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TPDDSBackend.Aplication.Mappers
{
    public class FoodProfile : Profile
    {
        public FoodProfile()
        {
            CreateMap<CreateFoodRequest, Food>();
            CreateMap<UpdateFoodRequest, Food>();
            CreateMap<FoodContributionRequest, Food>()
                .ForMember(dest => dest.DonationDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.StateId, opt => opt.MapFrom(src => 1))
                .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => DateTime.ParseExact(src.ExpirationDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal)));

        }
    }
}

