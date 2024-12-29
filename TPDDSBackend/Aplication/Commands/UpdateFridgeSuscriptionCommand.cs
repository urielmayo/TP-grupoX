using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Enums;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Commands
{
    public class UpdateFridgeSuscriptionCommand : IRequest<Unit>
    {
        public UpdateFridgeSuscriptionRequest Request { get; set; }
        public int Id { get; set; }
        public UpdateFridgeSuscriptionCommand(UpdateFridgeSuscriptionRequest request, int id)
        {
            Request = request;
            Id = id;
        }
    }

    public class UpdateFridgeSuscriptionCommandHandler : IRequestHandler<UpdateFridgeSuscriptionCommand, Unit>
    {
        private readonly IGenericRepository<FridgeSubscription> _fridgeSuscriptionRepository;
        private readonly ICommunicationMediaRepository _communicationMediaRepository;

        public UpdateFridgeSuscriptionCommandHandler(
            IGenericRepository<FridgeSubscription> fridgeSuscriptionRepository,
            ICommunicationMediaRepository communicationMediaRepository)
        {
            _fridgeSuscriptionRepository = fridgeSuscriptionRepository;
            _communicationMediaRepository = communicationMediaRepository;
        }

        public async Task<Unit> Handle(UpdateFridgeSuscriptionCommand command, CancellationToken ct)
        {
            var entity = await _fridgeSuscriptionRepository.GetById(command.Id);

            if (entity is null)
            {
                throw new ApiCustomException("No se encontro la suscripcion", HttpStatusCode.NotFound);
            }

            if (command?.Request?.FullFoodsQuantity is not null)
                entity.FullFoodsQuantity = command.Request.FullFoodsQuantity;


            if (command?.Request?.AvailableFoodsQuantity is not null)
                entity.AvailableFoodsQuantity = command.Request.AvailableFoodsQuantity;

            if (command?.Request?.IncidentSubscription is not null)
                entity.IncidentSubscription = command.Request.IncidentSubscription;

            if (command?.Request?.CommunicationMedia is not null)
            {
                var communicationMediaName = (CommunicationMediaName)Enum.Parse(typeof(CommunicationMediaName), command.Request.CommunicationMedia);

                var media = await _communicationMediaRepository.GetByName(communicationMediaName);

                entity.CommunicationMediaId = media.Id;
            }
            _fridgeSuscriptionRepository.Update(entity);
            
            return Unit.Value;
        }
    }
}


