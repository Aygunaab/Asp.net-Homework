using Classwork.Constants;
using Classwork.DAL;
using Classwork.Models;
using Classwork.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Classwork.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LayoutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public LayoutController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var layout = await _context.Layouts.ToListAsync();
            return View(layout);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var layout = await _context.Layouts.FindAsync(id);
            if (layout == null) return NotFound();

            return View(layout);
        }

        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Layout layout)
        {
            if (!ModelState.IsValid) return View();
            if (layout.LogoFile.ContentType.Contains("Logo"))
            {
                ModelState.AddModelError(nameof(layout.LogoFile), "File is unsupported ,please select image ");
                return View();
            }
            if (layout.LogoFile.Length > 1024 * 1024)
            {
                ModelState.AddModelError(nameof(layout.LogoFile), "File size cannot be greater than 1 mb  ");
                return View();
            }

            //var FolderPath = FileConstants.ImagePath;
            //var LogoName = Guid.NewGuid()+layout.LogoFile.FileName ;
           
           
            //FileStream fileStream = new FileStream(FullPath, FileMode.Create);
            //await layout.LogoFile.CopyToAsync(fileStream);
            //fileStream.Close();
            layout.Logo = FileUtils.Create(FileConstants.ImagePath, layout.LogoFile);
         
           
            await _context.Layouts.AddAsync(layout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int Id)
        {
            Layout layout = await _context.Layouts.FindAsync(Id);
            if (layout == null) return NotFound();

            return View(layout);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int Id, Layout layout)
        {
            var dblayout = await _context.Layouts.FindAsync(Id);
            if (layout == null) return NotFound();
            if (Id != layout.Id) return BadRequest();
            if (!ModelState.IsValid) return View();
        
            var FullPath = FileConstants.ImagePath;
            var LogoName = Guid.NewGuid() + layout.LogoFile.FileName;


            FileStream fileStream = new FileStream(FullPath, FileMode.Append);
            await layout.LogoFile.CopyToAsync(fileStream);
            fileStream.Close();
            dblayout.LogoFile = layout.LogoFile;
            dblayout.InstagramUrl = layout.InstagramUrl;
            dblayout.FacebookUrl = layout.FacebookUrl;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var layout = await _context.Layouts.FindAsync(id);
            if (layout == null) return NotFound();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteLayout(int id)
        {
            var layout = await _context.Layouts.FindAsync(id);
            if (layout == null) return NotFound();
            _context.Layouts.Remove(layout);
            await _context.SaveChangesAsync();

            FileUtils.Delete(Path.Combine(FileConstants.ImagePath, layout.Logo));


            return RedirectToAction(nameof(Index));
        }
    }
}
