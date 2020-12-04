namespace FysiodataAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Medarbejdetabel")]
    public partial class Medarbejdetabel
    {
        [Required]
        [StringLength(500)]
        public string Navn { get; set; }

        [Required]
        [StringLength(500)]
        public string Adresse { get; set; }

        public long Tlfnr { get; set; }

        public long Cprnr { get; set; }

        [Key]
        public int MedarbejdeID { get; set; }
    }
}
