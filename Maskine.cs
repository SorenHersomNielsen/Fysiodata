using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FysiodataAPI
{
    public partial class Maskine : DbContext
    {
        public Maskine()
            : base("name=Maskine")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Maskinetabel> Maskinetabels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Maskinetabel>()
                .Property(e => e.MaskineNavn)
                .IsUnicode(false);
        }
    }
}
