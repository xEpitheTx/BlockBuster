using AutoMapper;
using BlockBuster.Data;
using BlockBuster.Models;
using BlockBuster.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlockBuster.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        private const string formViewName = "CustomerForm";
        //private readonly IMapper _mapper;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
            //_mapper = mapper;

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType);
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            Customer customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer is null)
            {
                return StatusCode(404);
            }

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
#if DEBUG
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();
#endif

            bool diditwork = ModelState.Remove("customer.MembershipType"); //I have no idea why MembershipType is required and this is a shameless hack
            if (!ModelState.IsValid)
            {
                CustomerFormViewModel? viewModel = new CustomerFormViewModel()
                {
                    MembershipTypes = _context.MembershipType.ToList()
                };

                return View(formViewName, viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
            else
            {
                UpdateExistingCustomer(customer);
            }

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer is null)
            {
                return StatusCode(404);
            }

            CustomerFormViewModel? viewModel = new CustomerFormViewModel(customer)
            {
                MembershipTypes = _context.MembershipType.ToList()
            };

            return View(formViewName, viewModel);
        }

        public ActionResult NewCustomer()
        {
            List<MembershipType>? membershipTypes = _context.MembershipType.ToList();
            CustomerFormViewModel? viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View(formViewName, viewModel);
        }
        private void UpdateExistingCustomer(Customer customer)
        {
            Customer? customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
            if (customerInDb != null)
            {
                //Couldn't get mapper to work, sadness
                //customerInDb = _mapper.Map<Customer>(customerInDb);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeID = customer.MembershipTypeID;
                customerInDb.IsSubscribed = customer.IsSubscribed;
                _context.SaveChanges();
            }
            else
            {
                //throw error customer not found
            }
        }
    }
}
