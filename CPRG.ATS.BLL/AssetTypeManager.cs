using CPRG214.ATS.Data;
using CPRG214.ATS.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPRG.ATS.BLL
{
    public interface IAssetTypeManager
    {
        List<AssetType> GetAll();
        IList GetAsKeyValuePairs();
        void Add(AssetType assetType);
        void Update(AssetType assetType);
        AssetType Find(int id);
    }
    public class AssetTypeManager : IAssetTypeManager
    {
        private AssetsContext _context;

        public AssetTypeManager(AssetsContext context)
        {
            _context = context;
        }

        public List<AssetType> GetAll()
        {
            //var context = new AssetsContext();
            var listOfAssetTypes = _context.AssetTypes;
            return listOfAssetTypes.ToList();
        }
        public IList GetAsKeyValuePairs()
        {
            //var context = new AssetsContext();
            var types = _context.AssetTypes.Select(type => new
            {
                Value = type.Id,
                Text = type.Name
            }).ToList();
            return types;
        }
        public void Add(AssetType assetType)
        {
            //var context = new AssetsContext();
            _context.AssetTypes.Add(assetType);
            _context.SaveChanges();
        }
        public void Update(AssetType assetType)
        {
            //var context = new AssetsContext();
            var originalAssetType = _context.AssetTypes.Find(assetType.Id);
            originalAssetType.Name = assetType.Name;

            _context.SaveChanges();
        }
        public AssetType Find(int id)
        {
            //var context = new AssetsContext();
            var originalAssetType = _context.AssetTypes.Find(id);

            return originalAssetType;
        }
    }
}
