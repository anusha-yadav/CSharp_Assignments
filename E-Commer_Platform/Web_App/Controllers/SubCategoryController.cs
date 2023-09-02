using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web_App.Data;
using Web_App.Models;

namespace Web_App.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly ECommerceContext _context;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.categoryList = new SelectList(_context.Categories, "CategoryID", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(SubCategory sctg)
        {
            if (ModelState.IsValid)
            {
                _context.SubCategories.Add(sctg);
                _context.SaveChanges();
                return PartialView("_Success");
            }
            return PartialView("_Error");
        }
    }
}
