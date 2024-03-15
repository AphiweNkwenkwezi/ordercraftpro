using OrderCraftPro.Data;
using OrderCraftPro.Models;
using OrderCraftPro.Repositories.Interfaces;

namespace OrderCraftPro.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OrderCraftProDbContext _context;

        public ProductRepository(OrderCraftProDbContext context)
        {
            _context = context;
        }
        public Product? GetProduct(Guid id) 
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
        //public List<Product> GetAllProducts()
        //{
        //    var staticProducts = new List<Product>
        //    {
        //        new Product { Id = Guid.NewGuid(), ProductName = "Laptop", Price = 999.99m, ProductCode = "LP001" },
        //        new Product { Id = Guid.NewGuid(), ProductName = "Smartphone", Price = 599.99m, ProductCode = "SP002" },
        //        new Product { Id = Guid.NewGuid(), ProductName = "Headphones", Price = 99.99m, ProductCode = "HP003" },
        //        new Product { Id = Guid.NewGuid(), ProductName = "Wireless Mouse", Price = 29.99m, ProductCode = "WM004" },
        //        new Product { Id = Guid.NewGuid(), ProductName = "External Hard Drive", Price = 149.99m, ProductCode = "EHD005" },
        //        new Product { Id = Guid.NewGuid(), ProductName = "Bluetooth Speaker", Price = 79.99m, ProductCode = "BS006" }
        //    };

        //    return staticProducts;
        //}
        public void SaveProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(Guid productId)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
