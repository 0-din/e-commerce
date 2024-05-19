using Microsoft.AspNetCore.Mvc;
using Core.Interface;
using Core.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IBaseRepository<User> _userRepo;

        public UserController(IBaseRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAsync()
        {
            var users = await _userRepo.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetByIdAsync(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            return Ok(user);
        }
    }
}