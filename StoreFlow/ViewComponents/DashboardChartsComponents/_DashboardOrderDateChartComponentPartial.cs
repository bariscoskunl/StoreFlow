using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreFlow.Context;
using StoreFlow.Models;

namespace StoreFlow.ViewComponents.DashboardChartsComponents
{
    public class _DashboardOrderDateChartComponentPartial : ViewComponent
    {
        private readonly StoreContext _context;

        public _DashboardOrderDateChartComponentPartial(StoreContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var data = _context.Orders.GroupBy(o => o.OrderDate.Date).Select(g => new 
            {
               rawDate = g.Key,              
               Count = g.Count()
            })
            .OrderBy(d => d.rawDate)
            .ToList()
            .Select(d => new OrderDateViewModel
            {
                Date = d.rawDate.ToString("yyyy-MM-dd"),
                Count = d.Count
            }).ToList();
            return View(data);
        }
    }
}
