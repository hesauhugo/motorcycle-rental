using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorcycleRental.Application.Commands.CreateCustomer;
using MotorcycleRental.Application.Commands.CreateMotorcycle;
using MotorcycleRental.Application.Queries.GetCustomerById;
using MotorcycleRental.Application.Queries.GetMotorcycleById;
using MotorcycleRental.Application.ViewModels;

namespace MotorcycleRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "customer")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromForm] CreateCustomerCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "customer")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var query = new GetCustomerByIdQuery(id);
            var customer = await _mediator.Send(query);

            if (customer is null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
    }
}
