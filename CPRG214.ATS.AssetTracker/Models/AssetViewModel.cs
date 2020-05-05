using CPRG214.ATS.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.ATS.AssetTracker.Models
{
    public class AssetViewModel
    {

        public int Id { get; set; }

        public string Description { get; set; }
        public string Manufacturer { get; set; }
        [DisplayName("Asset Type")] public string AssetType { get; set; }
        [DisplayName("Tag Number")] public string TagNumber { get; set; }

        [DisplayName("Serial Number")] public string SerialNumber { get; set; }
    } 
}