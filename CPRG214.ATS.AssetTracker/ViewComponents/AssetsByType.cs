using CPRG.ATS.BLL;
using CPRG214.ATS.AssetTracker.Models;
using CPRG214.ATS.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.ATS.AssetTracker.ViewComponents
{
    public class AssetsByTypeViewComponent : ViewComponent
    {
        
        IAssetManager _assetManager;

        public AssetsByTypeViewComponent(IAssetManager assetMgr)
        {
            _assetManager = assetMgr;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            List<Asset> listOfAssets = null;

            if (id == 0)
            {
                listOfAssets = _assetManager.GetAll();
            }
            else
            {
                listOfAssets = _assetManager.GetAllByAssetType(id);
            }

            var assets = listOfAssets.Select(a => new AssetViewModel
            {
                Description = a.Description,
                Manufacturer = a.Manufacturer.Name,
                AssetType = a.AssetType.Name,
                TagNumber = a.TagNumber,
                SerialNumber = a.SerialNumber,
                Id = a.Id,
            }).ToList();

            return View(assets);
        }
    }
}
