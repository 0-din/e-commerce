using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repo, ILogger<ProductController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repo;
            configuration.GetConnectionString("default");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _repository.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductById(int id)
        {
            var products = await _repository.GetProductByIdAsync(id);
            return Ok(products);
        }
    }
}