using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TPDDSBackend.Aplication.Commands.Fridges;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Queries;
using TPDDSBackend.Infrastructure.Entities;

namespace TPDDSBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpGet("fridge-failures")]
        [Authorize(Roles = "Admin")]
        [SwaggerResponse(StatusCodes.Status200OK, "Cantidad de fallas por heladera", typeof(CustomResponse<List<FridgeIncidentCountDto>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(CustomResponse<string>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetTotalFailuresByFridge([FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            var result = await _mediator.Send(new GetFridgeFailureReportQuery(from,to));

            return Ok(result);
        }


        [HttpGet("fridge-movements")]
        [Authorize(Roles = "Admin")]
        [SwaggerResponse(StatusCodes.Status200OK, "Cantidad de viandas retiradas y colocadas por heladera", typeof(CustomResponse<List<FridgeIncidentCountDto>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(CustomResponse<string>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetTotalFoodsInOutByFridge([FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            var result = await _mediator.Send(new GetFridgeMovementsReportQuery(from, to));

            return Ok(result);
        }

        [HttpGet("foods-by-collaborator")]
        [Authorize(Roles = "Admin")]
        [SwaggerResponse(StatusCodes.Status200OK, "Cantidad de viandas retiradas y colocadas por heladera", typeof(CustomResponse<List<FridgeIncidentCountDto>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad Request", typeof(CustomResponse<string>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetTotalDonatedFoodsByCollaborator([FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            var result = await _mediator.Send(new GetTotalDonatedFoodReportQuery(from, to));

            return Ok(result);
        }
    }
}
