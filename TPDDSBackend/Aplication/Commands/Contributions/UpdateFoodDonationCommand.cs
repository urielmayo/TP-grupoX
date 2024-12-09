using AutoMapper;
using MediatR;
using System;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Constans;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Enums;
using TPDDSBackend.Infrastructure.Repositories;
using TPDDSBackend.Infrastructure.Services;

namespace TPDDSBackend.Aplication.Commands.Contributions
{
    public class UpdateFoodDonationCommand : IRequest<Unit>
    {
        public UpdateRequestContributionRequest Request { get; set; }

        public int ContributionId { get; set; }
        public UpdateFoodDonationCommand(UpdateRequestContributionRequest request, int contributionId) 
        { 
            Request = request;
            ContributionId = contributionId;
        }
    }

    public class UpdateFoodDonationCommandHandler : IRequestHandler<UpdateFoodDonationCommand, Unit>
    {
        private readonly IJwtFactory _jwtFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGenericRepository<FoodDonation> _foodDonationRepository;
        public UpdateFoodDonationCommandHandler(
            IJwtFactory jwtFactory,
            IHttpContextAccessor httpContextAccessor,
            IGenericRepository<FoodDonation> foodDonationRepository)
        {
            _jwtFactory = jwtFactory;
            _httpContextAccessor = httpContextAccessor;
            _foodDonationRepository = foodDonationRepository;
        }
        public async Task<Unit> Handle(UpdateFoodDonationCommand command, CancellationToken cancellationToken)
        {

            var donation = await _foodDonationRepository.GetById(command.ContributionId);

            if(donation == null)
            {
                throw new ApiCustomException("contribucion no encontrada", HttpStatusCode.NotFound);
            }

            if(donation.Status == ContributionStatus.Requested &&
                donation.CreatedAt.AddHours(ServiceConstans.RequestExpirationInHours) < DateTime.UtcNow)
            {
                donation.Status = ContributionStatus.OverdueRequest;
                _foodDonationRepository.Update(donation);
                throw new ApiCustomException(ServiceConstans.UpdateDeniedMessageByExpires, HttpStatusCode.Forbidden);
            }

            var jwt = _httpContextAccessor.HttpContext.Request.Headers.Authorization;

            (string collaboradorId, _) = _jwtFactory.GetClaims(jwt);

            if (donation.CollaboratorId != collaboradorId)
            {
                throw new ApiCustomException(ServiceConstans.UpdateDeniedMessage, HttpStatusCode.Forbidden);
            }

            donation.Status = (ContributionStatus)Enum.Parse(typeof(ContributionStatus), command.Request.NewState);
            _foodDonationRepository.Update(donation);

            return Unit.Value;
        }
    }
}
