using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreFlow.Context;

namespace StoreFlow.ViewComponents.StatisticsViewComponents
{
    public class _StatisticsWidgetComponentPartial : ViewComponent
    {
        private readonly StoreContext _context;

        public _StatisticsWidgetComponentPartial(StoreContext context)
        {
            _context  = context;
        }
        public IViewComponentResult Invoke()
        { 
            ViewBag.categoryCount = _context.Categories.Count();
            ViewBag.productMaxPrice = _context.Products.Max(x => x.ProductPrice);
            ViewBag.productMinPrice = _context.Products.Min(x => x.ProductPrice);            
            ViewBag.productMaxPriceProductName = _context.Products.Where(x => x.ProductPrice == _context.Products.Max(x => x.ProductPrice)).Select(z => z.ProductName).FirstOrDefault();
            ViewBag.productMinPriceProductName = _context.Products.Where(x => x.ProductPrice == _context.Products.Min(x => x.ProductPrice)).Select(z => z.ProductName).FirstOrDefault();

            ViewBag.totalSumProductCount = _context.Products.Sum(x => x.ProductStock);
            ViewBag.avarageProductStock = _context.Products.Average(x => x.ProductStock);
            ViewBag.avarageProductPrice = _context.Products.Average(x =>x.ProductPrice);

            ViewBag.biggerPriceThen1000ProductCount = _context.Products.Where(x => x.ProductPrice > 1000).Count();
            ViewBag.getIdIs4ProductName = _context.Products.Where(x => x.ProductId == 4).Select(y => y.ProductName).FirstOrDefault();
            ViewBag.stockCountBigger50AndSmaller100ProductCount = _context.Products.Where(x => x.ProductStock > 50 && x.ProductStock < 100).Count();
            return View();
        }
    }
}
