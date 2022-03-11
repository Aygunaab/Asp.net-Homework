using Classwork.Areas.Admin.ViewModel;
using Classwork.Constants;
using Classwork.DAL;
using Classwork.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classwork.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = RoleConstants.Admin + "," + RoleConstants.Moderator)]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(AppDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

       public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            List<UserVM> userList = new List<UserVM>();
            foreach (var user in users)
            {
                userList.Add(new UserVM
                {
                    Id = user.Id,
                    FullName = user.FulName,
                    UserName = user.UserName,
                    Roles = string.Join(",", await _userManager.GetRolesAsync(user))
                });
            }
            return View(userList);
        }
        public async Task<IActionResult>GetRoles(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null) return NotFound();
            var roles = await _userManager.GetRolesAsync(user);
            ViewBag.Name = user.FulName;
            return View(roles);
        }
        public async Task<IActionResult>RemoveRole(string Id,string roleName)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null) return NotFound();
            await _userManager.RemoveFromRoleAsync(user, roleName);
            return RedirectToAction(nameof(GetRoles), new { user.Id });


        }
    }
}
