using AutoMapper;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Mappers
{
    public class BenefitProfile : Profile
    {    
        public BenefitProfile()
        {
            CreateMap<Benefit, GetBenefitResponse>()
                  .ForMember(dest => dest.CollaboratorId, opt => opt.MapFrom(src => src.CollaboratorId));
        }
    }
}
