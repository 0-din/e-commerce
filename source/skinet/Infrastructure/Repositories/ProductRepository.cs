using System.Data.SqlClient;
using Core.Entities;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            var products = await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .ToListAsync();
            return products;
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<int> InsertAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        } 

        public Task DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            var brands = await _context.ProductBrands.ToListAsync();
            return brands;
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            var types = await _context.ProductTypes.ToListAsync();
            return types;
        }
    }
}