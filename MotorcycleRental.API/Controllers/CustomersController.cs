﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorcycleRental.Application.Commands.CreateCustomer;
using MotorcycleRental.Application.Commands.CreateMotorcycle;
using MotorcycleRental.Application.Commands.LoginCustomer;
using MotorcycleRental.Application.Commands.LoginUser;
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
        private readonly ILogger<CustomersController> _logger;
        public CustomersController(IMediator mediator,ILogger<CustomersController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromForm] CreateCustomerCommand command)
        {
            _logger.LogInformation($"Post started");
            var id = await _mediator.Send(command);

            _logger.LogInformation($"Post finished");
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
                _logger.LogInformation($"GetById not found");
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginCustomerCommand command)
        {
            var loginUserviewModel = await _mediator.Send(command);

            if (loginUserviewModel == null)
            {
                _logger.LogInformation($"Login not bad request");

                return BadRequest();
            }

            return Ok(loginUserviewModel);
        }
    }
}
