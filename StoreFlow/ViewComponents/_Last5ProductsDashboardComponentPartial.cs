using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents
{
    public class _Last5ProductsDashboardComponentPartial : ViewComponent
    {
        private readonly StoreContext _context;

        public _Last5ProductsDashboardComponentPartial(StoreContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Products.OrderBy(x => x.ProductId).ToList().SkipLast(5).TakeLast(7).ToList();
            return View(values);
        }
    }
}
