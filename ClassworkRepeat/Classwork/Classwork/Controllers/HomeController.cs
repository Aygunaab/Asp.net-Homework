
using Classwork.DAL;
using Classwork.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Classwork.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async  Task<IActionResult> Index()
        {
            HomeVM model = new HomeVM
            {
                Sliders = await _context.Sliders.OrderBy(s => s.Order).ToListAsync(),
                Experts = await _context.Experts.Include(e => e.Position).Take(4).ToListAsync(),
                Categories = await _context.Categories.OrderByDescending(c => c.Id).Take(6).ToListAsync(),
               
            };
            return View(model);
        }
        //public IActionResult SetSession()
        //{
        //    HttpContext.Session.SetString("p512", "Ali ,Medine,Ricat");
        //    return Content("Elave edildi");
        //}
        //public IActionResult GetSession()
        //{

        //    return Content(HttpContext.Session.GetString("p512"));
        //}
        //public IActionResult CookieSet()
        //{
        //    Response.Cookies.Append("p512", "Aygun,Aylin,Leyla");
        //    return Content("Elave olundu");
        //}
        //public IActionResult CookieGet()
        //{
           
        //    return Content(Request.Cookies["p512"]);
        //}


    }
}
