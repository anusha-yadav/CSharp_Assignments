using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using Web_App.Data;
using Web_App.Models;
using System.Diagnostics;

namespace Web_App.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ECommerceContext? _context;

        public CategoryController(ECommerceContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            {
                Debug.WriteLine($"Category Name {category.Name}");
                _context.Categories.Add(category);
                _context.SaveChanges();
                return PartialView("_Success");
            }
            return PartialView("_Error");
        }

        public IActionResult Delete()
        {
            return View();
        }

        /*public async IActionResult Delete(int? CategoryID) 
        { 
            if(CategoryID == null || _context.)
            {
                return NotFound();
            }

            var category = await _context.Categories.
        }*/

    }
}
