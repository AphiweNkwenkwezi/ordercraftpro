using Microsoft.EntityFrameworkCore;
using OrderCraftPro.Data;
using OrderCraftPro.Models;
using OrderCraftPro.Services.Interfaces;

namespace OrderCraftPro.Services
{
    public class OrderTypeService : IOrderTypeService
    {
        private readonly OrderCraftProDbContext _context;

        public OrderTypeService(OrderCraftProDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderType>> GetOrderTypesAsync()
        {
            return await _context.OrderTypes.ToListAsync();
        }

        public async Task<OrderType> GetOrderTypeByIdAsync(Guid id)
        {
            return await _context.OrderTypes.FindAsync(id);
        }

        public async Task AddOrderTypeAsync(OrderType orderType)
        {
            _context.OrderTypes.Add(orderType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderTypeAsync(OrderType orderType)
        {
            _context.OrderTypes.Update(orderType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderTypeAsync(Guid id)
        {
            var orderType = await _context.OrderTypes.FindAsync(id);
            if (orderType != null)
            {
                _context.OrderTypes.Remove(orderType);
                await _context.SaveChangesAsync();
            }
        }
    }
}
