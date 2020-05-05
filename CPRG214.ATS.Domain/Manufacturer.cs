using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CPRG214.ATS.Domain
{
    [Table("Manufacturer")]
    public class Manufacturer
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        //navigation properties (one to many)
        [Required, Display(Name = "Asset")] public ICollection<Asset> Assets { get; set; }
    }
}
