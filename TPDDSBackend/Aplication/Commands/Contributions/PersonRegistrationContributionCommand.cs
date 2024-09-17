using MediatR;
using Microsoft.AspNetCore.Identity;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Enums;
using TPDDSBackend.Infrastructure.Repositories;
using TPDDSBackend.Infrastructure.Services;

namespace TPDDSBackend.Aplication.Commands.Contributions
{
    public class PersonRegistrationContributionCommand: IRequest<CustomResponse<Contribution>>
    {
        public CreatePersonInVulnerableSituationRequest? Request { get; set; }
        public PersonRegistrationContributionCommand(CreatePersonInVulnerableSituationRequest? request)
        {
            Request = request;
        }
    }

    public class PersonRegistrationContributionCommandHandler : IRequestHandler<PersonRegistrationContributionCommand, CustomResponse<Contribution>>
    {
        private readonly UserManager<Collaborator> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGenericRepository<MoneyDonation> _moneyDonationRepository;
        public PersonRegistrationContributionCommandHandler(UserManager<Collaborator> userManager,
            IJwtFactory jwtFactory,
            IHttpContextAccessor httpContextAccessor,
            IGenericRepository<MoneyDonation> moneyDonationRepository)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _httpContextAccessor = httpContextAccessor;
            _moneyDonationRepository = moneyDonationRepository;
        }
        public async Task<CustomResponse<Contribution>> Handle(PersonRegistrationContributionCommand command, CancellationToken cancellationToken)
        {

            var jwt = _httpContextAccessor.HttpContext.Request.Headers.Authorization;

            (string collaboradorId, _) = _jwtFactory.GetClaims(jwt);

            //Insertar nueva persona en situacion vulnerable

            //Insertar nueva tarjeta como contribucion

            return new CustomResponse<Contribution>("Se ha realizado con exito la donacion");
        }
    }
}
