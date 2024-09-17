using AutoMapper;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Mappers
{
    public class PersonInVulnerableSituationProfile: Profile
    {
        public PersonInVulnerableSituationProfile()
        {
            CreateMap<CreatePersonInVulnerableSituationRequest, PersonInVulnerableSituation>();
        }
    }
}
