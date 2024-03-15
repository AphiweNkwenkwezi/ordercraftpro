using OrderCraftPro.Models;

namespace OrderCraftPro.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(Order order);
        Order? GetOrderById(Guid id);
        List<Order> GetAllOrders();
        Task<List<Order>> GetAllOrdersAsync();
        Task RemoveOrderAsync(Guid orderId);
        void SaveOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Guid id);
    }

    // Similarly, implement repositories for other entities like OrderLine, Product, etc.
}
