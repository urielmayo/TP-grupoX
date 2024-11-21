using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Commands.Fridges
{
    public class RegisterTemperatureFridgeCommand : IRequest<Unit>
    {
        public float Temperature { get; set; }
        public int FridgeId { get; set; }
        public RegisterTemperatureFridgeCommand(int fridgeId, float temperature)
        {
            Temperature = temperature;
            FridgeId = fridgeId;
        }
    }

    public class RegisterTemperatureFridgeCommandHandler : IRequestHandler<RegisterTemperatureFridgeCommand, Unit>
    {
        private readonly IGenericRepository<Fridge> _fridgeRepository;


        public RegisterTemperatureFridgeCommandHandler(IGenericRepository<Fridge> fridgeRepository)
        {
            _fridgeRepository = fridgeRepository;
        }

        public async Task<Unit> Handle(RegisterTemperatureFridgeCommand command, CancellationToken ct)
        {
            var fridge = await _fridgeRepository.GetById(command.FridgeId);
      
           if(fridge == null)
            {
                throw new ApiCustomException("No se ha encontrado la heladera", HttpStatusCode.NotFound);
            }

            fridge.LastTemperature = command.Temperature;

            _fridgeRepository.Update(fridge);

            return Unit.Value;
        }
    }
}


