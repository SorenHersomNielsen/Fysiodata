namespace FysiodataAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patientstabel")]
    public partial class Patientstabel
    {
        [Required]
        [StringLength(500)]
        public string Navn { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Cprnr { get; set; }

        [Required]
        [StringLength(500)]
        public string adresse { get; set; }

        public long tlfnr { get; set; }

        [Required]
        [StringLength(500)]
        public string email { get; set; }

        [Required]
        [StringLength(500)]
        public string nedsatteevne { get; set; }

        
        [StringLength(500)]
        public string Noter { get; set; }
    }
}
