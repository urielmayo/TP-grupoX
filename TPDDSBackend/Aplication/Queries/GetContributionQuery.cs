using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using TPDDSBackend.Aplication.Commands;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Queries
{
    public class GetContributionQuery: IRequest<CustomResponse<MoneyDonation>>
    {
        public int ContributionId { get; set; }

        public GetContributionQuery(int contributionId)
        {
            ContributionId = contributionId;
        }

    }

    public class GetContributionQueryHandler : IRequestHandler<GetContributionQuery, CustomResponse<MoneyDonation>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Contribution> _contributionRepository;
        private readonly IGenericRepository<MoneyDonation> _moneyDonationRepository;
        public GetContributionQueryHandler(IMapper mapper,
             IGenericRepository<MoneyDonation> moneyDonationRepository,
             IGenericRepository<Contribution> contributionRepository)
        {
            _mapper = mapper;
            _contributionRepository = contributionRepository;
            _moneyDonationRepository = moneyDonationRepository;        
         }

        public async Task<CustomResponse<MoneyDonation>> Handle(GetContributionQuery query, CancellationToken ct)
        {
            var contribution = await _contributionRepository.GetById(query.ContributionId);
            if(contribution == null)
            {
               throw new ApiCustomException("contribucion no encontrado", HttpStatusCode.NotFound);
            }

            switch(contribution.Discriminator)
            {
                case "MoneyDonation":
                    var moneyDonation = await _moneyDonationRepository.GetById(query.ContributionId);
                    return new CustomResponse<MoneyDonation>("usuario encontrado", moneyDonation);
                default:
                    return new CustomResponse<MoneyDonation>("usuario encontrado");

            };
            
        }
    }
}
