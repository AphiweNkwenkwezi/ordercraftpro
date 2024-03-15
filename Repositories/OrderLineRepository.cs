using Microsoft.EntityFrameworkCore;
using OrderCraftPro.Data;
using OrderCraftPro.Models;
using OrderCraftPro.Repositories.Interfaces;

namespace OrderCraftPro.Repositories
{
    public class OrderLineRepository : IOrderLineRepository
    {
        private readonly OrderCraftProDbContext _context;

        public OrderLineRepository(OrderCraftProDbContext context)
        {
            _context = context;
        }

        public List<OrderLine> GetAllOrderLines()
        {
            return _context.OrderLines
                           .Include(ol => ol.Product)
                           .ToList();
        }

        public void SaveOrderLine(OrderLine orderLine)
        {
            _context.OrderLines.Add(orderLine);
            _context.SaveChanges();
        }

        public void UpdateOrderLine(OrderLine orderLine)
        {
            _context.OrderLines.Update(orderLine);
            _context.SaveChanges();
        }

        public void DeleteOrderLine(int orderLineId)
        {
            var orderLine = _context.OrderLines.Find(orderLineId);
            if (orderLine != null)
            {
                _context.OrderLines.Remove(orderLine);
                _context.SaveChanges();
            }
        }
    }
}
