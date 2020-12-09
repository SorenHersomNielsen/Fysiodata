using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FysiodataAPI
{
    public partial class Træning : DbContext
    {
        public Træning()
            : base("name=Træning")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Træningtabel> Træningtabel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
