using Microsoft.AspNetCore.Mvc;
using Core.Interface;
using Core.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAsync()
        {
            var users = await _repository.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            return Ok(user);
        }
    }
}