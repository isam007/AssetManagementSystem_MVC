using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG.ATS.BLL;
using CPRG214.ATS.AssetTracker.Models;
using CPRG214.ATS.Data;
using CPRG214.ATS.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CPRG214.ATS.AssetTracker.Controllers
{
    public class AssetController : Controller
    {
        IAssetManager        _assetManager;
        IAssetTypeManager    _assetTypeManager;
        IManufacturerManager _manufacturerManager;
        public AssetController(IAssetManager        assetMgr,
                               IAssetTypeManager    assetTypeMgr,
                               IManufacturerManager manufacturerMgr)
        {
            _assetManager        = assetMgr;
            _assetTypeManager    = assetTypeMgr;
            _manufacturerManager = manufacturerMgr;
        }
        public IActionResult Search()
        {
            ViewBag.AssetTypes = GetAssetTypes();
            return View();
        }

        public IActionResult GetAssetsByType(int id)
        {
            return ViewComponent("AssetsByType", id);
        }
        public IActionResult Assets(int id)
        {
            //go to the rentals manager, get all the rentals of this property type
            var filteredAssets = _assetManager.GetAllByAssetType(id);
            var result = $"Asset Count: {filteredAssets.Count}";
            return Content(result);
        }
        // GET: Asset
        public ActionResult Index()
        {
            var assets = _assetManager.GetAll();
            var viewModels = assets.Select(a => new AssetViewModel
            {
                Id = a.Id,
                Description = a.Description,
                Manufacturer = a.Manufacturer.Name,
                AssetType = a.AssetType.Name,
                TagNumber = a.TagNumber,
                SerialNumber = a.SerialNumber,

            }).ToList();
            //call a local service to get collection of assets as the viewmodel
            return View(viewModels);

        }

        // GET: Asset/Details/5
        public ActionResult Details(int id)
        {
            var originalAsset = _assetManager.GetDetails(id);
            return View(originalAsset);
        }
        
        protected IEnumerable GetAssetTypes()
        {
            //create the collection of property types select list items
            var types = _assetTypeManager.GetAsKeyValuePairs();
            var brands = new SelectList(types, "Value", "Text");

            var assetTypesList = brands.ToList();
            assetTypesList.Insert(0, new SelectListItem
            {
                Text = "Select Asset Types",
                Value = "0"
            });
            return assetTypesList;
        }

        // GET: Asset/Create
        public ActionResult Create()
        {
            // call the asset manager and manufacturer manager to get the collection of key value objects
            
            var manufacturers = _manufacturerManager.GetAsKeyValuePairs();

            //create a collection of SelectListItems (get list from AssetType table). "Value" & "Text should match those assigned in AssetTypeManager
            
            var manufacturerList = new SelectList(manufacturers, "Value", "Text");

            //create the collection of manufacturers select list items "Value" & "Text should match those assigned in ManufacturerManager
            ViewBag.ManufacturerId = manufacturerList;

            
            ViewBag.AssetTypeId = GetAssetTypes();
            return View();
        }

        // POST: Asset/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Asset asset)
        {
            try
            {
                // TODO: Add insert logic here
                _assetManager.Add(asset);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Asset/Edit/5
        public ActionResult Edit(int id)
        {
            var originalAsset = _assetManager.Find(id);
            
            var manufacturers = _manufacturerManager.GetAsKeyValuePairs();
            var manufacturerList = new SelectList(manufacturers, "Value", "Text");
            ViewBag.ManufacturerId = manufacturerList;
            ViewBag.AssetTypeId = GetAssetTypes();
            return View(originalAsset);
        }

        // POST: Asset/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Asset asset)
        {
            try
            {
                // TODO: Add update logic here
                _assetManager.Update(asset);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Asset/Delete/5
        public ActionResult Delete(int id)
        {
            var originalAsset = _assetManager.GetDetails(id);
            return View(originalAsset);
        }

        // POST: Asset/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Asset asset)
        {
            try
            {
                // TODO: Add insert logic here
                _assetManager.Remove(asset);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}