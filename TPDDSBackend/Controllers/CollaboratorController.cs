using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPDDSBackend.Aplication.Commands.Collaborators;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Queries;

namespace TPDDSBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollaboratorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CollaboratorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("human-person")]
        public async Task<IActionResult> CreateHumanPerson([FromBody] CreateHumanPersonRequest request)
        {
            var result = await _mediator.Send(new CreateHumanPersonCommand(request));
            return Created($"{HttpContext.Request.Host.Value}/api/collaborator/{result.Data.Id}", result);
        }

        [HttpPost("legal-person")]
        public async Task<IActionResult> CreateLegalPerson([FromBody] CreateLegalPersonRequest request)
        {
            var result = await _mediator.Send(new CreateLegalPersonCommand(request));
            return Created($"{HttpContext.Request.Host.Value}/api/collaborator/{result.Data.Id}", result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> SignIn([FromBody] LoginCollaboratorRequest request)
        {
            var result = await _mediator.Send(new LoginCollaboratorCommand(request));
            return Ok(result);
        }



        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCollaborator(string id)
        {
            var result = await _mediator.Send(new GetCollaboratorQuery(id));

            return Ok(result);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCollaborator(string id,UpdateCollaboratorRequest updateCollaboratorRequest)
        {
            var result = await _mediator.Send(new UpdateCollaboratorCommand(id,updateCollaboratorRequest));
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollaborator(string id)
        {
            await _mediator.Send(new DeleteCollaboratorCommand(id));
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("process-file")]
        public async Task<IActionResult> ProcessFile([FromForm] ProcessFileRequest file)
        {
            var result = await _mediator.Send(new ProcessFileCommand(file));
            return Ok(result);
        }
    }
 }
