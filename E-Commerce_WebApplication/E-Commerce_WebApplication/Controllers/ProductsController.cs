using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Commerce_WebApplication.Data;
using E_Commerce_WebApplication.Models;
using System.Diagnostics;

namespace E_Commerce_WebApplication.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ECommerceContext _context;
        private readonly IWebHostEnvironment _environment;

        public ProductsController(ECommerceContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var eCommerceContext = _context.Products.Include(p => p.SubCategory);
            return View(await eCommerceContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.SubCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "Id");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile ImageFile, Products products)
        {
            Debug.WriteLine("Hi");
            if (ImageFile != null)
            {
                Debug.WriteLine("Hi");
                var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwRoot/uploads");
                if (uploadDirectory == null)
                {
                    Directory.CreateDirectory(uploadDirectory);
                }
                //string _ImageFile = Path.Combine(_environment.WebRootPath, "uploads");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                string filepath = Path.Combine(uploadDirectory, uniqueFileName);


                using (var fileStream = new FileStream(filepath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(fileStream);
                }

                products.ImageUrl = "/uploads/" + uniqueFileName;
                _context.Products.Add(products);
                await _context.SaveChangesAsync();
                return PartialView("_Success");

            }
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "Id", products.SubCategoryId);
            var subcategories = _context.SubCategories.Where(c => c.CategoryId == 1).ToList();
            ViewData["SubCategoryName"] = new SelectList(subcategories, "Value", "Text", products.SubCategory.Name);
            return View(products);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "Id", products.SubCategoryId);
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,Price,SubCategoryId,ImageUrl,Description")] Products products)
        {
            if (id != products.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubCategoryId"] = new SelectList(_context.SubCategories, "Id", "Id", products.SubCategoryId);
            return View(products);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.SubCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ECommerceContext.Products'  is null.");
            }
            var products = await _context.Products.FindAsync(id);
            if (products != null)
            {
                _context.Products.Remove(products);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public IActionResult ProductDetail(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(); // Handle product not found
            }
            return View(product);
        }

        public ActionResult SubCategoryDropdown()
        {
            var subcategories = _context.SubCategories.Where(c => c.CategoryId == 1).ToList();
            var subcategoryListItems = subcategories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });

            return PartialView("_SubCategoryDropdown", subcategoryListItems);
        }

        public IActionResult Search(string searchItem)
        {
            var products = _context.Products.Where(product => product.ProductName.Contains(searchItem)).ToList();
            return View(products);
        }
    }
}
