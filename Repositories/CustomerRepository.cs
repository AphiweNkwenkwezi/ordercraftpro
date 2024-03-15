using Microsoft.EntityFrameworkCore;
using OrderCraftPro.Data;
using OrderCraftPro.Models;
using OrderCraftPro.Repositories.Interfaces;

namespace OrderCraftPro.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OrderCraftProDbContext _context;

        public CustomerRepository(OrderCraftProDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }
        public async Task AddCustomerAsync(Customer customer)
        {
            // Add any additional logic here if needed
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCustomerAsync(Customer editedCustomer)
        {
            try
            {
                _context.Update(editedCustomer);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception($"Customer not saved with error: {ex.Message}");
            }

        }
        public Customer? GetCustomer(Guid id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public void CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(Guid id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }
    }
}
