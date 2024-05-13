using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorcycleRental.API.Extensions;
using MotorcycleRental.Application.Commands.CreateRental;
using MotorcycleRental.Application.Commands.LoginUser;
using MotorcycleRental.Application.Commands.UpdateRentalEndDate;
using MotorcycleRental.Application.Queries.GetMotorcycleById;
using MotorcycleRental.Application.Queries.GetRentalById;
using MotorcycleRental.Application.ViewModels;

namespace MotorcycleRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RentsController> _logger;

        public RentsController(IMediator mediator, ILogger<RentsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Authorize(Roles = "customer")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RentalViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddRental([FromBody] CreateRentalCommand command)
        {
            _logger.LogInformation($"AddRental started");
            var customerId = HttpContext.GetCustomerId();
            command.SetIdCustomer(customerId);
            var id = await _mediator.Send(command);

            _logger.LogInformation($"AddRental finished");
            return CreatedAtAction(nameof(GetById), new { id }, command);
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "customer")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RentalViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            _logger.LogInformation($"GetById started");
            var query = new GetRentalByIdQuery(id);
            var rental = await _mediator.Send(query);

            if (rental is null)
            {
                return NotFound();
            }
            _logger.LogInformation($"GetById finished");
            return Ok(rental);
        }

        [HttpPatch("{id}/EndDate")]
        [Authorize(Roles = "customer")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SetEndDate([FromRoute] int id, [FromBody] UpdateRentalEndDateCommand command)
        {
            _logger.LogInformation($"SetEndDate started");
            command.SetId(id);
            await _mediator.Send(command);

            _logger.LogInformation($"SetEndDate finished");
            return NoContent();
        }
    }
}
