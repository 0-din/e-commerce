using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrderController : BaseApiController
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