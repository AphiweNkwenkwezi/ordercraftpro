using Microsoft.EntityFrameworkCore;
using OrderCraftPro.Models;
using OrderCraftPro.Repositories;
using OrderCraftPro.Repositories.Interfaces;
using OrderCraftPro.Services.Interfaces;

namespace OrderCraftPro.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task AddOrderAsync(Order order)
        {
            await _orderRepository.AddOrderAsync(order);
        }
        public Order? GetOrder(Guid id) 
        {
            return _orderRepository.GetOrderById(id);
        }
        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }
        public void CreateOrder(Order order)
        {
            _orderRepository.SaveOrder(order);
        }
        public void UpdateOrder(Order order)
        {
            _orderRepository.UpdateOrder(order);
        }
        public void DeleteOrder(Guid orderId)
        {
            _orderRepository.DeleteOrder(orderId);
        }
        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _orderRepository.GetAllOrdersAsync(); ;
        }
        public async Task<List<Order>> SearchOrdersAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetOrdersAsync();
            }
            else
            {
                return (await _orderRepository.GetAllOrdersAsync())
                    .Where(o => o.OrderNumber.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
        }
        public async Task RemoveOrderAsync(Guid orderId)
        {
            try
            {
                await _orderRepository.RemoveOrderAsync(orderId);
            }
            catch (ArgumentException ex)
            {
                throw;
            }
        }
    }
}
