namespace FysiodataAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Maskinetabel")]
    public partial class Maskinetabel
    {
        [Key]
        public int MaskineID { get; set; }

        [StringLength(500)]
        public string MaskineNavn { get; set; }
    }
}
