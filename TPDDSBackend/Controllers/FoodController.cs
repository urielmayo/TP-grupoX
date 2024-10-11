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
    public class FoodController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FoodController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateFood([FromBody] CreateFoodRequest request)
        {
            var result = await _mediator.Send(new CreateFoodCommand(request));
            return Created($"{HttpContext.Request.Host.Value}/api/food/{result.Data.Id}", result);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFood(string id)
        {
            var result = await _mediator.Send(new GetFoodQuery(int.Parse(id)));

            return Ok(result);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFood([FromBody] UpdateFoodRequest request, string id)
        {
            var result = await _mediator.Send(new UpdateFoodCommand(request, int.Parse(id)));

            return Ok(result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(string id)
        {
            await _mediator.Send(new DeleteFoodCommand(int.Parse(id)));
            return NoContent();
        }
    }
}
