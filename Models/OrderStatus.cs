namespace OrderCraftPro.Models
{
    public class OrderStatus
    {
        public static string New = "New";
        public static string Processing = "Processing";
        public static string Completed = "Completed";
        public Guid Id { get; set; } = Guid.NewGuid();
        public string StatusName { get; set; } = null!;
    }
}