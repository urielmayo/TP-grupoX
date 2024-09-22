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
            CreateMap<PersonRegistrationContributionRequest, PersonInVulnerableSituation>();

            CreateMap<PersonRegistrationContributionRequest, Card>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.CardCode));
        }
    }
}
