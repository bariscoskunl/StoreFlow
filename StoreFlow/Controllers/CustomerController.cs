using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;
using StoreFlow.Entities;
using StoreFlow.Models;

namespace StoreFlow.Controllers
{
    public class CustomerController : Controller
    {
        private readonly StoreContext _context;

        public CustomerController(StoreContext context)
        {
            _context = context;
        }
        public IActionResult CustomerListOrderByCustomerName()
        {
            var values = _context.Customers.OrderBy(x => x.CustomerName).ThenBy(x => x.CustomerSurname).ToList();
            return View(values);
        }

        public IActionResult CustomerListOrderByDescBalance()
        {
            var values = _context.Customers.OrderByDescending(x => x.CustomerBalance).ToList();
            return View(values);
        }

        public IActionResult CustomerGetByCity(string city)
        {
            var exist = _context.Customers.Any(x => x.CustomerCity == city);
            if (exist)
            {
                TempData["message"] = $"{city} Sehrinde en az 1 tane musteri var";
            }
            else
            {
                TempData["error"] = $"{city} Sehrinde hic musteri yok";
            }
            return View();
        }


        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction(nameof(CustomerListOrderByCustomerName));
        }


        public IActionResult DeleteCustomer(int id)
        {
            var value = _context.Customers.Find(id);
            _context.Customers.Remove(value);
            _context.SaveChanges();
            return RedirectToAction(nameof(CustomerListOrderByCustomerName));
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            var value = _context.Customers.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return RedirectToAction(nameof(CustomerListOrderByCustomerName));
        }

        public IActionResult CustomerListByCity()
        {
            var groupedCustomers = _context.Customers.ToList().GroupBy(x => x.CustomerCity).ToList();
            return View(groupedCustomers);
        }
        public IActionResult CustomersByCityCount()
        {
            var query =
                from c in _context.Customers
                group c by c.CustomerCity into cityGroup
                select new CustomerCityGroup
                {
                    City = cityGroup.Key,
                    CustomerCount = cityGroup.Count()
                };
            var model = query.ToList();
            return View(model);
        }

        public IActionResult CustomerCityList()
        {
            var values = _context.Customers.Select(x => x.CustomerCity).Distinct().ToList();
            return View(values);
        }

        public IActionResult ParallelCustomers()
        {
            var customers = _context.Customers.ToList();
            var result = customers.AsParallel().Where(c => c.CustomerCity.StartsWith("A", StringComparison.OrdinalIgnoreCase)).ToList();
            return View(result);
        }

        public IActionResult CustomerListExceptIstanbul()
        {
            var result = _context.Customers.ToList()
                .ExceptBy(_context.Customers
                .Where(c => c.CustomerCity == "İstanbul")
                .Select(c => c.CustomerId), c => c.CustomerId)
                .ToList();
            return View(result);
        }

        public IActionResult CustomerListWithDefaultIfEmpty()
        {
            var customers = _context.Customers.Where(c => c.CustomerCity == "Ankara").ToList().DefaultIfEmpty(new Customer
            {
                CustomerId = 0,
                CustomerName = "Kayit Yok",
                CustomerSurname = "",
                CustomerCity = "Ankara",
            }).ToList();
            return View(customers);
        }

        public IActionResult CustomerIntersectByCity()
        {
            var cityValues1 = _context.Customers.Where(x => x.CustomerCity == "İstanbul").Select(y => y.CustomerName + " " + y.CustomerSurname).ToList();
            var cityValues2 = _context.Customers.Where(x => x.CustomerCity == "Ankara").Select(y => y.CustomerName + " " + y.CustomerSurname).ToList();
            var intersectValues = cityValues1.Intersect(cityValues2).ToList();
            return View(intersectValues);
        }

        public IActionResult CustomerCastExcample()
        { 
            var values = _context.Customers.ToList();
            ViewBag.v = values;
            return View();
        }

        public IActionResult CustomerListWithIndex()
        { 
            var customers = _context.Customers.ToList()
                .Select((c, index) => new { 
                    SiraNo = index + 1,
                    c.CustomerName,
                    c.CustomerSurname,
                    c.CustomerCity,
                }).ToList();
            return View(customers);
        }
    }
}
