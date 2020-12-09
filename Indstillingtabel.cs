namespace FysiodataAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Indstillingtabel")]
    public partial class Indstillingtabel
    {
        [Key]
        public int IndstillingID { get; set; }

        [StringLength(500)]
        public string IndstillingNavn { get; set; }

        public int? IndstillingTal { get; set; }
    }
}
