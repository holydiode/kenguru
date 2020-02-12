namespace Kenguru_four_
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class kengu : DbContext
    {
        public kengu()
            : base("name=kengu")
        {
        }

        public virtual DbSet<catigories> catigories { get; set; }
        public virtual DbSet<goods> goods { get; set; }
        public virtual DbSet<orders> orders { get; set; }
        public virtual DbSet<sellers> sellers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
