using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Constans;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;
using TPDDSBackend.Infrastructure.Services;

namespace TPDDSBackend.Aplication.Commands.Contributions
{
    public class OwnAFridgeContributionCommand : IRequest<CustomResponse<Contribution>>
    {
        public CreateFridgeRequest Request { get; set; }
        public OwnAFridgeContributionCommand(CreateFridgeRequest request)
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

        public OwnAFridgeContributionCommandHandler(
            IMapper mapper,
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

            var fridge = _mapper.Map<Fridge>(command.Request);
            fridge.SetUpAt = DateTime.SpecifyKind(fridge.SetUpAt, DateTimeKind.Utc);

            var fridgeSaved = await _fridgeRepository.Insert(fridge);


            var contribution = new FridgeOwner()
            {
                FridgeId = fridgeSaved.Id,
                CollaboratorId = collaboradorId,
                Date = DateTime.UtcNow,
            };

            var contributionSaved = await _fridgeOwnerRepository.Insert(contribution);
  

            return new CustomResponse<Contribution>(ServiceConstans.MessageSuccessDonation, contributionSaved);
        }
    }
}
