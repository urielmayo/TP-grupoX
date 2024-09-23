using AutoMapper;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Mappers
{
    public class FoodProfile : Profile
    {
        public FoodProfile()
        {
            CreateMap<CreateFoodRequest, Food>();
            //CreateMap<UpdateFoodRequest, Food>();
        }
    }
}

