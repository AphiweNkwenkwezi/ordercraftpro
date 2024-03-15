using Microsoft.EntityFrameworkCore;
using OrderCraftPro.Data;
using OrderCraftPro.Models;
using OrderCraftPro.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderCraftPro.Services
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly OrderCraftProDbContext _context;

        public OrderStatusService(OrderCraftProDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderStatus>> GetOrderStatusesAsync()
        {
            return await _context.OrderStatuses.ToListAsync();
        }

        public async Task<OrderStatus> GetOrderStatusByIdAsync(Guid id)
        {
            return await _context.OrderStatuses.FindAsync(id);
        }

        public async Task AddOrderStatusAsync(OrderStatus orderStatus)
        {
            _context.OrderStatuses.Add(orderStatus);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderStatusAsync(OrderStatus orderStatus)
        {
            _context.OrderStatuses.Update(orderStatus);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderStatusAsync(Guid id)
        {
            var orderStatus = await _context.OrderStatuses.FindAsync(id);
            if (orderStatus != null)
            {
                _context.OrderStatuses.Remove(orderStatus);
                await _context.SaveChangesAsync();
            }
        }
    }
}
