using Microsoft.AspNetCore.Mvc;
using MyHandbookSite.Domain;
using MyHandbookSite.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHandbookSite.Models.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly DataManager _dataManager;

        public SidebarViewComponent(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult)View("Default", _dataManager.ItemTypes.GetAll()));
        }
    }
}
