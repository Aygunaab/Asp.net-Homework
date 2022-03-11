using Classwork.Constants;
using Classwork.DAL;
using Classwork.Models;
using Classwork.Utils;
using Microsoft.AspNetCore.Authorization;
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
    //[Authorize(Roles = RoleConstants.Admin)]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public  async Task<IActionResult> Index()
        {
            var sliders = await _context.Sliders.ToListAsync();
            return View(sliders);
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid) return View();
            if (slider.ImageFile.ContentType.Contains("Image"))
            {
                ModelState.AddModelError(nameof(slider.ImageFile), "File is unsupported ,please select image ");
                return View();
            }
            if (slider.ImageFile.Length > 1024 * 1024)
            {
                ModelState.AddModelError(nameof(slider.ImageFile), "File size cannot be greater than 1 mb  ");
                return View();
            }
            if (slider.SignatureImageFile.ContentType.Contains("SignatureImage"))
            {
                ModelState.AddModelError(nameof(slider.SignatureImageFile), "File is unsupported ,please select image ");
                return View();
            }
            if (slider.SignatureImageFile.Length > 1024 * 1024)
            {
                ModelState.AddModelError(nameof(slider.SignatureImageFile), "File size cannot be greater than 1 mb  ");
                return View();
            }
            string wwwRootPath = _env.WebRootPath;

           
          
            //var FolderPath = Path.Combine(wwwRootPath, "images" );
            //var FileName = Guid.NewGuid() + slider.ImageFile.FileName;
            //FileStream fileStream = new FileStream(FullPath, FileMode.Create);
            //await slider.ImageFile.CopyToAsync(fileStream);
            //fileStream.Close();
            //var FileNameSign = Guid.NewGuid() + slider.ImageFile.FileName;
            //var FullPathSign = Path.Combine(wwwRootPath, "images", FileNameSign);
            //FileStream fileStreamSign = new FileStream(FullPath, FileMode.Create);
            //await slider.SignatureImageFile.CopyToAsync(fileStreamSign);
            //fileStreamSign.Close();


            slider.Image = FileUtils.Create(FileConstants.ImagePath, slider.ImageFile);
            slider.SignatureImage =FileUtils.Create(FileConstants.ImagePath, slider.SignatureImageFile);
            slider.RightIcon = "test";
            slider.LeftIcon = "test";
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
           
            FileUtils.Delete(Path.Combine(FileConstants.ImagePath, slider.Image));
            FileUtils.Delete(Path.Combine(FileConstants.ImagePath, slider.SignatureImage));

            return RedirectToAction(nameof(Index));
        }
    }
}
