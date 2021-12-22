using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHandbookSite.Domain;
using MyHandbookSite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHandbookSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TypesController : Controller
    {
        private readonly DataManager _dataManager;
        public TypesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            ViewBag.TypeId = id;
            return View(_dataManager.Items.FindByType(id));
        }

        [HttpPost]
        public IActionResult Add(ItemType type)
        {
            _dataManager.ItemTypes.Add(type);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            _dataManager.ItemTypes.Remove(id);
            _dataManager.Items.RemoveByType(id);
            return RedirectToAction("Index", "Home");
        }
    }
}
