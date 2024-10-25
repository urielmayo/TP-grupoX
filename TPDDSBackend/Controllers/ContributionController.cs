using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [Authorize]
        public async Task<IActionResult> DonateFood(FoodContributionRequest request)
        {
            var result = await _mediator.Send(new FoodContributionCommand(request));
            return Ok(result);
        }

        [HttpPost("food-distribution")]
        [Authorize]
        public async Task<IActionResult> Delivery(FoodDeliveryContributionRequest request)
        {
            var result = await _mediator.Send( new FoodDeliveryContributionCommand(request));
            return Ok(result);
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
        public async Task<IActionResult> TakeChargeFridge(OwnAFridgeContributionRequest request )
        {
            var result = await _mediator.Send(new OwnAFridgeContributionCommand(request));

            return Ok(result);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContribution(int id)
        {
            var result = await _mediator.Send(new GetContributionQuery(id));

            return Ok(result);
        }


    }
 }
