using CPRG214.ATS.Data;
using CPRG214.ATS.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;

namespace CPRG.ATS.BLL
{
    public interface IAssetManager
    {
        List<Asset> GetAll();
        List<Asset> GetAllByAssetType(int id);
        void Add(Asset asset);
        void Update(Asset asset);
        Asset Find(int id);
        Asset GetDetails(int id);
        void Remove(Asset asset);
    }
    public class AssetManager : IAssetManager
    {
        private AssetsContext _context;

        public AssetManager(AssetsContext context)
        {
            _context = context;
        }
        public List<Asset> GetAll()
        {
            //var context = new AssetsContext();
            var listOfAssets = _context.Assets.Include(a => a.AssetType).Include(m => m.Manufacturer);
            return listOfAssets.ToList();
        }
        public List<Asset> GetAllByAssetType(int id)
        {
            //var context = new AssetsContext();
            var assets = _context.Assets.
                Where(prop => prop.AssetTypeId == id).
                Include(m => m.Manufacturer).Include(at => at.AssetType).ToList();
            return assets;
        }

        public void Add(Asset asset)
        {
            //var context = new AssetsContext();
            _context.Assets.Add(asset);
            _context.SaveChanges();
        }

        public void Update(Asset asset)
        {
            //var context = new AssetsContext();
            var originalAsset = _context.Assets.Find(asset.Id);
            originalAsset.TagNumber = asset.TagNumber;
            originalAsset.Description = asset.TagNumber;
            originalAsset.SerialNumber = asset.SerialNumber;
            originalAsset.AssetTypeId = asset.AssetTypeId;
            originalAsset.ManufacturerId = asset.ManufacturerId;

            _context.SaveChanges();
        }
        public Asset Find(int id)
        {
            //var context = new AssetsContext();
            var originalAsset = _context.Assets.Find(id);

            return originalAsset;
        }
        public Asset GetDetails(int id)
        {
            //var context = new AssetsContext();
            var asset = _context.Assets
                .Include(a => a.AssetType)
                .Include(a => a.Manufacturer)
                .FirstOrDefault(m => m.Id == id);
            
            return asset;
        }

        public void Remove(Asset asset)
        {
            //var context = new AssetsContext();
            _context.Assets.Remove(asset);
            _context.SaveChanges();
        }

    }
}
