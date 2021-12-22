using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyHandbookSite.Domain;
using MyHandbookSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHandbookSite.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<MyHandbookSiteUser> _userManager;
        private SignInManager<MyHandbookSiteUser> _signInManager;
        
        public AccountController(SignInManager<MyHandbookSiteUser> signInManager, UserManager<MyHandbookSiteUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUri)
        {
            ViewBag.ReturnUri = returnUri;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                MyHandbookSiteUser user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.UserName), "Неверный логин или пароль");
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        
        public async Task<IActionResult> Profile(string id)
        { 
            var user = await _userManager.FindByIdAsync(id.ToString());
            if(await _userManager.IsInRoleAsync(user, "Admin"))
            {
                return RedirectToAction("Home", "Admin");
            }
            else
            {
                return View();
            }
  
        }

        public IActionResult AccessDenied()
        {
            return View();
        }    
    }
}
