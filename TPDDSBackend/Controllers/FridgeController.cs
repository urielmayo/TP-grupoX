using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPDDSBackend.Aplication.Commands;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Queries;
using TPDDSBackend.Domain.Entitites;

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

        [HttpPost("create")]
        public async Task<IActionResult> CreateFridge([FromBody] CreateFridgeRequest request)
        {
            var result = await _mediator.Send(new CreateFridgeCommand(request));
            return Created($"{HttpContext.Request.Host.Value}/api/fridge/{result.Data.Id}", result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFridge(string id)
        {
            var result = await _mediator.Send(new GetFridgeQuery(int.Parse(id)));

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFridge([FromBody]UpdateFridgeRequest request, string id)
        {
            var result = await _mediator.Send(new UpdateFridgeCommand(request, int.Parse(id)));

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFridge(string id)
        {
            await _mediator.Send(new DeleteFridgeCommand(int.Parse(id)));
            return NoContent();
        }
    }
}
