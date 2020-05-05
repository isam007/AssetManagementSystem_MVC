using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CPRG214.ATS.Domain
{
    [Table("Asset")]
    public class Asset

    {
        public int Id { get; set; }
        [Required, DisplayName("Tag Number")] public string TagNumber { get; set; }

        [Required] public string Model { get; set; }
        
        [Required] public string Description { get; set; }

        [Required] public string SerialNumber { get; set; }
        [DisplayName("Asset Type")] public int AssetTypeId { get; set; }   // value types are not nullable by default


        [DisplayName("Manufacturer")] public int ManufacturerId { get; set; }   //  not nullable by default
        

        //navigation properties (one to one)
        public AssetType AssetType { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}

