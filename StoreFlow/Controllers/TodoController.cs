using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreFlow.Context;
using StoreFlow.Entities;

namespace StoreFlow.Controllers
{
    public class TodoController : Controller
    {
        private readonly StoreContext _context;

        public TodoController(StoreContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TodoList()
        {
            var values = _context.Todos.ToList();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateToDo()
        {
            var todos = new List<Todo>
            {
                new Todo { Description = "Buy groceries", Status = false, Priority = "Birincil" },
                new Todo { Description = "Clean the house", Status = false, Priority = "Ikincil" },
                new Todo { Description = "Finish work project", Status = false, Priority = "Ucuncul" },
                new Todo { Description = "Exercise", Status = false, Priority = "Dorduncul" },
            };
            await _context.AddRangeAsync(todos);
            await _context.SaveChangesAsync();
            return View();
        }

        public IActionResult TodoAggregatePriority()
        {
            var prioristFirstlyTodo = _context.Todos.Where(x => x.Priority == "Birincil").Select(y => y.Description).ToList();
            string result = prioristFirstlyTodo.Aggregate((acc, desc) => acc + ", " + desc);
            ViewBag.Result = result;
            return View();
        }

        public IActionResult IncompleteTask()
        {
            var values = _context.Todos.Where(x => !x.Status).Select(y => y.Description).ToList().Append("Gun Sonunda butun gorevleri kontrol etmeyi unutmayin").ToList();
            return View(values);
        }

        public IActionResult TodoChunk()
        { 
            var values = _context.Todos.Where(x => !x.Status).ToList().Chunk(2).ToList();
            return View(values);
        }

        public IActionResult TodoConcat()
        { 
            var values = _context.Todos.Where(x => x.Priority == "Birincil").ToList().Concat(_context.Todos.Where(x => x.Priority == "İkincil").ToList());
            return View(values);
        }

        public IActionResult TodoUnion()
        {
            var values = _context.Todos.Where(x => x.Priority == "Birincil").ToList();
            var values2 = _context.Todos.Where(x => x.Priority == "İkincil").ToList();
            var result = values.UnionBy(values2, x => x.Description).ToList();
            return View(result);
        }
    }
}
