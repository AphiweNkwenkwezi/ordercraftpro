namespace OrderCraftPro.Enums
{
    public enum eOrderType
    {
        Staff,
        Normal,
        Perishable,
        Mechanical
    }

    public enum eOrderStatus
    {
        New,
        Processing,
        Completed
    }

    public enum eProductType
    {
        Apparel = 1,
        Parts = 2,
        Equipment = 3,
        Motor = 4
    }
}
