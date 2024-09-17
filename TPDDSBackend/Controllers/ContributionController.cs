using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TPDDSBackend.Aplication.Commands;
using TPDDSBackend.Aplication.Commands.Contributions;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Queries;

namespace TPDDSBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContributionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContributionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpPost("money")]
        [Authorize]
        public async Task<IActionResult> DonateMoney([FromBody] MoneyDonationRequest request)
        {
            var result = await _mediator.Send(new MoneyContributionCommand(request));

            return Ok(result);
        }

        [HttpPost("food")]
        public async Task<IActionResult> DonateFood()
        {
            return Ok();
        }

        [HttpPost("food-delivery")]
        public async Task<IActionResult> Delivery()
        {
            return Ok();
        }

        [HttpPost("person-registration")]
        [Authorize]
        public async Task<IActionResult> Register(CreatePersonInVulnerableSituationRequest request)
        {
            var result = await _mediator.Send(new PersonRegistrationContributionCommand(request));

            return Ok(result);
        }


    }
 }
