using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyHandbookSite.Domain;
using MyHandbookSite.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyHandbookSite.Models.ViewComponents
{
    public class LoginViewComponent : ViewComponent
    {
        private readonly UserManager<MyHandbookSiteUser> _userManager;

        public LoginViewComponent(UserManager<MyHandbookSiteUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult)View("UserInfo", _userManager.Users.FirstOrDefault(x => x.Id== HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))));
        }
    }
}
