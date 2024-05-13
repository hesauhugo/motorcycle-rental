using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorcycleRental.Application.Commands.CreateMotorcycle;
using MotorcycleRental.Application.Commands.UpdateLicensePlate;
using MotorcycleRental.Application.Queries.GetMotorcycleById;
using MotorcycleRental.Application.Queries.GetMotorcycleByLicensePlate;
using MotorcycleRental.Application.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MotorcycleRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorcyclesController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger<MotorcyclesController> _logger;
        public MotorcyclesController(IMediator mediator, ILogger<MotorcyclesController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type=typeof(MotorcycleViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreateMotorcycleCommand command)
        {
            _logger.LogInformation($"Post started");
            var id = await _mediator.Send(command);

            _logger.LogInformation($"Post finished");
            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MotorcycleViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            _logger.LogInformation($"GetById started");
            var query = new GetMotorcycleByIdQuery(id);
            var motorcycle = await _mediator.Send(query);

            if(motorcycle is null)
            {
                return NotFound();
            }
            _logger.LogInformation($"GetById finished");
            return Ok(motorcycle);
        }

        [HttpGet("GetByLicensePlate/{licensePlate}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MotorcycleViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByLicensePlate([FromRoute] string licensePlate)
        {
            
            var query = new GetMotorcycleByLicensePlateQuery(licensePlate);
            var motorcycle = await _mediator.Send(query);

            if (motorcycle is null)
            {
                _logger.LogInformation($"GetByLicensePlate notfound");
                return NotFound();
            }

            return Ok(motorcycle);
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Patch([FromRoute] int id, [FromBody] UpdateLicensePlateCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            _logger.LogInformation($"Patch NoContent");
            return NoContent();
        }
    }
}
