using AutoMapper;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Mappers
{
    public class FridgeProfile : Profile
    {
        public FridgeProfile()
        {
            CreateMap<CreateFridgeRequest, Fridge>();
        }
    }
}

