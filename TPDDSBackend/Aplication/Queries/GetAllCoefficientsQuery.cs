﻿using AutoMapper;
using MediatR;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Queries
{
    public class GetAllCoefficientsQuery : IRequest<CustomResponse<GetAllCoefficientsResponse>>
    {

    }

    public class GetAllCoefficientsQueryHandler : IRequestHandler<GetAllCoefficientsQuery, CustomResponse<GetAllCoefficientsResponse>>
    {
        private readonly IGenericRepository<BenefitCoefficients> _coefficientsRepository;
        private readonly IMapper _mapper;
        public GetAllCoefficientsQueryHandler(IGenericRepository<BenefitCoefficients> coefficientsRepository, IMapper mapper)
        {
            _coefficientsRepository = coefficientsRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponse<GetAllCoefficientsResponse>> Handle(GetAllCoefficientsQuery query, CancellationToken ct)
        {
            var coefficients = _coefficientsRepository.GetAll().ToList();

            var coefficientsResponses = _mapper.Map<IList<CoefficientsResponse>>(coefficients);


            return new CustomResponse<GetAllCoefficientsResponse>("Coeficientes encontrados", new GetAllCoefficientsResponse(coefficientsResponses));       
        }
    }
}
