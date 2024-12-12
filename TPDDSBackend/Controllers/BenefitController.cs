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
    public class BenefitController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BenefitController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "beneficios encontrados", typeof(CustomResponse<GetAllBenefitsResponse>))]
        public async Task<IActionResult> GetAllBenefits()
        {
            var result = await _mediator.Send(new GetAllBenefitQuery());
            return Ok(result);
        }
    }
 }
