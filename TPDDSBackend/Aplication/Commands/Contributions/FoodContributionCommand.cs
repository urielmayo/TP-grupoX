using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Constans;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Enums;
using TPDDSBackend.Infrastructure.Repositories;
using TPDDSBackend.Infrastructure.Services;

namespace TPDDSBackend.Aplication.Commands.Contributions
{
    public class FoodContributionCommand: IRequest<CustomResponse<Contribution>>
    {
        public FoodContributionRequest Request { get; set; }
        public FoodContributionCommand(FoodContributionRequest request) 
        { 
            Request = request;
        }
    }

    public class FoodContributionCommandHandler : IRequestHandler<FoodContributionCommand, CustomResponse<Contribution>>
    {
        private readonly IMapper _mapper;
        private readonly IJwtFactory _jwtFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGenericRepository<FoodDonation> _foodDonationRepository;
        private readonly IGenericRepository<PersonInVulnerableSituation> _personRepository;
        private readonly IGenericRepository<Food> _foodRepository;
        private readonly UserManager<Collaborator> _userManager;
        public FoodContributionCommandHandler(IMapper mapper,
            IJwtFactory jwtFactory,
            IHttpContextAccessor httpContextAccessor,
            IGenericRepository<PersonInVulnerableSituation> personRepository,
            IGenericRepository<Food> foodRepository,
            IGenericRepository<FoodDonation> foodDonationRepository,
            UserManager<Collaborator> userManager)
        {
            _mapper = mapper;
            _jwtFactory = jwtFactory;
            _httpContextAccessor = httpContextAccessor;
            _foodDonationRepository = foodDonationRepository;
            _foodRepository = foodRepository;
            _personRepository = personRepository;
            _userManager = userManager;
        }
        public async Task<CustomResponse<Contribution>> Handle(FoodContributionCommand command, CancellationToken cancellationToken)
        {
            var food = _mapper.Map<Food>(command.Request);
            food.ExpirationDate = DateTime.SpecifyKind(food.ExpirationDate, DateTimeKind.Utc);
            var saved = await _foodRepository.Insert(food);

            var jwt = _httpContextAccessor.HttpContext.Request.Headers.Authorization;

            (string collaboradorId, _) = _jwtFactory.GetClaims(jwt);

            var collaborator = await _userManager.FindByIdAsync(collaboradorId);

            if (collaborator?.Address is null)
                throw new ApiCustomException(ServiceConstans.AddressRequiredMessage, HttpStatusCode.BadRequest);

            var foodDonation = new FoodDonation()
            {
                CollaboratorId = collaboradorId,
                FoodId = saved.Id,
                Date = DateTime.UtcNow,
                Status = ContributionStatus.Requested            
            };

            await _foodDonationRepository.Insert(foodDonation);

            return new CustomResponse<Contribution>(ServiceConstans.MessageSuccessDonation);
        }
    }
}
