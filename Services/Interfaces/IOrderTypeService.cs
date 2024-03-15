using OrderCraftPro.Models;

namespace OrderCraftPro.Services.Interfaces
{
    public interface IOrderTypeService
    {
        Task<List<OrderType>> GetOrderTypesAsync();
        Task<OrderType> GetOrderTypeByIdAsync(Guid id);
        Task AddOrderTypeAsync(OrderType orderType);
        Task UpdateOrderTypeAsync(OrderType orderType);
        Task DeleteOrderTypeAsync(Guid id);
    }
}
