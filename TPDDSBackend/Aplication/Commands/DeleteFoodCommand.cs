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
        private readonly IMapper _mapper;
        private readonly IManager<Food> _foodManager;
        public DeleteFoodCommandHandler(IMapper mapper,
            IManager<Food> foodManager)
        {
            _mapper = mapper;
            _foodManager = foodManager;
        }

        public async Task<Unit> Handle(DeleteFoodCommand command, CancellationToken ct)
        {
            var fridge = await _foodManager.FindByIdAsync(command.FoodId);

            if (fridge == null)
            {
                throw new ApiCustomException("Vianda no encontrada", HttpStatusCode.NotFound);
            }

            //TODO: Revisar si hay validaciones previas antes de eliminar las viandas.

            var result = await _foodManager.DeleteAsync(fridge);

            if (!result)
            {
                throw new ApiCustomException("Error eliminando la vianda", HttpStatusCode.InternalServerError);
            }
            return Unit.Value;
        }
    }
}
