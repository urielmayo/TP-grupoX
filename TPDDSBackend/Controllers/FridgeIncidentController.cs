using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TPDDSBackend.Aplication.Commands.Fridges;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Queries;

namespace TPDDSBackend.Controllers
{
    [ApiController]
    [Route("fridge-incident")]
    public class FridgeIncidentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FridgeIncidentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("failure")]
        [SwaggerResponse(StatusCodes.Status200OK, "incidente de heladera registado", typeof(CustomResponse<CreateFridgeFailureResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Heladera no encontrada", typeof(CustomResponse<string>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateFridgeIncident([FromBody] CreateFridgeFailureRequest request)
        {
            var result = await _mediator.Send(new CreateFridgeFailureCommand(request));
            return Ok(result);
        }

        [Authorize]
        [HttpPost("alert")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "incidente de heladera registado", typeof(CustomResponse<CreateFridgeFailureResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Heladera no encontrada", typeof(CustomResponse<string>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateFridgeAlert([FromBody] CreateFridgeAlertRequest request)
        {
            await _mediator.Send(new CreateFridgeAlertCommand(request));
            return NoContent();
        }
    }
}
