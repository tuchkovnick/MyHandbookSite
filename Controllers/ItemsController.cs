using Microsoft.AspNetCore.Mvc;
using MyHandbookSite.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHandbookSite.Controllers
{
    public class ItemsController : Controller
    {
        private readonly DataManager _dataManager;

        public ItemsController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult Type(Guid id)
        {
            return View(_dataManager.Items.FindByType(id));
        }
        
        [HttpGet]
        public IActionResult Search(string parameter)
        {
            return View("Type", _dataManager.Items.FindByParameter(parameter));
        }
    }
}
