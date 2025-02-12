using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPDDSBackend.Aplication.Commands;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Commands.Fridges;  // Añadir este import
using TPDDSBackend.Aplication.Dtos.Responses;    // Añadir este import
using Swashbuckle.AspNetCore.Annotations;

namespace TPDDSBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DonationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DonationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Locaciones sugeridas para donar", typeof(List<FridgeLocationsResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(CustomResponse<string>))]
        public async Task<IActionResult> GetDonationLocations(SuggestFridgeLocationsRequest request)
        {
            var result = await _mediator.Send(new SuggestFridgeLocatiosCommand(request));

            return Ok(result);
        }
    }
}