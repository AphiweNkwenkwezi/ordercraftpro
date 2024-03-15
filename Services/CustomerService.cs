using OrderCraftPro.Models;
using OrderCraftPro.Repositories;
using OrderCraftPro.Repositories.Interfaces;
using OrderCraftPro.Services.Interfaces;

namespace OrderCraftPro.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }
        public async Task AddCustomerAsync(Customer customer)
        {
            await _customerRepository.AddCustomerAsync(customer);
        }
        public async Task UpdateCustomerAsync(Customer editedCustomer)
        {
            try
            {
                await _customerRepository.UpdateCustomerAsync(editedCustomer);
            }
            catch (Exception ex)
            {
                throw; // Rethrow the exception or handle it accordingly
            }
        }

        public Customer? GetCustomerById(Guid id) 
        {
            return _customerRepository.GetCustomer(id);
        }
        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        public void AddCustomer(Customer customer)
        {
            _customerRepository.CreateCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.UpdateCustomer(customer);
        }

        public void DeleteCustomer(Guid customerId)
        {
            _customerRepository.DeleteCustomer(customerId);
        }
    }
}
