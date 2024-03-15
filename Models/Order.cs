using Microsoft.Extensions.Logging.Abstractions;
using System.Net;

namespace OrderCraftPro.Models
{

    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string OrderNumber { get; set; } = null!;
        public DateTime OrderPlaced { get; set; }
        public DateTime? OrderFulfilled { get; set; }
        public Guid TypeId { get; set; }
        public OrderType OrderType { get; set; } = null!;   
        public Guid StatusId { get; set; }
        public OrderStatus OrderStatus { get; set; } = null!;
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public ICollection<OrderLine> OrderLines { get; set; } = null!;

        public Order()
        {
        }

        public Order(Order order)
        {
            OrderNumber = order.OrderNumber;
            OrderPlaced = order.OrderPlaced;
            OrderFulfilled = order.OrderFulfilled;
            TypeId = order.TypeId;
            OrderType = order.OrderType;
            StatusId = order.StatusId;
            OrderStatus = order.OrderStatus;
            CustomerId = order.CustomerId;
            Customer = order.Customer;
        }
    }
}