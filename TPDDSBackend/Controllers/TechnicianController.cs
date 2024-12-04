using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPDDSBackend.Aplication.Commands;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Queries;

namespace TPDDSBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TechnicianController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TechnicianController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllTechniciansQuery());

            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateTechnician([FromBody] CreateTechnicianRequest request)
        {
            var result = await _mediator.Send(new CreateTechnicianCommand(request));
            return Created($"{HttpContext.Request.Host.Value}/api/techician/{result.Data.Id}", result);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTechnician(string id)
        {
            var result = await _mediator.Send(new GetTechnicianQuery(int.Parse(id)));

            return Ok(result);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTechnician([FromBody] UpdateTechnicianRequest request, string id)
        {
            var result = await _mediator.Send(new UpdateTechnicianCommand(request, int.Parse(id)));

            return Ok(result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnician(string id)
        {
            await _mediator.Send(new DeleteTechnicianCommand(int.Parse(id)));
            return NoContent();
        }
    }
}
