namespace FysiodataAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Træningtabel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int dato { get; set; }

        public int? MaskineID { get; set; }

        public int? IndstillingID { get; set; }

        public int? Tid { get; set; }

        public int? Vægt { get; set; }
    }
}
