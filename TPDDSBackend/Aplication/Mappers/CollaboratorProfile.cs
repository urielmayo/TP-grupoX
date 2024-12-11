using AutoMapper;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Mappers
{
    public class CollaboratorProfile: Profile
    {
        public CollaboratorProfile()
        {
            CreateMap<CreateHumanPersonRequest, HumanPerson>();
            CreateMap<CreateLegalPersonRequest, LegalPerson>();
            CreateMap<Neighborhood, LegalPerson>();
        }
    }
}
