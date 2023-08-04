using Core.Entities;
using Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ProductRepository _repository;

        public ProductController(ILogger<ProductController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = new ProductRepository(_configuration.GetConnectionString("default"));
        }

        [HttpGet(Name = "GetProduct")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            var products = await _repository.GetAllProducts();
            return Ok(products);
        }
    }
}