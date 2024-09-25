using AutoMapper;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Mappers
{
    public class ContributionProfile: Profile
    {
        public ContributionProfile()
        {
            CreateMap<OwnAFridgeContributionRequest, FridgeOwner>();
        }
    }
}
