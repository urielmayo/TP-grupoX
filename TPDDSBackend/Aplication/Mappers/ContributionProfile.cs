using AutoMapper;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Mappers
{
    public class ContributionProfile: Profile
    {
        public ContributionProfile()
        {
            CreateMap<OwnAFridgeContributionRequest, FridgeOwner>();

            CreateMap<FoodDeliveryContributionRequest, FoodDelivery>();

            CreateMap<Contribution,ContributionByCollaboratorResponse>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Discriminator));

            CreateMap<CreateBenefitRequest, Benefit>()
                 .ForMember(dest => dest.Image, opt => opt.Ignore());
        }
    }
}
