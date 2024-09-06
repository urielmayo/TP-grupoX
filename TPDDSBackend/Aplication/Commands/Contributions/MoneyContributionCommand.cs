using MediatR;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Commands.Contributions
{
    public class MoneyContributionCommand : IRequest<CustomResponse<Contribution>>
    {
        public MoneyDonationRequest? Request { get; set; }
        public MoneyContributionCommand(MoneyDonationRequest? request)
        {
            Request = request;
        }
    }
}
