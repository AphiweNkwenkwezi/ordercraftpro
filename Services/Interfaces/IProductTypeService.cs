using OrderCraftPro.Models;

namespace OrderCraftPro.Services.Interfaces
{
    public interface IProductTypeService
    {
        Task<IEnumerable<ProductType>> GetProductTypesAsync();
        Task<ProductType> GetProductTypeByIdAsync(Guid id);
        Task AddProductTypeAsync(ProductType productType);
        Task UpdateProductTypeAsync(ProductType productType);
        Task DeleteProductTypeAsync(Guid id);
    }
}
