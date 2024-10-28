using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using TPDDSBackend.Aplication.Commands;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Aplication.Services.Strategies;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Interfaces;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Queries
{
    public class GetContributionQuery: IRequest<CustomResponse<ContributionResponse>>
    {
        public int ContributionId { get; set; }

        public GetContributionQuery(int contributionId)
        {
            ContributionId = contributionId;
        }

    }

    public class GetContributionQueryHandler : IRequestHandler<GetContributionQuery, CustomResponse<ContributionResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Contribution> _contributionRepository;
        private readonly IGenericRepository<MoneyDonation> _moneyDonationRepository;
        private readonly Dictionary<string, IContributionStrategy> _strategies;
        public GetContributionQueryHandler(IMapper mapper,
             IGenericRepository<MoneyDonation> moneyDonationRepository,
             IGenericRepository<Contribution> contributionRepository,
             Dictionary<string, IContributionStrategy> strategies)
        {
            _mapper = mapper;
            _contributionRepository = contributionRepository;
            _moneyDonationRepository = moneyDonationRepository;
            _strategies = strategies;
        }

        public async Task<CustomResponse<ContributionResponse>> Handle(GetContributionQuery query, CancellationToken ct)
        {
            var contribution = await _contributionRepository.GetById(query.ContributionId);
            if(contribution == null)
            {
               throw new ApiCustomException("contribucion no encontrada", HttpStatusCode.NotFound);
            }
            if (!_strategies.TryGetValue(contribution.Discriminator, out var strategy))
                throw new InvalidOperationException($"Strategy for type '{contribution.Discriminator}' not found.");

            var response = new ContributionResponse
            {
                Id = contribution.Id,
                Type = contribution.Discriminator,
                CreatedAt = contribution.CreatedAt,
                Attributes = strategy.GetAttributes(contribution)
            };
            return new CustomResponse<ContributionResponse>("contribucion encontrada", response);
        }
    }
}
