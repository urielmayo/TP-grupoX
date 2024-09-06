using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Drawing;
using System;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Services;
using TPDDSBackend.Domain.Enums;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Commands.Contributions
{
    public class MoneyContributionCommandHandler : IRequestHandler<MoneyContributionCommand, CustomResponse<Contribution>>
    {
        private readonly UserManager<Collaborator> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGenericRepository<MoneyDonation> _moneyDonationRepository;
        public MoneyContributionCommandHandler(UserManager<Collaborator> userManager,
            IJwtFactory jwtFactory,
            IHttpContextAccessor httpContextAccessor,
            IGenericRepository<MoneyDonation> moneyDonationRepository)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _httpContextAccessor = httpContextAccessor;
            _moneyDonationRepository = moneyDonationRepository;
        }
        public async Task<CustomResponse<Contribution>> Handle(MoneyContributionCommand command, CancellationToken cancellationToken)
        {
            var jwt = _httpContextAccessor.HttpContext.Request.Headers.Authorization;

            (string collaboradorId, _) = _jwtFactory.GetClaims(jwt);

            var collaborador = await _userManager.FindByIdAsync(collaboradorId);
            
            DonationFrequency frequency = (DonationFrequency)Enum.Parse(typeof(DonationFrequency), command.Request.Frequency);
            DateTime date = DateTime.Parse(command.Request.Date).ToUniversalTime();
            
            var donation =  await collaborador.DonateMoney(command.Request.Amount, date, frequency);

            await _moneyDonationRepository.Insert(donation);

            return new CustomResponse<Contribution>("Se ha realizado con exito la donacion");
        }
    }
}
