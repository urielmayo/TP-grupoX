using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TPDDSBackend.Aplication.Commands.Contributions;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Queries;
using TPDDSBackend.Constans;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;

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
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status200OK, ServiceConstans.MessageSuccessDonation, typeof(CustomResponse<Contribution>))]
        [Authorize]
        public async Task<IActionResult> DonateMoney([FromBody] MoneyDonationRequest request)
        {
            var result = await _mediator.Send(new MoneyContributionCommand(request));

            return Ok(result);
        }

        [HttpPost("food")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status200OK, ServiceConstans.MessageSuccessDonation, typeof(CustomResponse<Contribution>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, ServiceConstans.AddressRequiredMessage, typeof(CustomResponse<string>))]
        [Authorize]
        public async Task<IActionResult> DonateFood(FoodContributionRequest request)
        {
            var result = await _mediator.Send(new FoodContributionCommand(request));
            return Ok(result);
        }

        [HttpPost("food-distribution")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "No existe esa heladera", typeof(CustomResponse<string>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, ServiceConstans.AddressRequiredMessage, typeof(CustomResponse<string>))]
        [SwaggerResponse(StatusCodes.Status200OK, ServiceConstans.MessageSuccessDonation, typeof(CustomResponse<Contribution>))]
        [Authorize]
        public async Task<IActionResult> Delivery(FoodDeliveryContributionRequest request)
        {
            var result = await _mediator.Send(new FoodDeliveryContributionCommand(request));
            return Ok(result);
        }

        [HttpPost("person-registration")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, ServiceConstans.AddressRequiredMessage, typeof(CustomResponse<string>))]
        [SwaggerResponse(StatusCodes.Status200OK, ServiceConstans.MessageSuccessDonation, typeof(CustomResponse<Contribution>))]
        [Authorize]
        public async Task<IActionResult> Register(PersonRegistrationContributionRequest request)
        {
            var result = await _mediator.Send(new PersonRegistrationContributionCommand(request));

            return Ok(result);
        }

        [HttpPost("fridge")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status200OK, ServiceConstans.MessageSuccessDonation, typeof(CustomResponse<Contribution>))]
        [Authorize]
        public async Task<IActionResult> TakeChargeFridge(CreateFridgeRequest request)
        {
            var result = await _mediator.Send(new OwnAFridgeContributionCommand(request));

            return Ok(result);
        }

        [Authorize]
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "contribucion encontrada", typeof(CustomResponse<ContributionResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "contribucion no encontrada", typeof(CustomResponse<string>))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, ServiceConstans.UpdateDeniedMessage, typeof(CustomResponse<string>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetContribution(int id)
        {
            var result = await _mediator.Send(new GetContributionQuery(id));

            return Ok(result);
        }

        [HttpPost("benefit")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status200OK, ServiceConstans.MessageSuccessDonation, typeof(CustomResponse<Benefit>))]
        [Authorize]
        public async Task<IActionResult> CreateBenefit([FromBody] CreateBenefitRequest request)
        {
            var result = await _mediator.Send(new PublishBenefitContributionCommand(request));

            return Ok(result);
        }
    }
 }
