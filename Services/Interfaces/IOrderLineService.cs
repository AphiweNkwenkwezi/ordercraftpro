using OrderCraftPro.Models;

namespace OrderCraftPro.Services.Interfaces
{
    public interface IOrderLineService
    {
        List<OrderLine> GetAllOrderLines();
        void CreateOrderLine(OrderLine orderLine);
        void UpdateOrderLine(OrderLine orderLine);
        void DeleteOrderLine(int orderLineId);
    }
}
