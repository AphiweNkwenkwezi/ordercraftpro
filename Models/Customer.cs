using Microsoft.AspNetCore.Identity;

namespace OrderCraftPro.Models
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid(); 
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public ICollection<Order> Orders { get; set; } = null!;

        // Default constructor
        public Customer()
        {
            // Default constructor
        }

        // Copy constructor
        public Customer(Customer other)
        {
            FirstName = other.FirstName;
            LastName = other.LastName;
            Phone = other.Phone;
            Address = other.Address;
            Email = other.Email;
        }
    }
}
