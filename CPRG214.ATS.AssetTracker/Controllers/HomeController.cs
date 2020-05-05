using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG.ATS.BLL;
using CPRG214.ATS.AssetTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPRG214.ATS.AssetTracker.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //var assets = AssetManager.GetAll();
            //var viewModels = assets.Select(r => new AssetViewModel
            //{
            //    Id = r.Id,
            //    Description = r.Description,
            //    AssetType = r.AssetType.Name,
            //    TagNumber = r.TagNumber,
            //    SerialNumber = r.SerialNumber,
                
            //}).ToList();
            ////call a local service to get collection of assets as the viewmodel
            //return View(viewModels);
            return View();
        }

    }
}