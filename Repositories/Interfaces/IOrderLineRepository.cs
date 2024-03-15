using OrderCraftPro.Models;

namespace OrderCraftPro.Repositories.Interfaces
{
    public interface IOrderLineRepository
    {
        List<OrderLine> GetAllOrderLines();
        void SaveOrderLine(OrderLine orderLine);
        void UpdateOrderLine(OrderLine orderLine);
        void DeleteOrderLine(int orderLineId);
    }
}
