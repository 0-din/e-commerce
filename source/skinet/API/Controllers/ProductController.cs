using System.Runtime.CompilerServices;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _repository.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductById(int id)
        {
            var products = await _repository.GetByIdAsync(id);
            return Ok(products);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _repository.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetProductTypes()
        {
            return Ok(await _repository.GetProductTypesAsync());
        }
    }
}