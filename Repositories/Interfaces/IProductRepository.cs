using OrderCraftPro.Models;

namespace OrderCraftPro.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Product GetProduct(Guid id);
        List<Product> GetAllProducts();
        void SaveProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Guid id);
    }
}
