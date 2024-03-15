using System.ComponentModel.DataAnnotations.Schema;

namespace OrderCraftPro.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ProductName { get; set; } = null!;
        public string ProductCode { get; set; } = null!;
        public Guid ProductTypeId { get; set; }
        public ProductType ProductType { get; set; } = null!;

        [Column(TypeName = "decimal(6, 2 )")]
        public decimal Price { get; set; }  
    }
}
