using CPRG214.ATS.Data;
using CPRG214.ATS.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPRG.ATS.BLL
{
    public interface IManufacturerManager
    { 
        List<Manufacturer> GetAll();
        IList GetAsKeyValuePairs();
        void Add(Manufacturer manufacturer);
        void Update(Manufacturer manufacturer);
        Manufacturer Find(int id);
    }


    public class ManufacturerManager : IManufacturerManager
    {
        private AssetsContext _context;

        public ManufacturerManager(AssetsContext context)
        {
            _context = context;
        }
        public List<Manufacturer> GetAll()
        {
            //var context = new AssetsContext();
            var listOfManufacturers = _context.Manufacturers;
            return listOfManufacturers.ToList();
        }
        public IList GetAsKeyValuePairs()
        {
            //var context = new AssetsContext();
            var brands = _context.Manufacturers.Select(m => new
            {
                Value = m.Id,
                Text = m.Name
            }).ToList();
            return brands;
        }
        public void Add(Manufacturer manufacturer)
        {
            //var context = new AssetsContext();
            _context.Manufacturers.Add(manufacturer);
            _context.SaveChanges();
        }

        public void Update(Manufacturer Manufacturer)
        {
            //var context = new AssetsContext();
            var originalManufacturer = _context.Manufacturers.Find(Manufacturer.Id);
            originalManufacturer.Name = Manufacturer.Name;

            _context.SaveChanges();
        }
        public Manufacturer Find(int id)
        {
            //var context = new AssetsContext();
            var originalManufacturer = _context.Manufacturers.Find(id);

            return originalManufacturer;
        }
    }
}
