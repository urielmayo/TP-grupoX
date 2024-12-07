using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TPDDSBackend.Aplication.Commands.Coefficients;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Queries;

namespace TPDDSBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoefficientsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CoefficientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [SwaggerResponse(StatusCodes.Status200OK, "coeficientes creados", typeof(CustomResponse<CoefficientsResponse>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CreateCoefficients([FromBody] CoefficientsRequest request)
        {
            var result = await _mediator.Send(new CreateCoefficientsCommand(request));

            return Ok(result);
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "coeficientes dados de alta", typeof(CustomResponse<GetAllCoefficientsResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Coeficientes no encontrados", typeof(CustomResponse<string>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCoefficients()
        {
            var result = await _mediator.Send(new GetAllCoefficientsQuery());
            return Ok(result);
        }

        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "coeficientes actualizados", typeof(CustomResponse<CoefficientsResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Coeficientes no encontrados", typeof(CustomResponse<string>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCoefficients([FromBody] CoefficientsRequest request, [FromRoute]int id)
        {
            var result = await _mediator.Send( new UpdateCoefficientsCommand(request,id));
            return Ok(result);
        }
    }
 }
