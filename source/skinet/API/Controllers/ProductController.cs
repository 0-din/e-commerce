using API.Dtos;
using Core.Entities;
using Core.Interface;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IBaseRepository<Product> _productRepo;
        private readonly IBaseRepository<ProductBrand> _productBrandRepo;
        private readonly IBaseRepository<ProductType> _productTypeRepo;

        public ProductController(IBaseRepository<Product> productRepo,
                IBaseRepository<ProductBrand> productBrandRepo,
                IBaseRepository<ProductType> productTypeRepo)
        {
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandSpecification();
            var products = await _productRepo.ListAsync(spec);
            var dtos = products.Select(product => new ProductToReturnDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PictureUrl = product.PictureUrl,
                Price = product.Price,
                ProductType = product.ProductType.Name,
                ProductBrand = product.ProductBrand.Name
            }).ToList();

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProductById(int id)
        {
            var spec = new ProductsWithTypesAndBrandSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            var dto = new ProductToReturnDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PictureUrl = product.PictureUrl,
                Price = product.Price,
                ProductType = product.ProductType.Name,
                ProductBrand = product.ProductBrand.Name
            };

            return dto;
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.GetAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.GetAllAsync());
        }
    }
}