using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPRG214.ATS.Domain
{
    [Table("AssetType")]
    public class AssetType
    {
        public int Id { get; set; }
        [Required, Display(Name="Type")] public string Name { get; set; }

        //navigation properties (one to many)
        public ICollection<Asset> Assets { get; set; }
    }
}
