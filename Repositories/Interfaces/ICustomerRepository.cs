using OrderCraftPro.Models;

namespace OrderCraftPro.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task UpdateCustomerAsync(Customer editedCustomer);
        Task AddCustomerAsync(Customer customer);
        Task<List<Customer>> GetAllCustomersAsync();
        Customer? GetCustomer(Guid id);
        List<Customer> GetAllCustomers();
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Guid id);
    }
}
