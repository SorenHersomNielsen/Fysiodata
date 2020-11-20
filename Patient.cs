namespace FysiodataAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Patient : DbContext
    {
        public Patient()
            : base("name=Patient")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Patientstabel> Patientstabels { get; set; }

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
        }
    }
}
