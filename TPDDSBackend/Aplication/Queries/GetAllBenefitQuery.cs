using AutoMapper;
using MediatR;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Queries
{
    public class GetAllBenefitQuery : IRequest<CustomResponse<GetAllBenefitsResponse>>
    {

    }

    public class GetAllBenefitQueryHandler : IRequestHandler<GetAllBenefitQuery, CustomResponse<GetAllBenefitsResponse>>
    {
        private readonly IGenericRepository<Benefit> _benefitRepository;
        private readonly IMapper _mapper;
        public GetAllBenefitQueryHandler(IGenericRepository<Benefit> benefitRepository, IMapper mapper)
        {
            _benefitRepository = benefitRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponse<GetAllBenefitsResponse>> Handle(GetAllBenefitQuery query, CancellationToken ct)
        {
            var benefits = _benefitRepository.GetAll().ToList();

            var benefitResponses= _mapper.Map<IList<GetBenefitResponse>>(benefits);


            return new CustomResponse<GetAllBenefitsResponse>("Benficios encontrados", new GetAllBenefitsResponse(benefitResponses));       
        }
    }
}
