using Core.Entities;

namespace Core.Interface
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}