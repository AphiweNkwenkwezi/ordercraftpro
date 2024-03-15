using Microsoft.Extensions.Logging.Abstractions;

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
    }
}