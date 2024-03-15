using OrderCraftPro.Models;
using OrderCraftPro.Repositories.Interfaces;
using OrderCraftPro.Services.Interfaces;

namespace OrderCraftPro.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product? GetProduct(Guid id)
        {
            return _productRepository.GetProduct(id);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public void CreateProduct(Product product)
        {
            _productRepository.SaveProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(Guid id)
        {
            _productRepository.DeleteProduct(id);
        }
    }
}
