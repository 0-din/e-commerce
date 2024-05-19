using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class OrderController : ControllerBase
    {
        public OrderController()
        {
        }

        [HttpGet]
        public async Task<ActionResult<Order>> GetAsync()
        {
            return Ok();
        }
    }
}