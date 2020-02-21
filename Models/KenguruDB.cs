namespace Kenguru_four_
{
    using System;
    using System.Data.Entity;
    using MySql.Data.EntityFramework;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public partial class KenguruDB : DbContext
    {
        public KenguruDB()
            : base("name=kenguru")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Good> Goods { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Good>().HasRequired(a => a.seller).WithMany(g => g.good);
            modelBuilder.Entity<Good>().MapToStoredProcedures();
            modelBuilder.Entity<Category>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Good>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Good>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Good>()
                .Property(e => e.short_discribe)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.track)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.adres)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Seller>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Seller>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Seller>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Seller>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Seller>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Seller>()
                .Property(e => e.adress)
                .IsUnicode(false);

            modelBuilder.Entity<Seller>()
                .Property(e => e.description)
                .IsUnicode(false);
        }
    }
}
