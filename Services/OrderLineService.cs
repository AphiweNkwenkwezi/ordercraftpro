using OrderCraftPro.Models;
using OrderCraftPro.Repositories.Interfaces;
using OrderCraftPro.Services.Interfaces;

namespace OrderCraftPro.Services
{
    public class OrderLineService : IOrderLineService
    {
        private readonly IOrderLineRepository _orderLineRepository;

        public OrderLineService(IOrderLineRepository orderLineRepository)
        {
            _orderLineRepository = orderLineRepository;
        }

        public List<OrderLine> GetAllOrderLines()
        {
            return _orderLineRepository.GetAllOrderLines();
        }

        public void CreateOrderLine(OrderLine orderLine)
        {
            _orderLineRepository.SaveOrderLine(orderLine);
        }

        public void UpdateOrderLine(OrderLine orderLine)
        {
            _orderLineRepository.UpdateOrderLine(orderLine);
        }

        public void DeleteOrderLine(int orderLineId)
        {
            _orderLineRepository.DeleteOrderLine(orderLineId);
        }
    }
}
