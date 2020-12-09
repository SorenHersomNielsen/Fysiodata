using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FysiodataAPI
{
    public partial class Indstilling : DbContext
    {
        public Indstilling()
            : base("name=Indstilling")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Indstillingtabel> Indstillingtabels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Indstillingtabel>()
                .Property(e => e.IndstillingNavn)
                .IsUnicode(false);
        }
    }
}
