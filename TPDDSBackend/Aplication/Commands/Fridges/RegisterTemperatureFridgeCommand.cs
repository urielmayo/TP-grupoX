using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Enums;
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
        private readonly IGenericRepository<FridgeAlert> _fridgeAlertRepository;


        public RegisterTemperatureFridgeCommandHandler(IGenericRepository<Fridge> fridgeRepository,
            IGenericRepository<FridgeAlert> fridgeAlertRepository)
        {
            _fridgeRepository = fridgeRepository;
            _fridgeAlertRepository = fridgeAlertRepository;
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

            if (fridge.LastTemperature < fridge.Model.MinTemperature ||
                fridge.LastTemperature > fridge.Model.MaxTemperature) 
            {
                fridge.Active = false;
                _fridgeRepository.Update(fridge);

                var alertFridge = new FridgeAlert()
                {
                    Date = DateTime.UtcNow,
                    FridgeId = fridge.Id,
                    Type = TypeFridgeAlert.Temperature,
                };
                await _fridgeAlertRepository.Insert(alertFridge);
            }

            return Unit.Value;
        }
    }
}


