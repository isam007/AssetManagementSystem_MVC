using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG.ATS.BLL;
using CPRG214.ATS.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CPRG214.ATS.AssetTracker.Controllers
{
    public class ManufacturerController : Controller
    {
        IManufacturerManager _manufacturerManager;
        public ManufacturerController(IManufacturerManager manufacturerMgr)
        {
           _manufacturerManager = manufacturerMgr;
        }
        public ActionResult Index()
        {
            var manufacturers = _manufacturerManager.GetAll();
            return View(manufacturers);
        }

        // GET: AssetType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Owner/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Manufacturer manufacturer)
        {
            try
            {
                //call the OwnerManager to add
                _manufacturerManager.Add(manufacturer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var originalManufacturer = _manufacturerManager.Find(id);
            return View(originalManufacturer);
        }

        // POST: Asset/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Manufacturer Manufacturer)
        {
            try
            {
                // TODO: Add update logic here
                _manufacturerManager.Update(Manufacturer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
