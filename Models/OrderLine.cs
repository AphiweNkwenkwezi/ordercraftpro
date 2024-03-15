using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderCraftPro.Models
{
    public class OrderLine
    {
        [Key]
        public int LineNumber { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;
        
        [Column(TypeName = "decimal(6, 2)")]
        public decimal CostPrice { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal SalesPrice { get; set; }
        public DateTime OrderDate { get; set; }  
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}