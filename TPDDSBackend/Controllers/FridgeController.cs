using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPDDSBackend.Aplication.Commands.Fridges;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Queries;

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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllFridgesQuery());

            return Ok(result);
        }

        [Authorize]
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
    }
}
