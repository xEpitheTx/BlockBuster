using BlockBuster.Data;
using BlockBuster.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlockBuster.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext _context)
        {
            this._context = _context;    
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var customers = _context.Customers;
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer is null)
            {
                return StatusCode(404);
            }

            return View(customer);
        }
    }
}
