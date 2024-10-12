using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;
using TPDDSBackend.Infrastructure.Services;

namespace TPDDSBackend.Aplication.Commands.Contributions
{
    public class OwnAFridgeContributionCommand : IRequest<CustomResponse<Contribution>>
    {
        public OwnAFridgeContributionRequest Request { get; set; }
        public OwnAFridgeContributionCommand(OwnAFridgeContributionRequest request)
        {
            Request = request;
        }
    }
    public class OwnAFridgeContributionCommandHandler : IRequestHandler<OwnAFridgeContributionCommand, CustomResponse<Contribution>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Collaborator> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGenericRepository<FridgeOwner> _fridgeOwnerRepository;
        private readonly IGenericRepository<Fridge> _fridgeRepository;

        public OwnAFridgeContributionCommandHandler(IMapper mapper,
                        IJwtFactory jwtFactory,
            IHttpContextAccessor httpContextAccessor,
            IGenericRepository<FridgeOwner> fridgeOwnerRepository,
            IGenericRepository<Fridge> fridgeRepository)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _jwtFactory = jwtFactory;
            _fridgeRepository = fridgeRepository;
            _fridgeOwnerRepository = fridgeOwnerRepository;
        }

        public async Task<CustomResponse<Contribution>> Handle(OwnAFridgeContributionCommand command, CancellationToken ct)
        {
            
            var jwt = _httpContextAccessor.HttpContext.Request.Headers.Authorization;

            (string collaboradorId, _) = _jwtFactory.GetClaims(jwt);

            var contribution = _mapper.Map<FridgeOwner>(command.Request);

            var fridge = await _fridgeRepository.GetById(contribution.FridgeId);

            if (fridge == null) 
            {
                throw new ApiCustomException("No existe una heladera con ese id", HttpStatusCode.BadRequest);
            }

            contribution.Date = DateTime.UtcNow;
            contribution.CollaboratorId = collaboradorId;

            await _fridgeOwnerRepository.Insert(contribution);

            return new CustomResponse<Contribution>("Se ha asociado la heladera con el colaborador", contribution);
        }
    }
}
