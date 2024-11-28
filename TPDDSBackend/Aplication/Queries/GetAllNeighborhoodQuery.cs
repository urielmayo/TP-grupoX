using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Queries
{
    public class GetAllNeighborhoodQuery : IRequest<CustomResponse<GetAllNeighborhoodResponse>>
    {

    }

    public class GetAllNeighborhoodQueryHandler : IRequestHandler<GetAllNeighborhoodQuery, CustomResponse<GetAllNeighborhoodResponse>>
    {
        private readonly IGenericRepository<Neighborhood> _neighborhoodRepository;
        private readonly IMapper _mapper;
        public GetAllNeighborhoodQueryHandler(IGenericRepository<Neighborhood> neighborhoodRepository, IMapper mapper)
        {
            _neighborhoodRepository = neighborhoodRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponse<GetAllNeighborhoodResponse>> Handle(GetAllNeighborhoodQuery query, CancellationToken ct)
        {
            var neighborhoods = _neighborhoodRepository.GetAll().ToList();

            var neighborhoodssDto = _mapper.Map<IList<GetNeighborhoodResponse>>(neighborhoods);


            return new CustomResponse<GetAllNeighborhoodResponse>("Barrios encontrados", new GetAllNeighborhoodResponse(neighborhoodssDto));       
        }
    }
}
