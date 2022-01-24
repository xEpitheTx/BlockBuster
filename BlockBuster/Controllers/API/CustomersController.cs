using BlockBuster.Data;
using BlockBuster.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace BlockBuster.Controllers.API
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomer(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer is null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            return customer;
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        [Microsoft.AspNetCore.Mvc.HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }

            Customer customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb is null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.IsSubscribed = customer.IsSubscribed;
            customerInDb.MembershipTypeID = customer.MembershipTypeID;

            _context.SaveChanges();
        }

        [Microsoft.AspNetCore.Mvc.HttpDelete]
        public void DeleteCustomer(int id)
        {
            Customer customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb is null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
