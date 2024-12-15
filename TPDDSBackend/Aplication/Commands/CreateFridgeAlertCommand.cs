using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Enums;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Commands.Fridges
{
    public class CreateFridgeAlertCommand : IRequest<Unit>
    {
        public CreateFridgeAlertRequest Request { get; set; }
        public CreateFridgeAlertCommand(CreateFridgeAlertRequest request)
        {
            Request = request;
        }
    }

    public class CreateFridgeAlertCommandHandler : IRequestHandler<CreateFridgeAlertCommand, Unit>
    { 
        private readonly IGenericRepository<FridgeAlert> _alertFridgeRepository;
        private readonly IGenericRepository<Fridge> _fridgeRepository;

        public CreateFridgeAlertCommandHandler(
            IGenericRepository<FridgeAlert> alertFridgeRepository,
            IGenericRepository<Fridge> fridgeRepository)
        {           
            _fridgeRepository = fridgeRepository;
            _alertFridgeRepository = alertFridgeRepository;
        }

        public async Task<Unit> Handle(CreateFridgeAlertCommand command, CancellationToken ct)
        {
            var fridge = await _fridgeRepository.GetById(command.Request.FridgeId) ?? throw new ApiCustomException("Heladera no encontrada", HttpStatusCode.NotFound);
            fridge.Active = false;
            _fridgeRepository.Update(fridge);

            var alertFridge = new FridgeAlert()
            {
                Date = DateTime.UtcNow,
                FridgeId = command.Request.FridgeId,
                Type = (TypeFridgeAlert)Enum.Parse(typeof(TypeFridgeAlert), command.Request.Type)
            };
            await _alertFridgeRepository.Insert(alertFridge);

            return Unit.Value;
        }
    }
}


