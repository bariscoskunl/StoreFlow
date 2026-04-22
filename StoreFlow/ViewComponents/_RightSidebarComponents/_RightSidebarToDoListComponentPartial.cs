using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents._RightSidebarComponents
{
    public class _RightSidebarToDoListComponentPartial : ViewComponent
    {
        private readonly StoreContext _context;

        public _RightSidebarToDoListComponentPartial(StoreContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Todos.OrderBy(x => x.TodoId).ToList().TakeLast(10).ToList();
            return View(values);
        }
    }
}
