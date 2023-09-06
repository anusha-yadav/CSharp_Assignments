using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_App.Data;
using Web_App.Models;

namespace Web_App.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ECommerceContext _context;
        private readonly IWebHostEnvironment _environment;

        public ProductsController(ECommerceContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _environment = hostEnvironment;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var eCommerceContext = _context.Products.Include(p => p.Category).Include(p => p.SubCategory);
            return View(await eCommerceContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.SubCategory)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            ViewData["SubCategoryID"] = new SelectList(_context.SubCategories, "SubCategoryID", "SubCategoryID");
            ViewData["SubCaregoryName"] = new SelectList(_context.SubCategories, "Name", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            string uniqueFileName = null;
            if (product.ImageFile!=null)
            {
                string ImageFile = Path.Combine(_environment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + product.ImageFile.FileName;
                string filepath = Path.Combine(ImageFile, uniqueFileName);


                /*string wwwRoothPath = _environment.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string extension = Path.GetExtension(product.ImageFile.FileName);
                product.PicturePath = filename + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRoothPath + "/images/", filename);*/
                using(var fileStream = new FileStream(filepath, FileMode.Create))
                {
                    await product.ImageFile.CopyToAsync(fileStream);
                }

                //product.PicturePath = "~/wwwroot/images";
                product.PicturePath = uniqueFileName;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryID);
            ViewData["SubCategoryID"] = new SelectList(_context.SubCategories, "SubCategoryID", "SubCategoryID", product.SubCategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryID);
            ViewData["SubCategoryID"] = new SelectList(_context.SubCategories, "SubCategoryID", "SubCategoryID", product.SubCategoryID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,Name,Quantity,Price,PicturePath,Description,CategoryID,SubCategoryID")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
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
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryID);
            ViewData["SubCategoryID"] = new SelectList(_context.SubCategories, "SubCategoryID", "SubCategoryID", product.SubCategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.SubCategory)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
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
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.ProductID == id)).GetValueOrDefault();
        }

        public IActionResult RenderSubCategory()
        {
            ViewData["SubCategoryName"] = new SelectList(_context.SubCategories, "Name", "Name");
            return PartialView("_SubCategory");
        }
    }
}
