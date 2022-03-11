using Classwork.Constants;
using Classwork.DAL;
using Classwork.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classwork.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = RoleConstants.Admin)]
    public class CategoryController : Controller
    {
        
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
      
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            return View(categories);
        }
        public async Task<IActionResult> Detail(int id)
        {
           var category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();
            
            return View(category);
        }
        public IActionResult Create()
        {
           

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int Id)
        {
            Category category = await _context.Categories.FindAsync(Id);
            if (category == null) return NotFound();
           
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int Id, Category category)
        {
            Category Dbcategory = await _context.Categories.FindAsync(Id);
            if (category == null) return NotFound();
            if (Id != category.Id) return BadRequest();
            if (!ModelState.IsValid) return View();
            Dbcategory.Name = category.Name;
            Dbcategory.Desc = category.Desc;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int Id)
        {
            Category category = await _context.Categories.FindAsync(Id);
            if (category == null) return NotFound();
            return View(category);

        }
        [HttpPost]

        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteCategory(int Id)
        {
            Category category = await _context.Categories.FindAsync(Id);
            if (category == null) return NotFound();
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
    }
}
