using OrderCraftPro.Models;

namespace OrderCraftPro.Services.Interfaces
{
    public interface IProductService
    {
        Product? GetProduct(Guid id);
        List<Product> GetAllProducts();
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Guid id);
    }
}
