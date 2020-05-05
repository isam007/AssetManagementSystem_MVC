using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG.ATS.BLL;
using CPRG214.ATS.AssetTracker.Models;
using CPRG214.ATS.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CPRG214.ATS.AssetTracker.Controllers
{
    public class AssetTypeController : Controller
    {
        IAssetTypeManager _assetTypeManager;
        public AssetTypeController(IAssetTypeManager assetTypeMgr)
        {
            _assetTypeManager = assetTypeMgr;
        }
        public ActionResult Index()
        {
            var assetTypes = _assetTypeManager.GetAll();
            return View(assetTypes);
        }
            
        // GET: AssetType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Owner/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssetType assetType)
        {
            try
            {
                //call the OwnerManager to add
                _assetTypeManager.Add(assetType);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var originalAssetType = _assetTypeManager.Find(id);
            return View(originalAssetType);
        }

        // POST: Asset/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AssetType assetType)
        {
            try
            {
                // TODO: Add update logic here
                _assetTypeManager.Update(assetType);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}