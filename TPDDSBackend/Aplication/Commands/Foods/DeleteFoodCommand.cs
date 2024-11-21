using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Aplication.Managers;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Commands.Foods
{
    public class DeleteFoodCommand : IRequest<Unit>
    {
        public int FoodId { get; set; }

        public DeleteFoodCommand(int foodId)
        {
            FoodId = foodId;
        }
    }
    public class DeleteFoodCommandHandler : IRequestHandler<DeleteFoodCommand, Unit>
    {
        private readonly IGenericRepository<Food> _foodManager;

        public DeleteFoodCommandHandler(IGenericRepository<Food> foodManager)
        {
            _foodManager = foodManager;
        }

        public async Task<Unit> Handle(DeleteFoodCommand command, CancellationToken ct)
        {
            var food = await _foodManager.GetById(command.FoodId);
            if (food == null)
                throw new ApiCustomException("Vianda no encontrada", HttpStatusCode.NotFound);


            //TODO: Revisar que no existan donaciones de vianda o contribucion de deliveries asociados.


            var result = await _foodManager.Delete(food.Id);

            if (!result)
            {
                throw new ApiCustomException("Error eliminando la vianda", HttpStatusCode.InternalServerError);
            }
            return Unit.Value;
        }
    }
}
