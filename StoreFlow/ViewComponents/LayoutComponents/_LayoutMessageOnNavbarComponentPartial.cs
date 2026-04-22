using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents.LayoutComponents
{
    public class _LayoutMessageOnNavbarComponentPartial : ViewComponent
    {
        private readonly StoreContext _context;

        public _LayoutMessageOnNavbarComponentPartial(StoreContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Messages.Where(x => x.IsRead == false).OrderByDescending(x => x.MessageId).Take(5).ToList();
            ViewBag.MessageCount = _context.Messages.Where(x => x.IsRead == false).Count();
            return View(values);
        }
    }
}
