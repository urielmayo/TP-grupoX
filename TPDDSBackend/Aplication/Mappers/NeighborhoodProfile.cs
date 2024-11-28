using AutoMapper;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Mappers
{
    public class NeighborhoodProfile : Profile
    {    
        public NeighborhoodProfile()
        {
            CreateMap<Neighborhood, GetNeighborhoodResponse>();
        }
    }
}
