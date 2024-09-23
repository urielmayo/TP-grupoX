using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPDDSBackend.Aplication.Commands.Contributions;
using TPDDSBackend.Aplication.Dtos.Requests;

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
        public async Task<IActionResult> Register(PersonRegistrationContributionRequest request)
        {
            var result = await _mediator.Send(new PersonRegistrationContributionCommand(request));

            return Ok(result);
        }

        [HttpPost("fridge")]
        [Authorize]
        public async Task<IActionResult> TakeChargeFridge( )
        {
            var result = await _mediator.Send(new OwnAFridgeContributionCommand());

            return Ok(result);
        }


    }
 }
