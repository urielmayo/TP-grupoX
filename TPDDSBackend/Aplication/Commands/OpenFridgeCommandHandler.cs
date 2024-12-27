using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Commands.Contributions;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Aplication.Services.Strategies;
using TPDDSBackend.Constans;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Enums;
using TPDDSBackend.Infrastructure.Repositories;
using TPDDSBackend.Infrastructure.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TPDDSBackend.Aplication.Commands.Fridges
{
    public class OpenFridgeCommand : IRequest<Unit>
    {
        public OpeningRequest Request { get; set; }
        public OpenFridgeCommand(OpeningRequest request)
        {
            Request = request;
        }
    }

    public class OpenFridgeCommandHandler : IRequestHandler<OpenFridgeCommand, Unit>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IGenericRepository<Fridge> _fridgeRepository;
        private readonly IJwtFactory _jwtFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IFridgeOpeningService _fridgeOpeningService;
        private readonly IGenericRepository<PersonInVulnerableSituation> _personRepository;

        public OpenFridgeCommandHandler(    
            ICardRepository cardRepository,
            IGenericRepository<Fridge> fridgeRepository,
            IJwtFactory jwtFactory,
            IHttpContextAccessor httpContextAccessor,
            IFridgeOpeningService fridgeOpeningService,
            IGenericRepository<PersonInVulnerableSituation> personRepository)
        {
            _fridgeRepository = fridgeRepository;
            _cardRepository = cardRepository;    
            _jwtFactory = jwtFactory;
            _httpContextAccessor = httpContextAccessor;
            _fridgeOpeningService = fridgeOpeningService;
            _personRepository = personRepository;
        }

        public async Task<Unit> Handle(OpenFridgeCommand command, CancellationToken ct)
        {
            var fridge = await _fridgeRepository.GetById(command.Request.FridgeId);

            if (fridge == null)
                throw new ApiCustomException("Heladera no encontrada", HttpStatusCode.NotFound);

            var jwt = _httpContextAccessor.HttpContext.Request.Headers.Authorization;
            (string collaboradorId, _) = _jwtFactory.GetClaims(jwt);

            var openingForEnum =  (OpeningFor)Enum.Parse(typeof(OpeningFor), command.Request.OpeningFor);

            if (command.Request.PersonInVulnerableSituationId is not null)
            {
                var person = await _personRepository.GetById((int)command.Request.PersonInVulnerableSituationId);
                if(person is null)
                    throw new ApiCustomException("la persona vulnerable solo puede retirar vianda para comer", HttpStatusCode.NotFound);

                if (openingForEnum != OpeningFor.TakeOutFood)
                    throw new ApiCustomException("la persona vulnerable solo puede retirar vianda para comer", HttpStatusCode.UnprocessableContent);

                var card = await _cardRepository.GetPersonCard(person.Id);
                
                if(card == null)
                     throw new ApiCustomException("La persona debe tener una tarjeta asociada", HttpStatusCode.UnprocessableContent);
                
                await _fridgeOpeningService.RegisterOpeningForVulnerablePerson(fridge.Id, person, 
                    card.Id, openingForEnum);
            }
            else
            {
                var card = await _cardRepository.GetCollaboratorCard(collaboradorId);

                if (card == null)
                {
                    throw new ApiCustomException("el colaborador debe tener una tarjeta asociada", HttpStatusCode.UnprocessableContent);
                }
                await _fridgeOpeningService.RegisterOpeningForCollaborator(fridge.Id, collaboradorId, 
                    card.Id, openingForEnum);
            }
            return Unit.Value;
        }
    }
}


