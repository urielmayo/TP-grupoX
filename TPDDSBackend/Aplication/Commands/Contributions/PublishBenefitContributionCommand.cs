using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Constans;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;
using TPDDSBackend.Infrastructure.Services;

namespace TPDDSBackend.Aplication.Commands.Contributions
{
    public class PublishBenefitContributionCommand: IRequest<CustomResponse<Benefit>>
    {
        public CreateBenefitRequest Request { get; set; }
        public PublishBenefitContributionCommand(CreateBenefitRequest request)
        {
            Request = request;
        }
    }

    public class PublishBenefitContributionCommandHandler : IRequestHandler<PublishBenefitContributionCommand, CustomResponse<Benefit>>
    {
        private readonly IMapper _mapper;
        private readonly IJwtFactory _jwtFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGenericRepository<Benefit> _benefitRepository;
        public PublishBenefitContributionCommandHandler(IMapper mapper,
            IJwtFactory jwtFactory,
            IHttpContextAccessor httpContextAccessor,
            IGenericRepository<Benefit> benefitRepository)
        {
            _mapper = mapper;
            _jwtFactory = jwtFactory;
            _httpContextAccessor = httpContextAccessor;
            _benefitRepository = benefitRepository;        
        }
        public async Task<CustomResponse<Benefit>> Handle(PublishBenefitContributionCommand command, CancellationToken cancellationToken)
        {
            var jwt = _httpContextAccessor.HttpContext.Request.Headers.Authorization;

            (string collaboradorId, _) = _jwtFactory.GetClaims(jwt);

            var benefit = _mapper.Map<Benefit>(command.Request);
            benefit.CollaboratorId = collaboradorId;
            using var memoryStream = new MemoryStream();
            await command.Request.Image.CopyToAsync(memoryStream);
            var bytesImage = memoryStream.ToArray();

            benefit.Image = bytesImage;

            await _benefitRepository.Insert(benefit);

            return new CustomResponse<Benefit>(ServiceConstans.MessageSuccessDonation, benefit);
        }
    }
}
