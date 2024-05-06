using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorcycleRental.Application.Commands.CreateMotorcycle;
using MotorcycleRental.Application.Queries;

namespace MotorcycleRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorcyclesController : ControllerBase
    {

        private readonly IMediator _mediator;

        public MotorcyclesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMotorcycleCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetMotorcycleByIdQuery(id);
            var motorcycle = await _mediator.Send(query);

            if(motorcycle is null)
            {
                return NotFound();
            }

            return Ok(motorcycle);
        }
    }
}
