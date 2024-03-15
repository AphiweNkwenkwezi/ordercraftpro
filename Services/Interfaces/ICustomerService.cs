using OrderCraftPro.Models;

namespace OrderCraftPro.Services.Interfaces
{
    public interface ICustomerService
    {
        Task UpdateCustomerAsync(Customer editedCustomer);
        Task AddCustomerAsync(Customer customer);
        Task<List<Customer>> GetAllCustomersAsync();
        Customer GetCustomerById(Guid id);
        List<Customer> GetAllCustomers();
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Guid customerId);
    }
}
