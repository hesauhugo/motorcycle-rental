using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MotorcycleRental.Application.Commands.CreateUser;
using MotorcycleRental.Application.Commands.LoginUser;
using MotorcycleRental.Application.Queries.GetUser;

namespace MotorcycleRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {

        private readonly IMediator _mediator;
        ILogger<UsersController> _logger;
        public UsersController(IMediator mediator, ILogger<UsersController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation($"GetById started");

            var query = new GetUserQuery(id);

            var user = await _mediator.Send(query);

            if (user == null)
            {
                return NotFound();
            }

            _logger.LogInformation($"GetById finished with id:{id}");
            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            _logger.LogInformation($"Post started");

            var id = await _mediator.Send(command);

            _logger.LogInformation($"Post finished with id:{id}");
            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            _logger.LogInformation($"Login started");

            var loginUserviewModel = await _mediator.Send(command);

            if (loginUserviewModel == null)
            {
                return BadRequest();
            }

            _logger.LogInformation($"Login finished with user:{loginUserviewModel.Email}");

            return Ok(loginUserviewModel);
        }

    }
}
