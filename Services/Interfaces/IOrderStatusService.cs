using OrderCraftPro.Models;

namespace OrderCraftPro.Services.Interfaces
{
    public interface IOrderStatusService
    {
        Task<List<OrderStatus>> GetOrderStatusesAsync();
        Task<OrderStatus> GetOrderStatusByIdAsync(Guid id);
        Task AddOrderStatusAsync(OrderStatus OrderStatus);
        Task UpdateOrderStatusAsync(OrderStatus OrderStatus);
        Task DeleteOrderStatusAsync(Guid id);
    }
}
