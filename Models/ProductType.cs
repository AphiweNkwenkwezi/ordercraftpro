namespace OrderCraftPro.Models
{
    public class ProductType
    {
        public static string Apparel = "Apparel"; //1
        public static string Parts = "Parts"; //2
        public static string Equipment = "Equipment"; //3
        public static string Motor = "Motor"; //4
        public Guid Id { get; set; }
        public string TypeName { get; set; } = null!;
    }
}