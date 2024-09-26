using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Aplication.Managers;
using TPDDSBackend.Domain.Entitites;

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
        private readonly IMapper _mapper;
        private readonly IFridgeManager _fridgeManager;
        public DeleteFridgeCommandHandler(IMapper mapper,
            IFridgeManager fridgeManager)
        {
            _mapper = mapper;
            _fridgeManager = fridgeManager;
        }

        public async Task<Unit> Handle(DeleteFridgeCommand command, CancellationToken ct)
        {
            var fridge = await _fridgeManager.FindByIdAsync(command.FridgeId);

            if (fridge == null)
            {
                throw new ApiCustomException("Heladera no encontrada", HttpStatusCode.NotFound);
            }

            var result = await _fridgeManager.DeleteAsync(fridge);

            if (!result)
            {
                throw new ApiCustomException("Error eliminando Heladera", HttpStatusCode.InternalServerError);
            }
            return Unit.Value;
        }
    }
}
