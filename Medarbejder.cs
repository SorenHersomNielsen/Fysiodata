using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FysiodataAPI
{
    public partial class Medarbejder : DbContext
    {
        public Medarbejder()
            : base("name=Medarbejder")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Medarbejdetabel> Medarbejdetabels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medarbejdetabel>()
                .Property(e => e.Navn)
                .IsUnicode(false);

            modelBuilder.Entity<Medarbejdetabel>()
                .Property(e => e.Adresse)
                .IsUnicode(false);
        }
    }
}
