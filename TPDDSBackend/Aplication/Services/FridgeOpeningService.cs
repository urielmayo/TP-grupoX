using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Commands.Contributions;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Aplication.Services.Strategies;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Enums;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Services
{
    public class FridgeOpeningService : IFridgeOpeningService
    {
        private readonly IGenericRepository<FridgeOpening> _fridgeOpeningRepository;
        private readonly IContributionRepository _contributionRepository;
        private readonly IMediator _mediator;
        private readonly ICardRepository _cardRepository;
        public FridgeOpeningService(
            IGenericRepository<FridgeOpening> fridgeOpeningRepository,  
            IContributionRepository contributionRepository,
            ICardRepository cardRepository,
            IMediator mediator)
        {
            _mediator = mediator;
            _fridgeOpeningRepository = fridgeOpeningRepository;
            _contributionRepository = contributionRepository;
            _cardRepository = cardRepository;
        }
        public async Task RegisterOpeningForCollaborator(int fridgeId, string collaboratorId, int cardId, OpeningFor openingFor)
        {
            var entity = new FridgeOpening()
            {
                CardId = cardId,
                FridgeId = fridgeId,
                OpeningFor = openingFor
            };

            var contribution = await _contributionRepository.GetRequestedContribution(collaboratorId, fridgeId);

            if (contribution == null)
                throw new ApiCustomException("No se encontro una solicitud para esa heladera", HttpStatusCode.NotFound);

            var request = new UpdateRequestContributionRequest() { NewState = "Done" };
            if (contribution.Discriminator == "FoodDonation")
            {
                await _mediator.Send(new UpdateFoodDonationCommand(request, contribution.Id));
            }
            else
            {
                await _mediator.Send(new UpdateFoodDeliveryCommand(request, contribution.Id));
            }

            await _fridgeOpeningRepository.Insert(entity);
        }

        public async Task RegisterOpeningForVulnerablePerson(int fridgeId, PersonInVulnerableSituation person, int cardId, OpeningFor openingFor)
        {
            int usesByDay = await _cardRepository.GetNumberOfOpeningsForCurrentDay(cardId);

            int maxUses = 4 + (person.MinorsInCare * 2);

            if (usesByDay > maxUses)
            {
                throw new ApiCustomException("No se puede usar mas esa tarjeta por el dia de hoy", HttpStatusCode.UnprocessableContent);
            }

            var entity = new FridgeOpening()
            {
                CardId = cardId,
                FridgeId = fridgeId,
                OpeningFor = openingFor
            };
            await _fridgeOpeningRepository.Insert(entity);
        }
    }
}
