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
    public class ContributionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContributionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("money")]
        public async Task<IActionResult> DonateMoney()
        {
            return Ok();
        }

        [HttpPost("food")]
        public async Task<IActionResult> DonateFood()
        {
            return Ok();
        }

        [HttpPost("food-delivery")]
        public async Task<IActionResult> Delivery()
        {
            return Ok();
        }

        [HttpPost("person-registration")]
        public async Task<IActionResult> Register()
        {
            return Ok();
        }


    }
    }
