using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Aplication.Services;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;
using TPDDSBackend.Infrastructure.Services;

namespace TPDDSBackend.Aplication.Commands.Collaborators
{
    public class ExchangeBenefitCommand : IRequest<CustomResponse<Contribution>>
    {
        public ExchangeBenefitRequest Request { get; set; }
        public ExchangeBenefitCommand(ExchangeBenefitRequest request)
        {
            Request = request;
        }
    }

    public class ExchangeBenefitCommandHandler : IRequestHandler<ExchangeBenefitCommand, CustomResponse<Contribution>>
    {
        private readonly IGenericRepository<BenefitExchange> _benefitExcahngeRepository;
        private readonly IGenericRepository<Benefit> _benefitRepository;
        private readonly UserManager<Collaborator> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAccumulatedPointsCalculator _accumulatedPointsCalculator;
        private readonly IContributionRepository _contributionRepository;
        public ExchangeBenefitCommandHandler(IGenericRepository<BenefitExchange> benefitExcahngeRepository,
            IGenericRepository<Benefit> benefitRepository,
            UserManager<Collaborator> userManager,
            IJwtFactory jwtFactory,
            IHttpContextAccessor httpContextAccessor,
            IAccumulatedPointsCalculator accumulatedPointsCalculator,
            IContributionRepository contributionRepository)
        {
            _benefitExcahngeRepository = benefitExcahngeRepository;
            _benefitRepository = benefitRepository;
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _httpContextAccessor = httpContextAccessor;
            _accumulatedPointsCalculator = accumulatedPointsCalculator;
            _contributionRepository = contributionRepository;
        }

        public async Task<CustomResponse<Contribution>> Handle(ExchangeBenefitCommand command, CancellationToken ct)
        {
            var benefit = await _benefitRepository.GetById(command.Request.BenefitId);

            if (benefit == null)
            {
                throw new ApiCustomException("Beneficio no encontrado", HttpStatusCode.NotFound);
            }

            var jwt = _httpContextAccessor.HttpContext.Request.Headers.Authorization;

            (string collaboradorId, _) = _jwtFactory.GetClaims(jwt);

            var user = _userManager.FindByIdAsync(collaboradorId);

            var contributions = await _contributionRepository.GetAllByCollaborador(collaboradorId);

            decimal accumulatedPoints = await _accumulatedPointsCalculator.CalculateAccumulatedPoints(contributions);

            if(accumulatedPoints >= benefit.RequiredPoints)
            {
                throw new ApiCustomException("No tienes puntos suficientes para cambiar ese beneficio", HttpStatusCode.BadRequest);
            }

            var benefitExchange = new BenefitExchange()
            {
                BenefitId = benefit.Id,
                UserId = collaboradorId
            };

            await _benefitExcahngeRepository.Insert(benefitExchange);

            return new CustomResponse<Contribution>("Se ha canjeado el producto o servicio correctamente");
        }
    }
}


