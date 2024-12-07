using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Commands.Coefficients
{
    public class UpdateCoefficientsCommand : IRequest<CustomResponse<CoefficientsResponse>>
    {
        public CoefficientsRequest Request { get; set; }

        public int Id {  get; set; }
        public UpdateCoefficientsCommand(CoefficientsRequest request, int id)
        {
            Request = request;
            Id = id;
        }
    }

    public class UpdateCoefficientsCommandHandler : IRequestHandler<UpdateCoefficientsCommand, CustomResponse<CoefficientsResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<BenefitCoefficients> _coefficientsRepository;
        public UpdateCoefficientsCommandHandler(IMapper mapper,
            IGenericRepository<BenefitCoefficients> coefficientsRepository)
        {
            _mapper = mapper;
            _coefficientsRepository = coefficientsRepository;
        }

        public async Task<CustomResponse<CoefficientsResponse>> Handle(UpdateCoefficientsCommand command, CancellationToken ct)
        {
            var coefficients = await _coefficientsRepository.GetById(command.Id);

            if (coefficients == null)
            {
                throw new ApiCustomException("Coeficientes no encontrados", HttpStatusCode.NotFound);
            }

            coefficients.DeliveredCards = command.Request.DeliveredCards;
            coefficients.DeliveredFoods = command.Request.DeliveredFoods;
            coefficients.DonatedFoods = command.Request.DonatedFoods;
            coefficients.DonatedPesos = command.Request.DonatedPesos;
            coefficients.ActiveFridges = command.Request.ActiveFridges;
            coefficients.ValidFrom = DateTime.SpecifyKind(command.Request.ValidFrom, DateTimeKind.Utc);
            coefficients.ValidUntil = DateTime.SpecifyKind(command.Request.ValidUntil, DateTimeKind.Utc);

            _coefficientsRepository.Update(coefficients);

            var responseDto = _mapper.Map<CoefficientsResponse>(coefficients);

            return new CustomResponse<CoefficientsResponse>("Coeficientes actualizados", responseDto);
        }
    }
}


