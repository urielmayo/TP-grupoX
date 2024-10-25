using AutoMapper;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Mappers
{
    public class ContributionProfile: Profile
    {
        public ContributionProfile()
        {
            CreateMap<OwnAFridgeContributionRequest, FridgeOwner>();

            CreateMap<FoodContributionRequest, FoodDonation>();

            CreateMap<FoodDeliveryContributionRequest, FoodDelivery>();



            CreateMap<Contribution,GetContributionResponse>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Discriminator));
        }
    }
}
