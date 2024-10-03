using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Aplication.Managers;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Queries
{
    public class GetFoodQuery: IRequest<CustomResponse<GetFoodResponse>>
    {
        public int FoodId { get; set; }

        public GetFoodQuery(int fridgeId)
        {
            FoodId = fridgeId;
        }

    }

    public class GetFoodQueryHandler : IRequestHandler<GetFoodQuery, CustomResponse<GetFoodResponse>>
    {
        private readonly IGenericRepository<Food> _foodManager;
        public GetFoodQueryHandler(IGenericRepository<Food> foodManager)
        {
            _foodManager = foodManager;
        }

        public async Task<CustomResponse<GetFoodResponse>> Handle(GetFoodQuery query, CancellationToken ct)
        {
            var food = await _foodManager.GetById(query.FoodId);

            if(food == null)
            {
               throw new ApiCustomException("Vianda no encontrada", HttpStatusCode.NotFound);
            }

            var foodResponse = new GetFoodResponse()
            {
                Id = food.Id,
                Description = food.Description,
                Calories = food.Calories,
                DonationDate = food.DonationDate,
                DoneeId = food.DoneeId,
                ExpirationDate = food.ExpirationDate,
                FridgeId = food.FridgeId,
                StateId = food.StateId,
                Weight = food.Weight
            };

            return new CustomResponse<GetFoodResponse>("Vianda encontrada", foodResponse);
            
        }
    }
}
