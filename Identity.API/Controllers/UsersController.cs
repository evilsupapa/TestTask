using Microsoft.AspNetCore.Mvc;
using Identity.API.Models;
using Identity.Service.Managers;
using System.Threading.Tasks;
using Identity.Service.Queries;
using Identity.API.Extensions;
using Serilog;

namespace Identity.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager, ILogger logger)
        {
            _logger = logger;
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var query = new GetUserByIdQuery { Id = id };

            var user = await _userManager.GetById(query);
            if (user == null)
            {
                _logger.Information($"User with id={id} not found");
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("login/{login}")]
        public async Task<IActionResult> GetByLogin(string login)
        {
            var query = new GetUserByLoginQuery { Login = login };

            var user = await _userManager.GetByLogin(query);
            if (user == null)
            {
                _logger.Information($"User with login={login} not found");
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("country/{country}")]
        public async Task<IActionResult> FindByCountry(string country)
        {
            var query = new FindUsersByCountryQuery { Country = country };
            return Ok(await _userManager.FindByCountry(query));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateUserRequest request)
        {
            var user = await _userManager.Create(request.ToCreateUserCommand());
            if (user == null)
            {
                return StatusCode(500);
            }

            return Ok();
        }
    }
}