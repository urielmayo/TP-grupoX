using AutoMapper;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Mappers
{
    public class PersonInVulnerableSituationProfile: Profile
    {
        public PersonInVulnerableSituationProfile()
        {
            CreateMap<PersonRegistrationContributionRequest, PersonInVulnerableSituation>()
                 .ForMember(dest => dest.DocumentType, opt => opt.Ignore());

            CreateMap<PersonRegistrationContributionRequest, VulnerablePersonCard>()
                .ForMember(dest => dest.Card.Code, opt => opt.MapFrom(src => src.CardCode));
        }
    }
}
