using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreFlow.Context;
using StoreFlow.Entities;
using StoreFlow.Models;

namespace StoreFlow.Controllers
{
    public class OrderController : Controller
    {
        private readonly StoreContext _context;

        public OrderController(StoreContext context)
        {
            _context = context;
        }
        public IActionResult AllStockSmallerThen5()
        {
            bool orderStockCount = _context.Orders.All(x => x.OrderCount <= 5);
            if (orderStockCount)
            {
                TempData["message"] = "Tüm siparişler 5'ten az";
            }
            else
            {
                TempData["error"] = "Tüm siparişler 5'ten az değil";
            }
            return View();
        }

        public IActionResult OrderListByStatus(string status)
        {
            List<Order> list;

            if (string.IsNullOrWhiteSpace(status))
            {
                list = _context.Orders.ToList();
            }
            else
            {
                list = _context.Orders
                    .Where(x => x.Status.Contains(status))
                    .ToList();
            }

            if (!list.Any() && !string.IsNullOrWhiteSpace(status))
            {
                ViewBag.Message = $"{status} durumunda sipariş bulunamadı";
            }

            return View(list);
        }

        public IActionResult OrderListSearch(string name, string filterType)
        {
            if (filterType == "start")
            {
                var values = _context.Orders.Where(x => x.Status.StartsWith(name)).ToList();
                return View(values);
            }
            else if (filterType == "end")
            {
                var values = _context.Orders.Where(x => x.Status.EndsWith(name)).ToList();
                return View(values);

            }
            var orderValues = _context.Orders.ToList();
            return View(orderValues);
        }


        public async Task<IActionResult> OrderList()
        {
            var values = await _context.Orders.Include(x => x.Product).Include(y => y.Customer).ToListAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            var products = await _context.Products
                .Select(x => new SelectListItem
                {
                    Value = x.ProductId.ToString(),
                    Text = x.ProductName
                }).ToListAsync();
            ViewBag.products = products;

            var customers = await _context.Customers
               .Select(x => new SelectListItem
               {
                   Value = x.CustomerId.ToString(),
                   Text = x.CustomerName + " " + x.CustomerSurname
               }).ToListAsync();
            ViewBag.customers = customers;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            order.Status = "Siparis Alindi";
            order.OrderDate = DateTime.Now;
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("OrderList");
        }
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var value = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(value);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(OrderList));
        }

        public async Task<IActionResult> UpdateOrder(int id)
        {
            var value = await _context.Orders.FindAsync(id);
            var products = await _context.Products
                .Select(x => new SelectListItem
                {
                    Value = x.ProductId.ToString(),
                    Text = x.ProductName
                }).ToListAsync();
            ViewBag.products = products;

            var customers = await _context.Customers
               .Select(x => new SelectListItem
               {
                   Value = x.CustomerId.ToString(),
                   Text = x.CustomerName + " " + x.CustomerSurname
               }).ToListAsync();
            ViewBag.customers = customers;

            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(OrderList));
        }

        public IActionResult OrderListWithCustomerGroup()
        {
            var result = from customer in _context.Customers
                         join order in _context.Orders
                         on customer.CustomerId equals order.CustomerId
                         into orderGroup
                         select new CustomerOrderViewModel
                         {
                             CustomerName = customer.CustomerName + " " + customer.CustomerSurname,
                             Orders = orderGroup.ToList()
                         };
                         return View(result.ToList());
        }
    }
}
