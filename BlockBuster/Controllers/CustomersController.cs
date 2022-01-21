using BlockBuster.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlockBuster.Controllers
{
    public class CustomersController : Controller
    {
        public ViewResult Index()
        {
            List<Customer> customers = GetCustomers();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            Customer customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer is null)
            {
                return StatusCode(404);
            }

            return View(customer);
        }

        private List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }
    }
}
