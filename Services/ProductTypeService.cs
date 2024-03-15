using Microsoft.EntityFrameworkCore;
using OrderCraftPro.Data;
using OrderCraftPro.Models;
using OrderCraftPro.Services.Interfaces;

namespace OrderCraftPro.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly OrderCraftProDbContext _context;

        public ProductTypeService(OrderCraftProDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<ProductType> GetProductTypeByIdAsync(Guid id)
        {
            return await _context.ProductTypes.FindAsync(id);
        }

        public async Task AddProductTypeAsync(ProductType productType)
        {
            _context.ProductTypes.Add(productType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductTypeAsync(ProductType productType)
        {
            _context.ProductTypes.Update(productType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductTypeAsync(Guid id)
        {
            var productType = await _context.ProductTypes.FindAsync(id);
            if (productType != null)
            {
                _context.ProductTypes.Remove(productType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
