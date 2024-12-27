using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TPDDSBackend.Aplication.Commands.Fridges;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Queries;
using TPDDSBackend.Constans;

namespace TPDDSBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FridgeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FridgeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateFridge([FromBody] CreateFridgeRequest request)
        {
            var result = await _mediator.Send(new CreateFridgeCommand(request));
            return Created($"{HttpContext.Request.Host.Value}/api/fridge/{result.Data.Id}", result);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFridge(string id)
        {
            var result = await _mediator.Send(new GetFridgeQuery(int.Parse(id)));

            return Ok(result);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFridge([FromBody]UpdateFridgeRequest request, string id)
        {
            var result = await _mediator.Send(new UpdateFridgeCommand(request, int.Parse(id)));

            return Ok(result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFridge(string id)
        {
            await _mediator.Send(new DeleteFridgeCommand(int.Parse(id)));
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllFridgesQuery());

            return Ok(result);
        }

        [HttpPost("{id}/temperature")]
        public async Task<IActionResult> RegisterTemperature(int id, RegisterTemperatureRequest request)
        {
             await _mediator.Send(new RegisterTemperatureFridgeCommand(id, request.Temperature));

            return NoContent();
        }

        [Authorize]
        [HttpPut("model/{id}/temperatures")]
        public async Task<IActionResult> SetupTemperatures(int id, SetupTemperaturesRequest request)
        {
           var result = await _mediator.Send(new SetupTemperaturesFridgeCommand(request,id));

            return Ok(result);
        }


        [Authorize]
        [HttpPost("suggested-locations")]
        public async Task<IActionResult> GetLocations(SuggestFridgeLocationsRequest request)
        {
            var result = await _mediator.Send(new SuggestFridgeLocatiosCommand(request));

            return Ok(result);
        }


        [Authorize]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status404NotFound, "entidad no encontrada", typeof(CustomResponse<string>))]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status403Forbidden, ServiceConstans.UpdateDeniedMessageByExpires, typeof(CustomResponse<string>))]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "no se puede continuar procesando", typeof(CustomResponse<string>))]
        [HttpPost("opening")]
        public async Task<IActionResult> OpenFridge([FromBody] OpeningRequest request)
        {
            await _mediator.Send(new OpenFridgeCommand(request));

            return NoContent();
        }
    }
}
