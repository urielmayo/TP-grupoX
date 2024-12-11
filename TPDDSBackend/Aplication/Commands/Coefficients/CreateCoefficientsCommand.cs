using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Commands.Coefficients
{
    public class CreateCoefficientsCommand : IRequest<CustomResponse<CoefficientsResponse>>
    {
        public CoefficientsRequest Request { get; set; }
        public CreateCoefficientsCommand(CoefficientsRequest request)
        {
            Request = request;
        }
    }

    public class CreateCoefficientsCommandHandler : IRequestHandler<CreateCoefficientsCommand, CustomResponse<CoefficientsResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBenefitCoefficientsRepository _coefficientsRepository;
        public CreateCoefficientsCommandHandler(IMapper mapper,
            IBenefitCoefficientsRepository coefficientsRepository)
        {
            _mapper = mapper;
           _coefficientsRepository = coefficientsRepository;
        }

        public async Task<CustomResponse<CoefficientsResponse>> Handle(CreateCoefficientsCommand command, CancellationToken ct)
        {
            var validCoefficients = await _coefficientsRepository.GetValidCoeficients();

            if (validCoefficients != null) //para evitar conflictos de coeficientes
            {
                throw new ApiCustomException("Ya existen coeficientes validos, actualize los coeficientes", HttpStatusCode.UnprocessableEntity);
            }
            
            var entity = _mapper.Map<BenefitCoefficients>(command.Request);
            entity.ValidFrom = DateTime.SpecifyKind(entity.ValidFrom, DateTimeKind.Utc);
            entity.ValidUntil = DateTime.SpecifyKind(entity.ValidUntil, DateTimeKind.Utc);

            var result = await _coefficientsRepository.Insert(entity);

            var responseDto = _mapper.Map<CoefficientsResponse>(result);

            return new CustomResponse<CoefficientsResponse>("Se ha creadon los coeficientes", responseDto);
        }
    }
}


