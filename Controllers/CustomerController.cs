using Microsoft.AspNetCore.Mvc;
using OrderCraftPro.Models;
using OrderCraftPro.Services;
using OrderCraftPro.Services.Interfaces;

namespace OrderCraftPro.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(Guid id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound($"Customer with ID {id} not found");
            }
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            _customerService.AddCustomer(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(Guid id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _customerService.UpdateCustomer(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(Guid id)
        {
            _customerService.DeleteCustomer(id);
            return NoContent();
        }
    }
}
