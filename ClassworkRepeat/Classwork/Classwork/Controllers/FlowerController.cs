using Classwork.DAL;
using Classwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classwork.Controllers
{
    public class FlowerController:Controller
    {
        private readonly AppDbContext _context;

        public FlowerController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
          
            return View();
        }
        public async Task<IActionResult> Detail(int id, int categoryId)
        {
            Flower flower = await  _context.Flowers.Include(f => f.FlowerImages).Include(f => f.FlowerCategories).ThenInclude(fc => fc.Category).FirstOrDefaultAsync(f => f.Id == id);
            if (flower == null) return NotFound();
            //ViewBag.Related = _context.FlowerCategories.Where(fc => fc.CategoryId == categoryId && fc.FlowerId!=flower.Id).Include(fc=>fc.Flower).ToList();
            ViewBag.Related = await _context.Flowers.Where(f => f.FlowerCategories.FirstOrDefault(fc => fc.CategoryId == categoryId).CategoryId == categoryId && f.Id != flower.Id).Include(f => f.FlowerImages).Include(f => f.FlowerCategories).ThenInclude(fc => fc.Category).ToListAsync();
            return View(flower);
        }

       
    }
}
