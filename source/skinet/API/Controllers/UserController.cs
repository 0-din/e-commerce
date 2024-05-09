using Microsoft.AspNetCore.Mvc;
using Core.Interface;
using Core.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repo, ILogger<ProductController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repo;
            configuration.GetConnectionString("default");
        }

        [HttpGet("constr")]
        public ActionResult<string> GetConnectionString()
        {
            if(string.IsNullOrEmpty(_repository.constr))
                return Ok("connection string is not provided!");

            return Ok("connectionString: " + _repository.constr);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAsync()
        {
            var users = await _repository.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetByIdAsync(int id)
        {
            var user = await _repository.GetUserByIdAsync(id);
            return Ok(user);
        }
    }
}