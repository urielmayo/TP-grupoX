using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using TPDDSBackend.Aplication.Commands;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Aplication.Services;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Queries
{
    public class GetCollaboratorQuery: IRequest<CustomResponse<GetCollaboratorResponse>>
    {
        public string CollaboratorId { get; set; }

        public GetCollaboratorQuery(string collaboratorId)
        {
            CollaboratorId = collaboratorId;
        }

    }

    public class GetCollaboratorQueryHandler : IRequestHandler<GetCollaboratorQuery, CustomResponse<GetCollaboratorResponse>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Collaborator> _userManager;
        private readonly IContributionRepository _contributionRepository;
        private readonly IAccumulatedPointsCalculator _accumulatedPointsCalculator;
        private readonly ICardRepository _cardRepository;
        public GetCollaboratorQueryHandler(IMapper mapper,
            UserManager<Collaborator> userManager,
            IContributionRepository contributionRepository,
            IAccumulatedPointsCalculator accumulatedPointsCalculator,
            ICardRepository cardRepository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _contributionRepository = contributionRepository;
            _accumulatedPointsCalculator = accumulatedPointsCalculator;
            _cardRepository = cardRepository;
        }

        public async Task<CustomResponse<GetCollaboratorResponse>> Handle(GetCollaboratorQuery query, CancellationToken ct)
        {
            var user = await _userManager.FindByIdAsync(query.CollaboratorId);

            if(user == null)
            {
               throw new ApiCustomException("usuario no encontrado", HttpStatusCode.NotFound);
            }
            var rol = await _userManager.GetRolesAsync(user);

            var contributions = await _contributionRepository.GetAllByCollaborador(user.Id);

            var accumulatedPoints = await _accumulatedPointsCalculator.CalculateAccumulatedPoints(contributions, user.Id);

            var destinationList = _mapper.Map<IList<ContributionByCollaboratorResponse>>(contributions);

            var card = await _cardRepository.GetCollaboratorCard(user.Id);

            var userResponse = new GetCollaboratorResponse()
            {
                Id = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName!,
                Rol = rol.FirstOrDefault(),
                Type = user.Discriminator,
                Contributions = destinationList,
                AccumulatedPoints = Math.Round(accumulatedPoints, 2), // Redondea a dos decimales
                CardCode = card?.Code,
                Address = user.Address
            };

            return new CustomResponse<GetCollaboratorResponse>("usuario encontrado", userResponse);

        }
    }
}
