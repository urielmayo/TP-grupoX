using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Commands
{
    public class DeleteFridgeCommand: IRequest<Unit>
    {
        public int FridgeId { get; set; }

        public DeleteFridgeCommand(int fridgeId)
        {
            FridgeId = fridgeId;
        }
    }
    public class DeleteFridgeCommandHandler : IRequestHandler<DeleteFridgeCommand, Unit>
    {
        private readonly IGenericRepository<Fridge> _fridgeRepository;
        public DeleteFridgeCommandHandler(IGenericRepository<Fridge> fridgeRepository)
        {
            _fridgeRepository = fridgeRepository;
        }

        public async Task<Unit> Handle(DeleteFridgeCommand command, CancellationToken ct)
        {
            var fridge = await _fridgeRepository.GetById(command.FridgeId);

            if (fridge == null)
            {
                throw new ApiCustomException("Heladera no encontrada", HttpStatusCode.NotFound);
            }

            var result = await _fridgeRepository.Delete(fridge.Id);
            if (!result)
            {
                throw new ApiCustomException("Error eliminando Heladera", HttpStatusCode.InternalServerError);
            }
            return Unit.Value;
        }
    }
}
