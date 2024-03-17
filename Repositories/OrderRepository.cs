using Microsoft.EntityFrameworkCore;
using OrderCraftPro.Data;
using OrderCraftPro.Models;
using OrderCraftPro.Repositories.Interfaces;

namespace OrderCraftPro.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderCraftProDbContext _context;

        public OrderRepository(OrderCraftProDbContext context)
        {
            _context = context;
        }
        public async Task AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveOrderAsync(Guid orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                throw new ArgumentException($"Order with ID {orderId} not found.");
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                    .Include(o => o.OrderLines)
                        .ThenInclude(ol => ol.Product)
                            .ThenInclude(p => p.ProductType)
                    .Include(o => o.OrderType)
                    .Include(o => o.OrderStatus)
                    .Include(o => o.Customer)
                    .ToListAsync();
        }

        public Order? GetOrderById(Guid id)
        {
            return _context.Orders
                .Include(o => o.OrderLines)
                    .ThenInclude(ol => ol.Product)
                .FirstOrDefault(o => o.Id == id);
        }
        public List<Order> GetAllOrders()
        {
            return _context.Orders
                .Include(o => o.OrderLines)
                    .ThenInclude(ol => ol.Product)
                .ToList();
        }

        public void SaveOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public void DeleteOrder(Guid orderId)
        {
            var order = _context.Orders.Find(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}
