using Classwork.Constants;
using Classwork.Models;
using Classwork.Services;
using Classwork.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classwork.Controllers
{
    public class AccountController : Controller
        
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMailService _mailService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IMailService mailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mailService = mailService;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult >Login(LoginVm model)
        {
            if (!ModelState.IsValid) return View();
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid credentials");
                return View();
            }
           var SignInResult= await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
            if (!SignInResult.Succeeded)
            {
                ModelState.AddModelError("", "Invalid password");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVm model)
        {
            if(!ModelState.IsValid) return View();
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null)
            {
                ModelState.AddModelError("Username", "Bu adda user adi movcuddur");
                return View();
            }

            User newuser = new User
            {
                FulName = model.FullName,
                UserName = model.Username,
                Age = model.Age,
                Email = model.Email,
                Position = model.Position
            };
            IdentityResult IdentityResult = await _userManager.CreateAsync(newuser, model.Password);
            if (!IdentityResult.Succeeded)
            {
                foreach ( var error in IdentityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(newuser, RoleConstants.User);
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(newuser);
            var link = Url.Action(nameof(ConfirmEmail), "Account", new { newuser.UserName, token }, Request.Scheme);
            await _mailService.SendEmailAsync(new MailRequest
            {
                ToEmail=newuser.Email,
                Subject="Comlite registration",
                Body=link


            });

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> ConfirmEmail(string userName,string Token)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null) return BadRequest();
            var identityResult = await _userManager.ConfirmEmailAsync(user, Token);
                if (!identityResult.Succeeded)
            {
                return BadRequest();
            }
            return RedirectToAction("Index", "Home");

        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
