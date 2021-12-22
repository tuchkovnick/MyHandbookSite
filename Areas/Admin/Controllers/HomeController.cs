﻿using Microsoft.AspNetCore.Mvc;
using MyHandbookSite.Domain;

namespace MyHandbookSite.Areas.Admin.Controllers
{
 
    [Area("Admin")]    
    public class HomeController : Controller
    {
        private readonly DataManager _dataManager;
        public HomeController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_dataManager.ItemTypes.GetAll());
        }
  
    }
}
