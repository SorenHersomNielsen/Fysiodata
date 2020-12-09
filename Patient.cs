using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FysiodataAPI
{
    public partial class Patient : DbContext
    {
        public Patient()
            : base("name=Patient1")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Patientstabel> Patientstabel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patientstabel>()
                .Property(e => e.Navn)
                .IsUnicode(false);

            modelBuilder.Entity<Patientstabel>()
                .Property(e => e.adresse)
                .IsUnicode(false);

            modelBuilder.Entity<Patientstabel>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Patientstabel>()
                .Property(e => e.nedsatteevne)
                .IsUnicode(false);

            modelBuilder.Entity<Patientstabel>()
                .Property(e => e.Noter)
                .IsUnicode(false);
        }
    }
}
