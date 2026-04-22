using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;
using System.Linq;

namespace StoreFlow.ViewComponents._RightSidebarComponents
{
    public class _RightSidebarMessageComponentPartial : ViewComponent
    {
        private readonly StoreContext _context;

        public _RightSidebarMessageComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {           
            var values = _context.Messages
                                 .Where(x => x.IsRead == false)
                                 .OrderByDescending(x => x.Datetime)
                                 .ToList();
            return View(values);
        }
    }
}