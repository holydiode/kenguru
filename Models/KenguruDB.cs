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
        public virtual DbSet<Good> goods { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Admin> Admins {get; set;}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Good>().HasRequired(a => a.seller).WithMany(g => g.good);
            modelBuilder.Entity<Order>().HasRequired(a => a.good).WithMany(g => g.orders);
            modelBuilder.Entity<Good>().HasRequired(g => g.category).WithMany(c => c.goods);
            modelBuilder.Entity<Category>().HasRequired(c => c.parent).WithMany(c => c.subCategories);

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
                .Property(e => e.adress)
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
