
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHandbookSite.Domain;
using MyHandbookSite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyHandbookSite.Areas.Admin.Controllers
{
    [Area ("Admin")]
    public class ItemsController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ItemsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            _dataManager = dataManager;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var item = id == default ? new Item() : _dataManager.Items.FindFirst(id);
            return View(item);            
        }

        [HttpPost]
        public IActionResult Edit(Item model, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                if (uploadedFile != null)
                {
                    model.ImageSource = uploadedFile.FileName;
                    using (var stream = new FileStream(Path.Combine(_hostingEnvironment.WebRootPath, "images/items/", uploadedFile.FileName), FileMode.Create))
                    {
                        uploadedFile.CopyTo(stream);
                    }
                }
                _dataManager.Items.Add(model);
                return RedirectToAction("Edit", "Types", new { id = model.TypeId });
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Add(Guid typeId)
        {
            ViewBag.TypeId = typeId;
            return View(new Item());
        }


        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var typeId = _dataManager.Items.FindFirst(id).TypeId;
            _dataManager.Items.Remove(id);
            return RedirectToAction("Edit", "Types", new { id = typeId });
        }
    }
}