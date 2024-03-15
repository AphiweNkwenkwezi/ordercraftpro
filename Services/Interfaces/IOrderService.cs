using OrderCraftPro.Models;
using System.Threading.Tasks;

namespace OrderCraftPro.Services.Interfaces
{
    public interface IOrderService
    {
        Task AddOrderAsync(Order order);
        Task<List<Order>> GetOrdersAsync();
        Task<List<Order>> SearchOrdersAsync(string searchTerm);
        Task RemoveOrderAsync(Guid orderId);
        Order? GetOrder(Guid id);
        List<Order> GetAllOrders();
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Guid id);
    }
}
