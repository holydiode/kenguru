namespace Kenguru_four_
{
    using System;
    using System.Data.Entity;
    using MySql.Data.EntityFramework;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public partial class kenguru : DbContext
    {
        public kenguru()
            : base("name=kenguru")
        {
        }

        public virtual DbSet<catigories> catigories { get; set; }
        public virtual DbSet<goods> goods { get; set; }
        public virtual DbSet<orders> orders { get; set; }
        public virtual DbSet<sellers> sellers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<goods>().HasRequired(a => a.seller).WithMany(g => g.good);
            modelBuilder.Entity<goods>().MapToStoredProcedures();

            modelBuilder.Entity<catigories>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<goods>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<goods>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<goods>()
                .Property(e => e.short_discribe)
                .IsUnicode(false);

            modelBuilder.Entity<orders>()
                .Property(e => e.track)
                .IsUnicode(false);

            modelBuilder.Entity<orders>()
                .Property(e => e.adres)
                .IsUnicode(false);

            modelBuilder.Entity<orders>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<orders>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<sellers>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<sellers>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<sellers>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<sellers>()
                .Property(e => e.pasword)
                .IsUnicode(false);

            modelBuilder.Entity<sellers>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<sellers>()
                .Property(e => e.adress)
                .IsUnicode(false);

            modelBuilder.Entity<sellers>()
                .Property(e => e.description)
                .IsUnicode(false);
        }
    }
}
