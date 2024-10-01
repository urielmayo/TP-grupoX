using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Aplication.Managers;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Commands
{
    public class DeleteFoodCommand: IRequest<Unit>
    {
        public int FoodId { get; set; }

        public DeleteFoodCommand(int foodId)
        {
            FoodId = foodId;
        }
    }
    public class DeleteFoodCommandHandler : IRequestHandler<DeleteFoodCommand, Unit>
    {
        private readonly IManager<Food> _foodManager;
        private readonly IManager<FoodDelivery> _foodDeliveryManager;

        public DeleteFoodCommandHandler(IManager<Food> foodManager,
            IManager<FoodDelivery> foodDeliveryManager)
        {
            _foodManager = foodManager;
            _foodDeliveryManager = foodDeliveryManager;
        }

        public async Task<Unit> Handle(DeleteFoodCommand command, CancellationToken ct)
        {
            var food = await _foodManager.FindByIdAsync(command.FoodId);
            if (food == null)
                throw new ApiCustomException("Vianda no encontrada", HttpStatusCode.NotFound);


            //TODO: Revisar que no existan donaciones de vianda o contribucion de deliveries asociados.


            var result = await _foodManager.DeleteAsync(food);

            if (!result)
            {
                throw new ApiCustomException("Error eliminando la vianda", HttpStatusCode.InternalServerError);
            }
            return Unit.Value;
        }
    }
}
