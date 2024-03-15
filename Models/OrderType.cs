namespace OrderCraftPro.Models
{
    public class OrderType
    {
        public static string Staff = "Staff";
        public static string Normal = "Normal";
        public static string Perishable = "Perishable";
        public static string Mechanical = "Mechanical";
        public Guid Id { get; set; } = Guid.NewGuid();
        public string TypeName { get; set; } = null!;
    }
}